using Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MegaMudMDCreator
{
    public class RacesMDWriter<T> : MDWriterFactory<T>
        where T : Race
    {
        private const int MAX_BYTES_FOR_ABILITIES = 20;
        private readonly List<Race> _races;
        public RacesMDWriter(List<Race> races)
        {
            _races = races;
        }

        public override List<byte[]> GetListOfRecordBytes()
        {
            List<byte[]> racesBytes = new List<byte[]>(_races.Count);

            List<Race> sortedRaces = _races.OrderBy(o => o.ID.ToString()).ToList();

            foreach (Race race in sortedRaces)
            {
                Console.WriteLine($"Doing raceID {race.ID}");
                byte[] serializedRace = Serialize(race);
                racesBytes.Add(serializedRace);
            }

            return racesBytes;
        }

        public override void WriteFile()
        {
            string filename = MDFiles.RACES_OUTPUT_FILE;

            var file = new MDFileData(filename, GetListOfRecordBytes());
            file.WriteToFile();
        }

        private byte[] Serialize(Race rec)
        {
            RaceMD raceMD = default;

            raceMD.RaceId = (ushort)rec.ID;
            raceMD.RaceName = rec.Name;

            raceMD.MinimumStrength = (byte)rec.MinimumStrength;
            raceMD.MaximumStrength = (byte)rec.MaximumStrength;
            raceMD.MinimumIntellect = (byte)rec.MinimumAgility;
            raceMD.MaximumIntellect = (byte)rec.MaximumIntellect;
            raceMD.MinimumWillpower = (byte)rec.MinimumWillpower;
            raceMD.MaximumWillpower = (byte)rec.MaximumWillpower;
            raceMD.MinimumAgility = (byte)rec.MinimumAgility;
            raceMD.MaximumAgility = (byte)rec.MaximumAgility;
            raceMD.MinimumHealth = (byte)rec.MinimumHealth;
            raceMD.MaximumHealth = (byte)rec.MaximumHealth;
            raceMD.MinimumCharm = (byte)rec.MinimumCharm;
            raceMD.MaximumCharm = (byte)rec.MaximumCharm;
            raceMD.HitpointModifierPerLevel = (byte)rec.HitpointModifierPerLevel;
            raceMD.ExperiencePercentage = (byte)rec.ExperiencePercentage;

            raceMD.AbilityKeys = new byte[MAX_BYTES_FOR_ABILITIES];
            raceMD.AbilityValues = new byte[MAX_BYTES_FOR_ABILITIES];

            int i = 0;
            foreach (KeyValuePair<Race.AbilitiesAndModifiers, short> kvp in rec.AbilitiesAndMods)
            {
                Race.AbilitiesAndModifiers ability = kvp.Key;
                short abilityMod = kvp.Value;

                byte[] k = BitConverter.GetBytes((short)ability);
                byte[] v = BitConverter.GetBytes(abilityMod);

                raceMD.AbilityKeys[i] = k[1];
                raceMD.AbilityKeys[i + 1] = k[0];

                raceMD.AbilityValues[i] = v[1];
                raceMD.AbilityValues[i + 1] = v[0];

                i += 2;
            }

            byte[] unusedByte = { 0x01 }; // Always 0x01
            byte[] raceIdAsCharacters = Encoding.ASCII.GetBytes(raceMD.RaceId.ToString());
            byte[] padding = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 };

            byte length = UshortToByteArray((ushort)(unusedByte.Length + raceIdAsCharacters.Length + padding.Length + Marshal.SizeOf(raceMD)))[1];

            var raceHeaderParts = new List<byte[]>(4)
            {
                new byte[] { length },
                unusedByte,
                raceIdAsCharacters,
                padding
            };

            byte[] raceHeader = raceHeaderParts.SelectMany(t => t).ToArray();
            byte[] raceRecord = GetBytes(raceMD);

            return CombineArrays(raceHeader, raceRecord);
        }

        internal byte[] GetBytes(RaceMD str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}

using Records;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MegaMudMDCreator
{
    public class RacesMDReader<T> : MDReaderFactory<T>
        where T : Race
    {
        public static int RaceIDOffset = 0;
        public static int RaceNameOffset = 2;
        public static int RaceNameLength = 28;
        public static int MinStrengthOffset = 32;
        public static int MinIntellectOffset = 33;
        public static int MinWillpowerOffset = 34;
        public static int MinAgilityOffset = 35;
        public static int MinHealthOffset = 36;
        public static int MinCharmOffset = 37;
        public static int MaxStrengthOffset = 38;
        public static int MaxIntellectOffset = 39;
        public static int MaxWillpowerOffset = 40;
        public static int MaxAgilityOffset = 41;
        public static int MaxHealthOffset = 42;
        public static int MaxCharmOffset = 43;
        public static int HPPerLevelOffset = 44;
        public static int ExpOffset = 45;
        public static int AbilityKeysOffset = 47;
        public static int AbilityKeysLength = 20;
        public static int AbilityValuesOffset = 67;
        public static int AbilityValuesLength = 20;
        public static int MaxAbilities = 9;
        public static int AbilityKeyLength = 2;
        public static int AbilityValueLength = 2;

        private static void UpdateOffsetsAndLengths(int headerOffset)
        {
            RaceIDOffset += headerOffset;
            RaceNameOffset += headerOffset;
            MinStrengthOffset += headerOffset;
            MinIntellectOffset += headerOffset;
            MinWillpowerOffset += headerOffset;
            MinAgilityOffset += headerOffset;
            MinHealthOffset += headerOffset;
            MinCharmOffset += headerOffset;
            MaxStrengthOffset += headerOffset;
            MaxIntellectOffset += headerOffset;
            MaxWillpowerOffset += headerOffset;
            MaxAgilityOffset += headerOffset;
            MaxHealthOffset += headerOffset;
            MaxCharmOffset += headerOffset;
            HPPerLevelOffset += headerOffset;
            ExpOffset += headerOffset;
            AbilityKeysOffset += headerOffset;
            AbilityValuesOffset += headerOffset;
        }

        public override List<T> GetAllRecords()
        {
            List<List<byte>> rawData = MDFileReader.FileReader(MDFiles.RACES_FILE);

            var races = new List<T>();

            foreach (List<byte> raw in rawData)
            {
                //Console.WriteLine("Length of raw: {0}", raw.Count);
                //string data = raw.Aggregate(string.Empty, (current, byt) => current + string.Format("{0:X2} ", byt));
                //Console.WriteLine("RawData: {0}", data);

                int raceId = -1;
                string name = string.Empty;
                int minimumStrength = -1;
                int maximumStrength = -1;
                int minimumIntellect = -1;
                int maximumIntellect = -1;
                int minimumWillpower = -1;
                int maximumWillpower = -1;
                int minimumAgility = -1;
                int maximumAgility = -1;
                int minimumHealth = -1;
                int maximumHealth = -1;
                int minimumCharm = -1;
                int maximumCharm = -1;
                int hitpointModifierPerLevel = -1;
                int experiencePercentage = -1;
                var abilitiesAndMods = new Dictionary<Race.AbilitiesAndModifiers, int>();


                // Since headers on rows are variable length, we need to first get to a null and then 
                // find the index of the first bit of data past "0x80" and know that's where we start
                int firstNull = raw.IndexOf(0x00);
                int headerOffset = raw.IndexOf(0x80, firstNull) + 1;
                UpdateOffsetsAndLengths(headerOffset);


                string data = raw.Aggregate(string.Empty, (current, byt) => current + string.Format("{0:X2} ", byt));
                //Console.WriteLine("RaceIDOffset: {1}, RawData: {0}", data, RaceIDOffset);
                //UpdateOffsetsAndLengths(-headerOffset);
                //continue;


                // RaceID (reverse order because it's stored Little Endian
                var id = new byte[] {
                    raw[RaceIDOffset],
                    raw[RaceIDOffset+1],
                };
                raceId = BitConverter.ToInt16(id, 0);

                // Race Name
                for (int i = RaceNameOffset; (i < RaceNameOffset + RaceNameLength) && (raw[i] != 0x00); i++)
                {
                    name += (char)raw[i];
                }

                // Exp
                var exp = new byte[]
                {
                    raw[ExpOffset],
                    raw[ExpOffset+1],
                };
                experiencePercentage = BitConverter.ToInt16(exp, 0);

                // HP modifier per level
                hitpointModifierPerLevel = Convert.ToInt32(raw[HPPerLevelOffset]);

                // Min/Max Stats
                minimumStrength = Convert.ToInt32(raw[MinStrengthOffset]);
                maximumStrength = Convert.ToInt32(raw[MaxStrengthOffset]);

                minimumIntellect = Convert.ToInt32(raw[MinIntellectOffset]);
                maximumIntellect = Convert.ToInt32(raw[MaxIntellectOffset]);

                minimumWillpower = Convert.ToInt32(raw[MinWillpowerOffset]);
                maximumWillpower = Convert.ToInt32(raw[MaxWillpowerOffset]);

                minimumAgility = Convert.ToInt32(raw[MinAgilityOffset]);
                maximumAgility = Convert.ToInt32(raw[MaxAgilityOffset]);

                minimumHealth = Convert.ToInt32(raw[MinHealthOffset]);
                maximumHealth = Convert.ToInt32(raw[MaxHealthOffset]);

                minimumCharm = Convert.ToInt32(raw[MinCharmOffset]);
                maximumCharm = Convert.ToInt32(raw[MaxCharmOffset]);


                // Modifiers and Abilities
                for (int i = 0; i < MaxAbilities; i++)
                {
                    var rawKey = new byte[] 
                    {
                        raw[AbilityKeysOffset + (i*AbilityKeyLength)],
                        raw[AbilityKeysOffset + (i*AbilityKeyLength) + 1],
                    };

                    var rawValue = new byte[] 
                    {
                        raw[AbilityValuesOffset + (i*AbilityValueLength)],
                        raw[AbilityValuesOffset + (i*AbilityValueLength) + 1],
                    };

                    var key = BitConverter.ToInt16(rawKey, 0);
                    var value = BitConverter.ToInt16(rawValue, 0);

                    if (key != 0)
                    {
                        abilitiesAndMods.Add((Race.AbilitiesAndModifiers)key, value);
                    }
                }

                var thisRace = new Race
                {
                    ID = raceId,
                    Name = name,
                    MinimumStrength = minimumStrength,
                    MaximumStrength = maximumStrength,
                    MinimumIntellect = minimumIntellect,
                    MaximumIntellect = maximumIntellect,
                    MinimumWillpower = minimumWillpower,
                    MaximumWillpower = maximumWillpower,
                    MinimumAgility = minimumAgility,
                    MaximumAgility = maximumAgility,
                    MinimumHealth = minimumHealth,
                    MaximumHealth = maximumHealth,
                    MinimumCharm = minimumCharm,
                    MaximumCharm = maximumCharm,
                    HitpointModifierPerLevel = hitpointModifierPerLevel,
                    ExperiencePercentage = experiencePercentage,
                    AbilitiesAndMods = abilitiesAndMods,
                };

                UpdateOffsetsAndLengths(-headerOffset);
                races.Add((T)thisRace);
            }

            return races;
        }
    }
}

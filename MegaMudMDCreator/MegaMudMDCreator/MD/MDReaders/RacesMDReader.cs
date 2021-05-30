using Records;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MegaMudMDCreator
{
    public class RacesMDReader<T> : MDReaderFactory<T>
        where T : Race
    {
        public override List<T> GetAllRecords()
        {
            var races = new List<T>();

            List<RaceMD> rawData = MDFileReader.FileReader<RaceMD>(MDFiles.RACES_FILE);
            if (rawData == null)
            {
                Console.WriteLine($"Unable to read file {MDFiles.RACES_FILE} - not parsing Items");
                return races;
            }


            foreach (RaceMD race in rawData)
            {
                Race newRace = new Race()
                {
                    ID = race.RaceId,
                    Name = race.RaceName,
                    MinimumStrength = race.MinimumStrength,
                    MaximumStrength = race.MaximumStrength,
                    MinimumIntellect = race.MinimumIntellect,
                    MaximumIntellect = race.MaximumIntellect,
                    MinimumWillpower = race.MinimumWillpower,
                    MaximumWillpower = race.MaximumWillpower,
                    MinimumAgility = race.MinimumAgility,
                    MaximumAgility = race.MaximumAgility,
                    MinimumHealth = race.MinimumHealth,
                    MaximumHealth = race.MaximumHealth,
                    MinimumCharm = race.MinimumCharm,
                    MaximumCharm = race.MaximumCharm,
                    HitpointModifierPerLevel = race.HitpointModifierPerLevel,
                    ExperiencePercentage = race.ExperiencePercentage,
                    AbilitiesAndMods = new Dictionary<Race.AbilitiesAndModifiers, short>(),
                };

                Array.Reverse(race.Ability1Key);
                Array.Reverse(race.Ability2Key);
                Array.Reverse(race.Ability3Key);
                Array.Reverse(race.Ability4Key);
                Array.Reverse(race.Ability5Key);
                Array.Reverse(race.Ability6Key);
                Array.Reverse(race.Ability7Key);
                Array.Reverse(race.Ability8Key);

                Array.Reverse(race.Ability1Value);
                Array.Reverse(race.Ability2Value);
                Array.Reverse(race.Ability3Value);
                Array.Reverse(race.Ability4Value);
                Array.Reverse(race.Ability5Value);
                Array.Reverse(race.Ability6Value);
                Array.Reverse(race.Ability7Value);
                Array.Reverse(race.Ability8Value);

                ushort ability1Key = BitConverter.ToUInt16(race.Ability1Key, 0);
                if (ability1Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability1Key, BitConverter.ToInt16(race.Ability1Value, 0));

                ushort ability2Key = BitConverter.ToUInt16(race.Ability2Key, 0);
                if (ability2Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability2Key, BitConverter.ToInt16(race.Ability2Value, 0));

                ushort ability3Key = BitConverter.ToUInt16(race.Ability3Key, 0);
                if (ability3Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability3Key, BitConverter.ToInt16(race.Ability3Value, 0));

                ushort ability4Key = BitConverter.ToUInt16(race.Ability4Key, 0);
                if (ability4Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability4Key, BitConverter.ToInt16(race.Ability4Value, 0));

                ushort ability5Key = BitConverter.ToUInt16(race.Ability5Key, 0);
                if (ability5Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability5Key, BitConverter.ToInt16(race.Ability5Value, 0));

                ushort ability6Key = BitConverter.ToUInt16(race.Ability6Key, 0);
                if (ability6Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability6Key, BitConverter.ToInt16(race.Ability6Value, 0));

                ushort ability7Key = BitConverter.ToUInt16(race.Ability7Key, 0);
                if (ability7Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability7Key, BitConverter.ToInt16(race.Ability7Value, 0));

                ushort ability8Key = BitConverter.ToUInt16(race.Ability8Key, 0);
                if (ability8Key != 0)
                    newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)ability8Key, BitConverter.ToInt16(race.Ability8Value, 0));

                races.Add((T)newRace);
            }

            return races;
        }
    }
}

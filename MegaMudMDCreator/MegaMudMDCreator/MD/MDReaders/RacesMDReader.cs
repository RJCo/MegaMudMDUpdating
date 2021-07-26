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
                Console.WriteLine($"Unable to read file {MDFiles.RACES_FILE} - not parsing Races");
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

                // Abilities and Mods
                for (int i = 0; i < 8; i++)
                {
                    byte[] abilityBytes = race.AbilityKeys.Skip(i * 2).Take(2).ToArray();
                    byte[] abilityValuesBytes = race.AbilityValues.Skip(i * 2).Take(2).ToArray();

                    var abilityCode = BitConverter.ToUInt16(abilityBytes, 0);
                    var abilityValueCode = BitConverter.ToInt16(abilityValuesBytes, 0);

                    // If the ability is zero, the value is zero or garbage, so ignore it
                    if (abilityCode != 0)
                    {
                        newRace.AbilitiesAndMods.Add((Race.AbilitiesAndModifiers)abilityCode, abilityValueCode);
                    }
                }

                races.Add((T)newRace);
            }

            return races;
        }
    }
}

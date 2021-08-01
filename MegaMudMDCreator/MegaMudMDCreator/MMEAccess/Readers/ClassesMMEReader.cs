using Records;
using System.Collections.Generic;
using System.Data.OleDb;
using static Records.Class;

namespace MegaMudMDCreator
{
    public class ClassesMMEReader
    {
        private readonly string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Properties.Settings.Default.MMUDExplorerMDBPath}";
        private const string getAllClasses = @"SELECT [Number], [Name], [MinHits], [MaxHits], [ExpTable],
                                                      [MageryType], [MageryLVL], [WeaponType], [ArmourType], [CombatLVL],
                                                      [Abil-0], [AbilVal-0], [Abil-1], [AbilVal-1],
                                                      [Abil-2], [AbilVal-2], [Abil-3], [AbilVal-3],
                                                      [Abil-4], [AbilVal-4], [Abil-5], [AbilVal-5],
                                                      [Abil-6], [AbilVal-6], [Abil-7], [AbilVal-7],
                                                      [Abil-8], [AbilVal-8], [Abil-9], [AbilVal-9]
                                               FROM Classes";

        public List<IRecord> GetAllRecords()
        {
            List<IRecord> classes = new List<IRecord>();
            using (var connection = new OleDbConnection(connString))
            {
                connection.Open();
              
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getAllClasses;
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int number = int.Parse(reader["Number"].ToString());
                        string name = reader["Name"].ToString();
                        int minimumHitpoints = int.Parse(reader["MinHits"].ToString());
                        int maximumHitpoints = int.Parse(reader["MaxHits"].ToString());
                        int experience = int.Parse(reader["ExpTable"].ToString());
                        int combatLevel = int.Parse(reader["CombatLVL"].ToString());
                        int weaponType = int.Parse(reader["WeaponType"].ToString());
                        int armourType = int.Parse(reader["ArmourType"].ToString());
                        int magicLevel = int.Parse(reader["MageryLVL"].ToString());
                        int magicType = int.Parse(reader["MageryType"].ToString());

                        var c = new Class()
                        {
                            ID = number,
                            Name = name,
                            ExperiencePercentage = experience,
                            Combat = combatLevel - 2,  // N.B.  MajorMud/Nightmare has vanilla Priest = Combat 3 and Warrior = Combat 6
                            HitpointPerLevelMinimum = minimumHitpoints,
                            HitpointPerLevelMaximum = maximumHitpoints,
                            WeaponType = (WeaponClasses)weaponType,
                            ArmorType = (ArmorClasses)armourType,
                            MagicLevel = magicLevel,
                            MagicType = (MagicTypes)magicType,
                        };

                        var ability0 = int.Parse(reader["Abil-0"].ToString());
                        if (ability0 > 0)
                        {
                            var ability0value = short.Parse(reader["AbilVal-0"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability0, ability0value);
                        }

                        var ability1 = int.Parse(reader["Abil-1"].ToString());
                        if (ability1 > 0)
                        {
                            var ability1value = short.Parse(reader["AbilVal-1"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability1, ability1value);
                        }

                        var ability2 = int.Parse(reader["Abil-2"].ToString());
                        if (ability2 > 0)
                        {
                            var ability2value = short.Parse(reader["AbilVal-2"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability2, ability2value);
                        }

                        var ability3 = int.Parse(reader["Abil-3"].ToString());
                        if (ability0 > 0)
                        {
                            var ability3value = short.Parse(reader["AbilVal-3"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability3, ability3value);
                        }

                        var ability4 = int.Parse(reader["Abil-4"].ToString());
                        if (ability4 > 0)
                        {
                            var ability4value = short.Parse(reader["AbilVal-4"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability4, ability4value);
                        }

                        var ability5 = int.Parse(reader["Abil-5"].ToString());
                        if (ability5 > 0)
                        {
                            var ability5value = short.Parse(reader["AbilVal-5"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability5, ability5value);
                        }

                        var ability6 = int.Parse(reader["Abil-6"].ToString());
                        if (ability6 > 0)
                        {
                            var ability6value = short.Parse(reader["AbilVal-6"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability6, ability6value);
                        }

                        var ability7 = int.Parse(reader["Abil-7"].ToString());
                        if (ability7 > 0)
                        {
                            var ability7value = short.Parse(reader["AbilVal-7"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability7, ability7value);
                        }

                        var ability8 = int.Parse(reader["Abil-8"].ToString());
                        if (ability8 > 0)
                        {
                            var ability8value = short.Parse(reader["AbilVal-8"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability8, ability8value);
                        }

                        var ability9 = int.Parse(reader["Abil-9"].ToString());
                        if (ability9 > 0)
                        {
                            var ability9value = short.Parse(reader["AbilVal-9"].ToString());
                            c.AbilitiesAndMods.Add((Common.Abilities)ability9, ability9value);
                        }

                        classes.Add(c);
                    }
                }
            }

            return classes;
        }
    }
}

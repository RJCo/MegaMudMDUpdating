using Records;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaMudMDCreator
{
    public class ClassesMDReader<T> : MDReaderFactory<T>
        where T : Class
    {
        public override List<T> GetAllRecords()
        {
            var classes = new List<T>();

            List<ClassMD> rawData = MDFileReader.FileReader<ClassMD>(MDFiles.CLASSES_FILE);
            if (rawData == null)
            {
                Console.WriteLine($"Unable to read file {MDFiles.CLASSES_FILE} - not parsing Classes");
                return classes;
            }

            foreach (ClassMD cls in rawData)
            {
                Class newClass = new Class()
                {
                    ID = cls.ClassId,
                    Name = cls.ClassName,
                    ExperiencePercentage = BitConverter.ToUInt16(cls.ExperienceBase, 0),
                    Combat = cls.CombatLevel,
                    HitpointPerLevelMinimum = cls.MinHPPerLevel,
                    HitpointPerLevelMaximum = cls.MaxHPPerLevel,
                    WeaponType = (Class.WeaponClasses)cls.WeaponsUsable,
                    ArmorType = (Class.ArmorClasses)cls.ArmorUseable,
                    MagicLevel = cls.MagicLevel,
                    MagicType = (Class.MagicTypes)cls.MagicLevel,
                    AbilitiesAndMods = new Dictionary<Common.Abilities, short>()
                };

                // Abilities and Mods
                for (int i = 0; i < 8; i++)
                {
                    byte[] abilityBytes = cls.AbilityKeys.Skip(i * 2).Take(2).ToArray();
                    byte[] abilityValuesBytes = cls.AbilityValues.Skip(i * 2).Take(2).ToArray();

                    Array.Reverse(abilityBytes);
                    Array.Reverse(abilityValuesBytes);

                    var abilityCode = BitConverter.ToUInt16(abilityBytes, 0);
                    var abilityValueCode = BitConverter.ToInt16(abilityValuesBytes, 0);

                    // If the ability is zero, the value is zero or garbage, so ignore it
                    if (abilityCode != 0)
                    {
                        newClass.AbilitiesAndMods.Add((Common.Abilities)abilityCode, abilityValueCode);
                    }
                }

                classes.Add((T)newClass);
            }

            return classes;
        }
    }
}

using Records;
using System;
using System.Collections.Generic;


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
                Console.WriteLine($"Unable to read file {MDFiles.CLASSES_FILE} - not parsing Items");
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

                Array.Reverse(cls.Ability1Key);
                Array.Reverse(cls.Ability2Key);
                Array.Reverse(cls.Ability3Key);
                Array.Reverse(cls.Ability4Key);
                Array.Reverse(cls.Ability5Key);
                Array.Reverse(cls.Ability6Key);
                Array.Reverse(cls.Ability7Key);
                Array.Reverse(cls.Ability8Key);

                Array.Reverse(cls.Ability1Value);
                Array.Reverse(cls.Ability2Value);
                Array.Reverse(cls.Ability3Value);
                Array.Reverse(cls.Ability4Value);
                Array.Reverse(cls.Ability5Value);
                Array.Reverse(cls.Ability6Value);
                Array.Reverse(cls.Ability7Value);
                Array.Reverse(cls.Ability8Value);

                ushort ability1Key = BitConverter.ToUInt16(cls.Ability1Key, 0);
                if (ability1Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability1Key, BitConverter.ToInt16(cls.Ability1Value, 0));

                ushort ability2Key = BitConverter.ToUInt16(cls.Ability2Key, 0);
                if (ability2Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability2Key, BitConverter.ToInt16(cls.Ability2Value, 0));

                ushort ability3Key = BitConverter.ToUInt16(cls.Ability3Key, 0);
                if (ability3Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability3Key, BitConverter.ToInt16(cls.Ability3Value, 0));

                ushort ability4Key = BitConverter.ToUInt16(cls.Ability4Key, 0);
                if (ability4Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability4Key, BitConverter.ToInt16(cls.Ability4Value, 0));

                ushort ability5Key = BitConverter.ToUInt16(cls.Ability5Key, 0);
                if (ability5Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability5Key, BitConverter.ToInt16(cls.Ability5Value, 0));

                ushort ability6Key = BitConverter.ToUInt16(cls.Ability6Key, 0);
                if (ability6Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability6Key, BitConverter.ToInt16(cls.Ability6Value, 0));

                ushort ability7Key = BitConverter.ToUInt16(cls.Ability7Key, 0);
                if (ability7Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability7Key, BitConverter.ToInt16(cls.Ability7Value, 0));

                ushort ability8Key = BitConverter.ToUInt16(cls.Ability8Key, 0);
                if (ability8Key != 0)
                    newClass.AbilitiesAndMods.Add((Common.Abilities)ability8Key, BitConverter.ToInt16(cls.Ability8Value, 0));

                classes.Add((T)newClass);
            }

            return classes;
        }
    }
}

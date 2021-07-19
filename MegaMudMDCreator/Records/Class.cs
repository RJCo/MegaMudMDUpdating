using System;
using System.Collections.Generic;
using System.Text;

namespace Records
{
    public class Class : IRecord
    {
        #region Enums
        public enum WeaponClasses
        {
            OneHandedBlunt = 0x00,
            TwoHandedBlunt = 0x01, 
            OneHandedSharp = 0x02,
            TwoHandedSharp = 0x03,
            OneHanded = 0x04,
            TwoHanded = 0x05,
            AnySharp = 0x06,
            BluntOnly = 0x07,
            AllWeapons = 0x08,
            Staff = 0x09,
        }

        public enum ArmorClasses
        {
            Platemail = 0x09,
            Scalemail = 0x08,
            Chainmail = 0x07,
            Leather = 0x06,
            Ninja = 0x02,
            Silk = 0x01,
            Unknown = 0x00,
        }

        public enum MagicTypes
        {
            None = 0x00,
            Mage = 0x01,
            Priest = 0x02,
            Druid = 0x03,
            Bard = 0x04,
            Kai = 0x05,
        }
        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
        public int ExperiencePercentage { get; set; }
        public int Combat { get; set; }
        public int HitpointPerLevelMinimum { get; set; }
        public int HitpointPerLevelMaximum { get; set; }
        public WeaponClasses WeaponType { get; set; }
        public ArmorClasses ArmorType { get; set; }
        public int MagicLevel { get; set; }
        public MagicTypes MagicType { get; set; }
        public Dictionary<Common.Abilities, short> AbilitiesAndMods { get; set; } = new Dictionary<Common.Abilities, short>(10); // MajorMud only has at most 10 abilities/mods for Classes

        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"ID: {ID}\t");
            sb.Append($"Name: {Name}\n");
            sb.Append($"Experience: {ExperiencePercentage}\n");
            sb.Append($"Combat: {Combat}\n");
            sb.Append($"HP Per Level (min): {HitpointPerLevelMinimum}\t");
            sb.Append($"HP Per Level (max): {HitpointPerLevelMaximum}\n");
            sb.Append($"Weapon Type: {Enum.GetName(typeof(WeaponClasses), WeaponType)}\t");
            sb.Append($"Armor Type: {Enum.GetName(typeof(ArmorClasses), ArmorType)}\n");
            sb.Append($"Magic Type: {Enum.GetName(typeof(MagicTypes), MagicType)}\t");
            sb.Append($"Magic Level: {MagicLevel}\n");

            foreach (KeyValuePair<Common.Abilities, short> ability in AbilitiesAndMods)
            {
                sb.Append($"Ability/Modifier: {Enum.GetName(typeof(Common.Abilities), ability.Key)}:{ability.Value}\n");
            }

            return sb.ToString();
        }
    }
}

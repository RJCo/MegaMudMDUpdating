using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    public class Class : IMDFileRecord
    {
        #region Enums
        public enum WeaponClasses
        {
            Unknown = 0x00,
            AllWeapons = 0x08,
            OneHanded = 0x04,
            Staff = 0x09,
            BluntOnly = 0x07,
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
        public Dictionary<Common.Abilities, int> AbilitiesAndMods { get; set; }

        public new string ToString() {
            string classStr = string.Empty;
            
            classStr += string.Format("ID: {0}\t", ID);
            classStr += string.Format("Name: {0}\n", Name);
            classStr += string.Format("Experience: {0}\n", ExperiencePercentage);
            classStr += string.Format("Combat: {0}\n", Combat);
            classStr += string.Format("HP Per Level (min): {0}\t", HitpointPerLevelMinimum);
            classStr += string.Format("HP Per Level (max): {0}\n", HitpointPerLevelMaximum);
            classStr += string.Format("Weapon Type: {0}\t", Enum.GetName(typeof(WeaponClasses), WeaponType));
            classStr += string.Format("Armor Type: {0}\n", Enum.GetName(typeof(ArmorClasses), ArmorType));
            classStr += string.Format("Magic Type: {0}\t", Enum.GetName(typeof(MagicTypes), MagicType)); 
            classStr += string.Format("Magic Level: {0}\n", MagicLevel);

            foreach (var ability in AbilitiesAndMods) {
                classStr += string.Format("Ability/Modifier: {0}:{1}\n", Enum.GetName(typeof(Common.Abilities), ability.Key), ability.Value);
            }

            return classStr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    public class Item : IMDFileRecord
    {
        /*
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

        public enum AbilitiesAndModifiers
        {
            Bash = 0x1f,
            Stealth = 0x67,
            Jumpkick = 0x23,
            Dodge = 0x22,
            Tracking = 0x26,
            HitMagical = 0x8e,
            AntiMagic = 0x33,
            Thievery = 0x27,
            Crit = 0x3a,
            Kick = 0x1d,
            Punch = 0x1e,
            Picklocks = 0x25,
            Traps = 0x28,
        }
        #endregion
        */

        /*
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
        public Dictionary<AbilitiesAndModifiers, int> AbilitiesAndMods { get; set; }
        */

        public new string ToString() {
            throw new NotImplementedException();

            /*
            string recordStr = string.Empty;

            recordStr += string.Format("ID: {0}\t", ID);
            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("\tExperience: {0}\n", ExperiencePercentage);
            recordStr += string.Format("\tCombat: {0}\n", Combat);
            recordStr += string.Format("\tHP Per Level (min): {0}\t", HitpointPerLevelMinimum);
            recordStr += string.Format("\tHP Per Level (max): {0}\n", HitpointPerLevelMaximum);
            recordStr += string.Format("\tWeapon Type: {0}\t", Enum.GetName(typeof(WeaponClasses), WeaponType));
            recordStr += string.Format("\tArmor Type: {0}\n", Enum.GetName(typeof(ArmorClasses), ArmorType));
            recordStr += string.Format("\tMagic Type: {0}\t", Enum.GetName(typeof(MagicTypes), MagicType));
            recordStr += string.Format("\tMagic Level: {0}\n", MagicLevel);

            foreach (var ability in AbilitiesAndMods) {
                recordStr += string.Format("\tAbility/Modifier: {0}:{1}\n", Enum.GetName(typeof(AbilitiesAndModifiers), ability.Key), ability.Value);
            }
            return recordStr;
            */
        }
    }
}

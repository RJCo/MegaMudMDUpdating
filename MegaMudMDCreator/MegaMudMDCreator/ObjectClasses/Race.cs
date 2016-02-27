using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    public class Race : IMDFileRecord
    {
        #region Enums
        public enum AbilitiesAndModifiers
        {
            ResistMagic = 0x24,
            ResistDamage = 0x07,
            PoisonImmunity = 0x15,
            Defense = 0x02,
            ResistFire = 0x05,
            ResistCold = 0x03,
            NightVision = 0x0d,
            Stealth = 0x66,
            Tracking = 0x26,
            Perception = 0x4d,
            Encumberance = 0x60,
            Picklocks = 0x25,
            Dodge = 0x22,
            Mana = 0x45,
            Crit = 0x3a,
            Alter3rdAttack = 0x6a,
        }
        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
        public int MinimumStrength { get; set; }
        public int MaximumStrength { get; set; }
        public int MinimumIntellect { get; set; }
        public int MaximumIntellect { get; set; }
        public int MinimumWillpower { get; set; }
        public int MaximumWillpower { get; set; }
        public int MinimumAgility { get; set; }
        public int MaximumAgility { get; set; }
        public int MinimumHealth { get; set; }
        public int MaximumHealth { get; set; }
        public int MinimumCharm { get; set; }
        public int MaximumCharm { get; set; }
        public int HitpointModifierPerLevel { get; set; }
        public int ExperiencePercentage { get; set; }
        public Dictionary<AbilitiesAndModifiers, int> AbilitiesAndMods { get; set; }

        public new string ToString() {
            string recordStr = string.Empty;

            recordStr += string.Format("ID: {0}\t", ID);
            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("\tExperience: {0}\n", ExperiencePercentage);
            recordStr += string.Format("\tHitpoints Per Level: {0}\n", HitpointModifierPerLevel);
            recordStr += string.Format("\tStrength: {0} to {1}\n", MinimumStrength, MaximumStrength);
            recordStr += string.Format("\tIntellect: {0} to {1}\n", MinimumIntellect, MaximumIntellect);
            recordStr += string.Format("\tWillpower: {0} to {1}\n", MinimumWillpower, MaximumWillpower);
            recordStr += string.Format("\tAgility: {0} to {1}\n", MinimumAgility, MaximumAgility);
            recordStr += string.Format("\tHealth: {0} to {1}\n", MinimumHealth, MaximumHealth);
            recordStr += string.Format("\tCharm: {0} to {1}\n", MinimumCharm, MaximumCharm);

            foreach (var ability in AbilitiesAndMods) {
                recordStr += string.Format("\tAbility/Modifier: {0}:{1}\n", Enum.GetName(typeof(AbilitiesAndModifiers), ability.Key), ability.Value);
            }
            return recordStr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Records
{
    public class Race : IRecord
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
        public short MinimumStrength { get; set; }
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
        public Dictionary<AbilitiesAndModifiers, short> AbilitiesAndMods { get; set; }

        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"ID: {ID}\t");
            sb.Append($"Name: {Name}\n");
            sb.Append($"\tExperience: {ExperiencePercentage}\n");
            sb.Append($"\tHitpoints Per Level: {HitpointModifierPerLevel}\n");
            sb.Append($"\tStrength: {MinimumStrength} to {MaximumStrength}\n");
            sb.Append($"\tIntellect: {MinimumIntellect} to {MaximumIntellect}\n");
            sb.Append($"\tWillpower: {MinimumWillpower} to {MaximumWillpower}\n");
            sb.Append($"\tAgility: {MinimumAgility} to {MaximumAgility}\n");
            sb.Append($"\tHealth: {MinimumHealth} to {MaximumHealth}\n");
            sb.Append($"\tCharm: {MinimumCharm} to {MaximumCharm}\n");

            foreach (KeyValuePair<AbilitiesAndModifiers, short> ability in AbilitiesAndMods)
            {
                sb.Append($"\tAbility/Modifier: {Enum.GetName(typeof(AbilitiesAndModifiers), ability.Key)}:{ability.Value}\n");
            }

            return sb.ToString();
        }
    }
}

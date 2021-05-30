using System;
using System.Collections.Generic;
using System.Text;

namespace Records
{
    public class Spell : IRecord
    {
        #region Enums
        public enum SpellType
        {
            ANY = 0,
            PRIEST1 = 1,
            PRIEST2 = 2,
            PRIEST3 = 3,
            MAGE1 = 4,
            MAGE2 = 5,
            MAGE3 = 6,
            DRUID1 = 7,
            DRUID2 = 8,
            DRUID3 = 9,
            BARDIC = 10,
            MYSTIC = 11,
        }

        public enum SpellFlag
        {
            NONE = 0x0000,
            UNSURE = 0x0001,
            TIMED = 0x0002,
            EVIL = 0x0004,
            INSTANT = 0x0008,
            SELF = 0x0010,
            PLAYER = 0x0020,
            MONSTER = 0x0040,
            AREA = 0x0080,
            LEARNT = 0x1000,
        }

        // TODO:  Are there more CasTypes?
        public enum CastType
        {
            None = 0,
        }
        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Command { get; set; }
        public int Mana { get; set; }
        public int Level { get; set; }
        public SpellType Type { get; set; }
        public SpellFlag Flag { get; set; }
        public int LevelMultiplier { get; set; }
        public int EnergyUsed { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int Duration { get; set; }
        public int Chance { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MaximumLevel;                    // Max. level
        public int LevelDivider;                    // Level divider?
        public int UseLevel;                        // Use level range?
        public int IncEvery;                        // ?
        public CastType CastingType;                // Cast type
        public Item LearnedFromItem { get; set; }
        public Dictionary<Common.Abilities, int> Abilities = new Dictionary<Common.Abilities, int>();    // Max 10

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"ID: {ID}\t");
            sb.Append($"Code: {Code}\t");
            sb.Append($"Name: {Name}\n");
            sb.Append($"Command: {Command}\n");
            sb.Append($"Mana: {Mana}\t");
            sb.Append($"Level: {Level}\t");
            sb.Append($"Type: {Enum.GetName(typeof(SpellType), Type)}\t");
            sb.Append($"Flag: {Enum.GetName(typeof(SpellFlag), Flag)}\t");
            sb.Append($"LevelMultiplier: {LevelMultiplier}\n");
            sb.Append($"EnergyUsed: {EnergyUsed}\n");
            sb.Append($"MinimumDamage: {MinimumDamage}\n");
            sb.Append($"MaximumDamage: {MaximumDamage}\n");
            sb.Append($"Duration: {Duration}\n");
            sb.Append($"Chance: {Chance}\n");
            sb.Append($"AreaOfEffect: {AreaOfEffect}\n");
            sb.Append($"MaximumLevel: {MaximumLevel}\n");
            sb.Append($"LevelDivider: {LevelDivider}\n");
            sb.Append($"UseLevel: {UseLevel}\n");
            sb.Append($"IncEvery: {IncEvery}\n");
            sb.Append($"CastType: {Enum.GetName(typeof(CastType), CastingType)}\t");
            sb.Append($"LearnedFromItem: {LearnedFromItem}\n");

            foreach (KeyValuePair<Common.Abilities, int> ability in Abilities)
            {
                sb.Append($"\tAbility/Modifier: {ability.Key} {Enum.GetName(typeof(Common.Abilities), ability.Key)}:{ability.Value}\n");
            }

            return sb.ToString();
        }
    }
}

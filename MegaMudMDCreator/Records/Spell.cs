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

        public enum SpellClasses
        {
            Cold = 0,
            Hot = 1,
            Stone = 2,
            Lightning = 3,
            Normal = 4,
            Water = 5,
            Poison = 6,
        }

        [Flags]
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

        // TODO:  Are there more CastTypes?
        public enum CastType
        {
            PerRound,
            Immediate = 3,
        }

        public enum AreaOfEffectType
        {
            Unknown = 0,
            SelfOnly = 1,
            SelfOrPlayer = 2,
            // 3?
            MonsterOnly = 4,
            // 5?
            SelfOrMonster = 6,
            Anything = 7,
            PlayerOrMonster = 8,
            // 9?
            // 10?
            EntireRoom = 11,
            AllNotInParty = 12,
            EntireParty = 13,
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
        public AreaOfEffectType AreaOfEffect { get; set; }
        public int MaximumLevel { get; set; }
        public int LevelDivider { get; set; }
        public int UseLevel { get; set; }
        public int IncEvery { get; set; }
        public CastType CastingType { get; set; }
        public SpellClasses SpellClass { get; set; }
        public ushort LearnedFromItem { get; set; }
        public Dictionary<Common.Abilities, short> AbilitiesAndMods = new Dictionary<Common.Abilities, short>();
        public HashSet<ushort> RemovesSpell = new HashSet<ushort>();
        public HashSet<ushort> TerminatesSpell = new HashSet<ushort>();
        public HashSet<ushort> SummonsCreature = new HashSet<ushort>();
        public HashSet<ushort> TriggersTextblock = new HashSet<ushort>();
        public HashSet<ushort> DescriptionMessages = new HashSet<ushort>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"ID: {ID}\t");
            sb.Append($"Code: {Code}\t");
            sb.Append($"Name: {Name}\n");
            sb.Append($"Command: {Command}\n");
            sb.Append($"Mana: {Mana}\t");
            sb.Append($"Level: {Level}\t");
            sb.Append($"Type: {Enum.GetName(typeof(SpellType), Type)}\n");
            sb.Append($"Flag: {Flag}\n");
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
            sb.Append($"LearnedFromItem: #{LearnedFromItem}\n");

            if (RemovesSpell.Count > 0)
                sb.Append($"RemovesSpells: {string.Join(", ", RemovesSpell)}\n");

            if (TerminatesSpell.Count > 0)
                sb.Append($"TerminatesSpells: {string.Join(", ", TerminatesSpell)}\n");

            if (SummonsCreature.Count > 0)
                sb.Append($"SummonsCreatures: {string.Join(", ", SummonsCreature)}\n");

            if (TriggersTextblock.Count > 0)
                sb.Append($"TriggersTextblocks: {string.Join(", ", TriggersTextblock)}\n");
            
            if (DescriptionMessages.Count > 0)
                sb.Append($"DescriptionMessages: {string.Join(", ", DescriptionMessages)}\n");

            foreach (KeyValuePair<Common.Abilities, short> ability in AbilitiesAndMods)
                sb.Append($"Ability/Modifier: {Enum.GetName(typeof(Common.Abilities), ability.Key)}:{ability.Value}\n");

            return sb.ToString();
        }
    }
}

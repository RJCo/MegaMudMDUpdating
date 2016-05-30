using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    public class Spell : IMDFileRecord
    {

        #region Enums
        public enum SpellType {
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
            MYSTIC = 11
        }

        public enum SpellFlag {
            NONE    = 0x0000,
            UNSURE  = 0x0001,
            TIMED   = 0x0002,
            EVIL    = 0x0004,
            INSTANT = 0x0008,
            SELF    = 0x0010,
            PLAYER  = 0x0020,
            MONSTER = 0x0040,
            AREA    = 0x0080,
            LEARNT  = 0x1000,
        }

        public enum CastType {
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

        public int LevelMultiplier{ get; set; }
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


        public new string ToString() {

            string recordStr = string.Empty;

            recordStr += string.Format("ID: {0}\t", ID);
            recordStr += string.Format("Code: {0}\t", Code);
            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("Command: {0}\n", Command);
            recordStr += string.Format("Mana: {0}\t", Mana); 
            recordStr += string.Format("Level: {0}\t", Level);
            recordStr += string.Format("Type: {0}\t", Enum.GetName(typeof(SpellType), Type));
            recordStr += string.Format("Flag: {0}\t", Enum.GetName(typeof(SpellFlag), Flag));
            recordStr += string.Format("LevelMultiplier: {0}\n", LevelMultiplier);
            recordStr += string.Format("EnergyUsed: {0}\n", EnergyUsed);
            recordStr += string.Format("MinimumDamage: {0}\n", MinimumDamage);
            recordStr += string.Format("MaximumDamage: {0}\n", MaximumDamage);
            recordStr += string.Format("Duration: {0}\n", Duration);
            recordStr += string.Format("Chance: {0}\n", Chance);
            recordStr += string.Format("AreaOfEffect: {0}\n", AreaOfEffect);
            recordStr += string.Format("MaximumLevel: {0}\n", MaximumLevel);
            recordStr += string.Format("LevelDivider: {0}\n", LevelDivider);
            recordStr += string.Format("UseLevel: {0}\n", UseLevel);
            recordStr += string.Format("IncEvery: {0}\n", IncEvery);
            recordStr += string.Format("CastType: {0}\t", Enum.GetName(typeof(CastType), CastingType));
            recordStr += string.Format("LearnedFromItem: {0}\n", LearnedFromItem);

            foreach (var ability in Abilities) {
                recordStr += string.Format("\tAbility/Modifier: {0}:{1}\n", Enum.GetName(typeof(Common.Abilities), ability.Key), ability.Value);
            }

            return recordStr;
        }
    }
}

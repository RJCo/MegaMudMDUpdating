using Records;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MegaMudMDCreator
{
    public class SpellsCreator
    {
        public static int SpellIDOffset = 0;
        public static int SpellIDLength = sizeof(short);
        public static int SpellNameLength = 30 * sizeof(char);
        public static int AbbrevLength = 7 * sizeof(char);
        public static int FlagsLength = sizeof(int);
        public static int CommandLength = 41 * sizeof(char);
        public static int LevelLength = sizeof(char);
        public static int LevelMultiplierLength = sizeof(char);
        public static int ManaCostLength = sizeof(short);
        public static int EnergyCostLength = sizeof(short);
        public static int MinimumDamageLength = sizeof(short);
        public static int MaximumDamageLength = sizeof(short);
        public static int DurationInRoundsLength = sizeof(short);
        public static int SCModifierLength = sizeof(short);
        public static int IsAreaOfEffectLength = sizeof(char);
        public static int TypeLength = sizeof(char);
        public static int SpellClassLength = sizeof(char);

        public static int MaxAbilityCount = 10;
        public static int AbilityCodeLength = sizeof(short);
        public static int AbilityValueLength = sizeof(short);
        public static int MaximumLevelLength = sizeof(char);
        public static int LevelDividerLength = sizeof(char);
        public static int UseLevelRangeLength = sizeof(char);
        public static int IncEveryLength = sizeof(char);
        public static int CastTypeLength = sizeof(char);
        public static int ItemSpellLearnedFromLength = sizeof(short);

        private static void UpdateOffsetsAndLengths(int headerOffset)
        {
            throw new NotImplementedException();
        }

        public static List<Spell> GetAllRecords()
        {
            List<List<byte>> rawData = MDFileUtil.Reader.FileReader(MDFileUtil.Reader.SPELLS_FILE);
            int currentOffset = 0;
            var spells = new List<Spell>();

            foreach (List<byte> raw in rawData)
            {
                //Console.WriteLine("Length of raw: {0}", raw.Count);
                //string data = raw.Aggregate(string.Empty, (current, byt) => current + string.Format("{0:X2} ", byt));
                //Console.WriteLine("RawData: {0}", data);

                int ID = default;
                string Name = string.Empty;
                string Code = string.Empty;
                string Command = string.Empty;
                int Mana = default;
                int Level = default;
                var Type = Spell.SpellType.ANY;
                var Flag = Spell.SpellFlag.NONE;
                int LevelMultiplier = default;
                int EnergyUsed = default;
                int MinimumDamage = default;
                int MaximumDamage = default;
                int Duration = default;
                int Chance = default;
                bool AreaOfEffect = false;
                int MaximumLevel = default;
                int LevelDivider = default;
                int UseLevel = default;
                int IncEvery = default;
                var CastingType = Spell.CastType.None;
                Item LearnedFromItem = null;
                var Abilities = new Dictionary<Common.Abilities, int>();

                // Since headers on rows are variable length, we need to first get to a null and then 
                // find the index of the first bit of data past "0x80" and know that's where we start
                int firstNull = raw.IndexOf(0x00);
                int headerOffset = raw.IndexOf(0x80, firstNull) + 1;

                currentOffset += headerOffset;

                //UpdateOffsetsAndLengths(headerOffset);

                string data = raw.Aggregate(string.Empty, (current, byt) => current + string.Format("{0:X2} ", byt));
                //Console.WriteLine("SpellIDOffset: {0}, RawData: {1}", SpellIDOffset, data);
                //UpdateOffsetsAndLengths(-headerOffset);
                //continue;

                // SpellID (reverse order because it's stored Little Endian)
                currentOffset += SpellIDOffset;
                var id = new byte[] {
                    raw[currentOffset],
                    raw[currentOffset+1],
                };
                ID = BitConverter.ToInt16(id, 0);
                currentOffset += SpellIDLength;

                // Spell Name
                for (int i = currentOffset; (i < currentOffset + SpellNameLength) && (raw[i] != 0x00); i++)
                {
                    Name += (char)raw[i];
                }
                currentOffset += SpellNameLength;

                /*
                    AbbrevLength
                    FlagsLength
                    CommandLength
                    LevelLength
                    LevelMultiplierLength
                    ManaCostLength
                    EnergyCostLength
                    MinimumDamageLength
                    MaximumDamageLength
                    DurationInRoundsLength
                    SCModifierLength
                    IsAreaOfEffectLength
                    TypeLength
                    SpellClassLength

                    MaxAbilityCount

                    AbilityCodeLength
                    AbilityValueLength
                    MaximumLevelLength
                    LevelDividerLength
                    UseLevelRangeLength
                    IncEveryLength
                    CastTypeLength
                    ItemSpellLearnedFromLength
                 */

                var thisSpell = new Spell
                {
                    ID = ID,
                    Name = Name,
                    Code = Code,
                    Command = Command,
                    Mana = Mana,
                    Level = Level,
                    Type = Type,
                    Flag = Flag,
                    LevelMultiplier = LevelMultiplier,
                    EnergyUsed = EnergyUsed,
                    MinimumDamage = MinimumDamage,
                    MaximumDamage = MaximumDamage,
                    Duration = Duration,
                    Chance = Chance,
                    AreaOfEffect = AreaOfEffect,
                    MaximumLevel = MaximumLevel,
                    LevelDivider = LevelDivider,
                    UseLevel = UseLevel,
                    IncEvery = IncEvery,
                    CastingType = CastingType,
                    LearnedFromItem = LearnedFromItem,
                    Abilities = Abilities,
                };

                // ?? // UpdateOffsetsAndLengths(-headerOffset);
                spells.Add(thisSpell);
            }

            return spells;
        }
    }
}

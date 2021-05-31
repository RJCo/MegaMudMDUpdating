using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class SpellsMDReader<T> : MDReaderFactory<T>
        where T : Spell
    {
        public override List<T> GetAllRecords()
        {
            var spells = new List<T>();

            List<SpellMD> rawData = MDFileReader.FileReader<SpellMD>(MDFiles.SPELLS_FILE);
            if (rawData == null)
            {
                Console.WriteLine($"Unable to read file {MDFiles.SPELLS_FILE} - not parsing Spells");
                return spells;
            }

            foreach (SpellMD spell in rawData)
            {
                Spell newSpell = new Spell()
                {
                    ID = spell.SpellId,
                    Name = spell.SpellName,
                    Code = spell.Abbreviation,
                    Flag = (Spell.SpellFlag)spell.Flags,
                    Command = spell.Command,
                    Level = spell.Level,
                    LevelMultiplier = spell.LevelMultiplier,
                    Mana = spell.ManaCost,
                    EnergyUsed = spell.EnergyCost,
                    MinimumDamage = spell.MinimumDamage,
                    MaximumDamage = spell.MaximumDamage,
                    Duration = spell.DurationInRounds,
                    Chance = spell.SCModifier,
                    AreaOfEffect = spell.IsAreaOfEffect == 1,
                    Type = (Spell.SpellType)spell.Type,
                    CastingType = (Spell.CastType)spell.SpellClass,
                    //MaximumLevel;                    // Max. level
                    //LevelDivider;                    // Level divider?
                    //UseLevel;                        // Use level range?
                    //IncEvery;                        // ?
                    //LearnedFromItem
                    //Abilities = new Dictionary<Common.Abilities, int>();    // Max 10
                };

                spells.Add((T)newSpell);
            }

            return spells;
        }
    }
}

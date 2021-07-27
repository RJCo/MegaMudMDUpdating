using Records;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    LearnedFromItem = spell.LearnedFromItemId,
                    //MaximumLevel;                    // Max. level
                    //LevelDivider;                    // Level divider?
                    //UseLevel;                        // Use level range?
                    //IncEvery;                        // ?
                    //LearnedFromItem
                };

                // Abilities and Mods
                for (int i = 0; i < Common.MAX_NUMBER_OF_ABILITIES; i++)
                {
                    byte[] abilityBytes = spell.AbilityKeys.Skip(i * 2).Take(2).ToArray();
                    byte[] abilityValuesBytes = spell.AbilityValues.Skip(i * 2).Take(2).ToArray();

                    var abilityCode = BitConverter.ToUInt16(abilityBytes, 0);
                    var abilityValueCode = BitConverter.ToInt16(abilityValuesBytes, 0);

                    // If the ability is zero, the value is zero or garbage, so ignore it
                    if (abilityCode == 0)
                        continue;

                    var ability = (Common.Abilities)abilityCode;

                    if (newSpell.AbilitiesAndMods.ContainsKey(ability))
                    {
                        Console.WriteLine($"Spell {newSpell.Name} already has the ability {ability} with value {newSpell.AbilitiesAndMods[ability]}.  Skipping new value {abilityValueCode}");
                    }
                    else
                    {
                        newSpell.AbilitiesAndMods.Add((Common.Abilities)abilityCode, abilityValueCode);
                    }
                }


                //if (spell.UNKNOWN_BYTES.Any(x => x != 0))
                //{
                //    string hex = "";
                //    foreach (byte b in spell.UNKNOWN_BYTES)
                //        hex += string.Format("{0:X2} ", b);
                //    Console.WriteLine($"{spell.SpellName} - UNKNOWN_BYTES = {hex}");
                //}

                spells.Add((T)newSpell);
            }

            return spells;
        }
    }
}
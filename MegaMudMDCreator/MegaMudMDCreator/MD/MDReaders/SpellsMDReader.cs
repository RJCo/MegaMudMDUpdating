using Records;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaMudMDCreator
{
    public class SpellsMDReader : MDReaderFactory<Spell>
    {
        public override List<Spell> GetAllRecords()
        {
            var spells = new List<Spell>();

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
                    AreaOfEffect = (Spell.AreaOfEffectType)spell.AreaOfEffect,
                    Type = (Spell.SpellType)spell.Type,
                    SpellClass = (Spell.SpellClasses)spell.SpellClass,
                    LearnedFromItem = spell.LearnedFromItemId,
                    MaximumLevel = spell.MaximumLevel,
                    LevelDivider = spell.LevelDivider,
                    UseLevel = spell.UseLevel, // What is this actually used for?
                    IncEvery = spell.IncEvery, // What is this actually used for?
                    CastingType = spell.CastType == 0x03 ? Spell.CastType.Immediate : Spell.CastType.PerRound,
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

                    if (ability == Common.Abilities.RemoveSpell)
                    {
                        newSpell.RemovesSpell.Add((ushort)abilityValueCode);
                    }
                    else if (ability == Common.Abilities.TerminateSpell)
                    {
                        newSpell.TerminatesSpell.Add((ushort)abilityValueCode);
                    }
                    else if (ability == Common.Abilities.SummonCreature)
                    {
                        newSpell.SummonsCreature.Add((ushort)abilityValueCode);
                    }
                    else if (ability == Common.Abilities.TriggerTextblock)
                    {
                        newSpell.TriggersTextblock.Add((ushort)abilityValueCode);
                    }
                    else if (ability == Common.Abilities.DescriptionMessage)
                    {
                        newSpell.DescriptionMessages.Add((ushort)abilityValueCode);
                    }
                    else if (newSpell.AbilitiesAndMods.TryGetValue(ability, out short currentValue))
                    {
                        if (currentValue != abilityValueCode)
                        {
                            // Spell out archway temp already has the ability NightVision with value 1.  Skipping new value -1
                            Console.WriteLine($"Spell {newSpell.Name} already has the ability {ability} with value {newSpell.AbilitiesAndMods[ability]}.  Skipping new value {abilityValueCode}");
                        }
                    }
                    else
                    {
                        newSpell.AbilitiesAndMods.Add((Common.Abilities)abilityCode, abilityValueCode);
                    }
                }

                spells.Add(newSpell);
            }

            return spells;
        }
    }
}
using Records;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaMudMDCreator
{
    public class ItemsMDReader<T> : MDReaderFactory<T>
        where T : Item
    {
        public override List<T> GetAllRecords()
        {
            var items = new List<T>();

            List<ItemMD> rawData = MDFileReader.FileReader<ItemMD>(MDFiles.ITEMS_FILE);
            if (rawData == null)
            {
                Console.WriteLine($"Unable to read file {MDFiles.ITEMS_FILE} - not parsing Items");
                return items;
            }

            foreach (ItemMD item in rawData)
            {
                Item newItem = new Item
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Shop = item.BoughtAndSoldAt,
                    Path = item.IfNeededDoPath,
                    MinimumToKeep = item.MinimumToKeep,
                    MaximumToGet = item.MaximumToGet,
                    Type = (Item.ItemType)BitConverter.ToUInt16(item.ItemType, 0),
                    Weight = item.Weight,
                    Price = item.Cost,
                    MinimumStrengthToUse = item.RequiredStrength,
                    MinimumDamage = item.MinimumDamage,
                    MaximumDamage = item.MaximumDamage,
                    Accuracy = item.AccuracyModifier,
                    Speed = item.WeaponSpeed,
                    ArmorClass = item.AC,
                    DamageReduction = item.DR,
                };

                int flag = item.Flags[2] << 16 | item.Flags[1] << 8 | item.Flags[0];
                newItem.Flags = (Item.ItemFlags)flag;

                // Abilities and Mods
                for (int i = 0; i < Common.MAX_BYTES_FOR_ABILITIES / 2; i++)
                {
                    byte[] abilityBytes = item.AbilityKeys.Skip(i * 2).Take(2).ToArray();
                    byte[] abilityValuesBytes = item.AbilityValues.Skip(i * 2).Take(2).ToArray();

                    ushort abilityCode = BitConverter.ToUInt16(abilityBytes, 0);
                    short abilityValueCode = BitConverter.ToInt16(abilityValuesBytes, 0);

                    // If the ability is zero, the value is zero or garbage, so ignore it
                    if (abilityCode == 0)
                        continue;

                    var ability = (Common.Abilities)abilityCode;

                    // Handle special-case, multiple valued ability: NegateAbility
                    if (ability == Common.Abilities.NegateAbility) // TODO:  TerminateSpell
                    {
                        newItem.NegatesSpells.Add(abilityValueCode);
                    }
                    // Handle special-case, multiple valued ability: ClassItemInclusion
                    else if (ability == Common.Abilities.ClassItemInclusion)
                    {
                        newItem.Classes.Add(abilityValueCode);
                    }
                    // Handle special-case, multiple valued ability: ????
                    else if (false) // TODO:  Is there actually an ability for race allowance?
                    {
                        //<int> Races { get; set; }                // Allowed races, max 10
                    }
                    // Handle general case, testing for disallowed duplicates
                    else if (newItem.Abilities.ContainsKey(ability))
                    {
                        Console.WriteLine($"Item {newItem.ItemName} already has the ability {ability} with value {newItem.Abilities[ability]}.  Skipping new value {abilityValueCode}");
                    }
                    else
                    {
                        newItem.Abilities.Add(ability, abilityValueCode);
                    }
                }

                items.Add((T)newItem);
            }

            return items;
        }
    }
}

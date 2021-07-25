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
                    //Type = (Item.ItemType)BitConverter.ToUInt16(item.ItemType, 0),
                    Weight = item.Weight,
                    Price = item.Cost,
                    //Flags = (Item.ItemFlags)BitConverter.ToUInt32(item.Flags, 0),  // TODO: This feels wrong.
                    MinimumStrengthToUse = item.RequiredStrength,
                    MinimumDamage = item.MinimumDamage,
                    MaximumDamage = item.MaximumDamage,
                    Accuracy = item.AccuracyModifier,
                    Speed = item.WeaponSpeed,
                    ArmorClass = item.AC,
                    DamageReduction = item.DR,
                };

                //<Abilities, int> Abilities = new Dictionary<Abilities, int>(); // Max 10
                //<int> NegatesSpells = new List<int>();   // Max 5 spell IDs
                //<int> Classes { get; set; }              // Allowed classes, max 10
                //<int> Races { get; set; }                // Allowed races, max 10

                // Abilities and Mods
                for (int i = 0; i < 8; i++)
                {
                    byte[] abilityBytes = item.AbilityKeys.Skip(i * 2).Take(2).ToArray();
                    byte[] abilityValuesBytes = item.AbilityValues.Skip(i * 2).Take(2).ToArray();

                    Array.Reverse(abilityBytes);
                    Array.Reverse(abilityValuesBytes);

                    var abilityCode = BitConverter.ToUInt16(abilityBytes, 0);
                    var abilityValueCode = BitConverter.ToInt16(abilityValuesBytes, 0);

                    // If the ability is zero, the value is zero or garbage, so ignore it
                    if (abilityCode != 0)
                    { 
                        var ability = (Common.Abilities)abilityCode;
                        if (newItem.Abilities.ContainsKey(ability))
                        {
                            Console.WriteLine($"Item {newItem.ItemName} already has the ability {ability} with value {newItem.Abilities[ability]}.  Skipping new value {abilityValueCode}");
                        }
                        else
                        {
                            newItem.Abilities.Add(ability, abilityValueCode);
                        }
                    }
                }

                items.Add((T)newItem);
            }

            return items;
        }
    }
}

using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class ItemsMDReader<T> : MDReaderFactory<T>
        where T : Item
    {
        private static void AbilityHelper(byte[] abilityKey, byte[] abilityValue, Item newItem)
        {
            ushort abilityKeyUshort = BitConverter.ToUInt16(abilityKey, 0);
            if (abilityKeyUshort != 0)
            {
                Common.Abilities k = (Common.Abilities)abilityKeyUshort;
                short v = BitConverter.ToInt16(abilityValue, 0);
                Console.WriteLine($"Adding ability {k} = {v}");

                if (k == Common.Abilities.ClassItemInclusion)
                {
                    newItem.Classes.Add(v);
                    return;
                }

                if (newItem.Abilities.ContainsKey(k))
                {
                    Console.WriteLine($"DUPLICATE KVP: {k} {v}");
                    Console.ReadLine();
                    return;
                }
                newItem.Abilities.Add(k, v);

            }
        }

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

                Console.WriteLine($"Item={item.ItemName}");

                AbilityHelper(item.Ability1Key, item.Ability1Value, newItem);
                AbilityHelper(item.Ability2Key, item.Ability2Value, newItem);
                AbilityHelper(item.Ability3Key, item.Ability3Value, newItem);
                AbilityHelper(item.Ability4Key, item.Ability4Value, newItem);
                AbilityHelper(item.Ability5Key, item.Ability5Value, newItem);
                AbilityHelper(item.Ability6Key, item.Ability6Value, newItem);
                AbilityHelper(item.Ability7Key, item.Ability7Value, newItem);
                AbilityHelper(item.Ability8Key, item.Ability8Value, newItem);
                AbilityHelper(item.Ability9Key, item.Ability9Value, newItem);
                AbilityHelper(item.Ability10Key, item.Ability10Value, newItem);

                items.Add((T)newItem);
            }

            return items;
        }
    }
}

using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class ItemsMDReader<T> : MDReaderFactory<T>
        where T : Item
    {
        private static void AbilityHelper(byte[] abilityKey, byte[] abilityValue, Dictionary<Common.Abilities, short> abilities)
        {
            ushort abilityKeyUshort = BitConverter.ToUInt16(abilityKey, 0);
            if (abilityKeyUshort != 0)
            {
                var k = (Common.Abilities)abilityKeyUshort;
                var v = BitConverter.ToInt16(abilityValue, 0);
                Console.WriteLine($"Adding ability {k} = {v}");
                if (abilities.ContainsKey(k))
                {
                    Console.WriteLine($"DUPLICATE KVP: {k} {v}");
                    return;
                }
                abilities.Add(k, v);

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

                //Array.Reverse(item.Ability1Key);
                //Array.Reverse(item.Ability2Key);
                //Array.Reverse(item.Ability3Key);
                //Array.Reverse(item.Ability4Key);
                //Array.Reverse(item.Ability5Key);
                //Array.Reverse(item.Ability6Key);
                //Array.Reverse(item.Ability7Key);
                //Array.Reverse(item.Ability8Key);
                //Array.Reverse(item.Ability9Key);
                //Array.Reverse(item.Ability10Key);

                //Array.Reverse(item.Ability1Value);
                //Array.Reverse(item.Ability2Value);
                //Array.Reverse(item.Ability3Value);
                //Array.Reverse(item.Ability4Value);
                //Array.Reverse(item.Ability5Value);
                //Array.Reverse(item.Ability6Value);
                //Array.Reverse(item.Ability7Value);
                //Array.Reverse(item.Ability8Value);
                //Array.Reverse(item.Ability9Value);
                //Array.Reverse(item.Ability10Value);

                Console.WriteLine($"Item={item.ItemName}");

                AbilityHelper(item.Ability1Key, item.Ability1Value, newItem.Abilities);
                AbilityHelper(item.Ability2Key, item.Ability2Value, newItem.Abilities);
                AbilityHelper(item.Ability3Key, item.Ability3Value, newItem.Abilities);
                AbilityHelper(item.Ability4Key, item.Ability4Value, newItem.Abilities);
                AbilityHelper(item.Ability5Key, item.Ability5Value, newItem.Abilities);
                AbilityHelper(item.Ability6Key, item.Ability6Value, newItem.Abilities);
                AbilityHelper(item.Ability7Key, item.Ability7Value, newItem.Abilities);
                AbilityHelper(item.Ability8Key, item.Ability8Value, newItem.Abilities);
                AbilityHelper(item.Ability9Key, item.Ability9Value, newItem.Abilities);
                AbilityHelper(item.Ability10Key, item.Ability10Value, newItem.Abilities);

                //ushort ability1Key = BitConverter.ToUInt16(item.Ability1Key, 0);
                //if (ability1Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability1Key, BitConverter.ToInt16(item.Ability1Value, 0));

                //ushort ability2Key = BitConverter.ToUInt16(item.Ability2Key, 0);
                //if (ability2Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability2Key, BitConverter.ToInt16(item.Ability2Value, 0));

                //ushort ability3Key = BitConverter.ToUInt16(item.Ability3Key, 0);
                //if (ability3Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability3Key, BitConverter.ToInt16(item.Ability3Value, 0));

                //ushort ability4Key = BitConverter.ToUInt16(item.Ability4Key, 0);
                //if (ability4Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability4Key, BitConverter.ToInt16(item.Ability4Value, 0));

                //ushort ability5Key = BitConverter.ToUInt16(item.Ability5Key, 0);
                //if (ability5Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability5Key, BitConverter.ToInt16(item.Ability5Value, 0));

                //ushort ability6Key = BitConverter.ToUInt16(item.Ability6Key, 0);
                //if (ability6Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability6Key, BitConverter.ToInt16(item.Ability6Value, 0));

                //ushort ability7Key = BitConverter.ToUInt16(item.Ability7Key, 0);
                //if (ability7Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability7Key, BitConverter.ToInt16(item.Ability7Value, 0));

                //ushort ability8Key = BitConverter.ToUInt16(item.Ability8Key, 0);
                //if (ability8Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability8Key, BitConverter.ToInt16(item.Ability8Value, 0));

                //ushort ability9Key = BitConverter.ToUInt16(item.Ability9Key, 0);
                //if (ability9Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability9Key, BitConverter.ToInt16(item.Ability9Value, 0));

                //ushort ability10Key = BitConverter.ToUInt16(item.Ability10Key, 0);
                //if (ability10Key != 0)
                //    newItem.Abilities.Add((Common.Abilities)ability10Key, BitConverter.ToInt16(item.Ability10Value, 0));

                items.Add((T)newItem);
            }

            return items;
        }
    }
}

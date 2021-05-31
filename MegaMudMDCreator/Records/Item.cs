using System;
using System.Collections.Generic;
using System.Text;

namespace Records
{
    public class Item : IRecord
    {
        #region Enums
        public enum ItemType
        {
            Clothing = 0,
            Weapon = 1,
            Projectile = 2,
            Furniture = 3,
            Food = 4,
            Drink = 5,
            Light = 6,
            Key = 7,
            Container = 8,
            Scroll = 9,
            Special = 10,
        }

        public enum ItemEquippableSlot
        {
            Unknown = 0,
            None = 1,
            Weapon = 2,
            Offhand = 3,
            Head = 4,
            Hands = 5,
            Finger = 6,
            Feet = 7,
            Arms = 8,
            Back = 9,
            Neck = 10,
            Legs = 11,
            Waist = 12,
            Torso = 13,
            Wrist = 14,
            Ears = 15,
        }

        public enum ItemEquippedOn
        {
            None = 0,
            Unknown = 1,
            Head = 2,
            Hands = 3,
            Finger = 4,
            Finger2 = 13,
            Feet = 5,
            Arms = 6,
            Back = 7,
            Neck = 8,
            Legs = 9,
            Waist = 10,
            Torso = 11,
            Offhand = 12,
            Wrist = 14,
            Wrist2 = 17,
            Ears = 15,
            Worn = 16,
            Face = 18,
            Eyes = 19,
        }

        public enum ItemWeaponType
        {
            OneHandedBlunt = 0,
            TwoHandedBlunt = 1,
            OneHandedSharp = 2,
            TwoHandedSharp = 3,
        }

        public enum ItemArmorType
        {
            None = 0,
            Natural = 1,
            Robes = 2,
            Padded = 3,
            SoftLeather = 4,
            StuddedLeather = 5,
            RigidLeather = 6,
            Chainmail = 7,
            Scalemail = 8,
            Platemail = 9,
        }

        public enum ItemFlags
        {
            None = 0x00000000,
            Unknown = 0x00000001,
            AutoGet = 0x00000002,
            AutoBuy = 0x00000004,
            AutoSell = 0x00000008,
            AutoEquip = 0x00000010,
            AutoFind = 0x00000020,
            CantBeTaken = 0x00000040,
            CanUseToBackstab = 0x00000200,
            MinToKeep = 0x00000400,
            AutoDrop = 0x00000800,
            AutoOpen = 0x00001000,
            IsAWeapon = 0x00010000,
            IsLoyal = 0x00020000,
            MustGet = 0x00100000,
            TriedGet = 0x00200000,
            NoStock = 0x00400000,
            Cash = 0x00800000,
        }
        #endregion

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public ItemType Type { get; set; }
        public ItemEquippableSlot Slot { get; set; }
        public ItemEquippedOn CurrentEquippedOn { get; set; }
        public int MinimumToKeep { get; set; }
        public int MaximumToGet { get; set; }
        public long Price { get; set; }
        public int MaximumInGame { get; set; }
        public string Shop { get; set; }
        public string Path { get; set; }
        public int Weight { get; set; }
        public ItemFlags Flags { get; set; }
        public int MaximumUses { get; set; }
        public int MinimumStrengthToUse { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int Accuracy { get; set; }
        public int Speed { get; set; }
        public int ArmorClass { get; set; }
        public int DamageReduction { get; set; }
        public Dictionary<Common.Abilities, short> Abilities = new Dictionary<Common.Abilities, short>(); // Max 10
        public int WeaponNumberOfHandsNeeded { get; set; }
        public int Material { get; set; }                   // TODO:  What is this?  WeaponType and ArmorType?
        public int Body { get; set; }
        public List<int> NegatesSpells = new List<int>();   // Max 5 spell IDs
        public List<int> Classes { get; set; } = new List<int>();   // Allowed classes, max 10
        public List<int> Races { get; set; } = new List<int>();     // Allowed races, max 10
        public int DroppedBy { get; set; }
        public int FromItem { get; set; }
        public int BasePrice { get; set; }


        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {ItemId}\n");
            sb.Append($"Name: {ItemName}\n");
            sb.Append($"Type: {Type}\n");
            sb.Append($"Slot: {Slot}\n");
            sb.Append($"CurrentEquippedOn: {CurrentEquippedOn}\n");
            sb.Append($"MinimumToKeep: {MinimumToKeep}\n");
            sb.Append($"MaximumToGet: {MaximumToGet}\n");
            sb.Append($"Price: {Price}\n");
            sb.Append($"MaximumInGame: {MaximumInGame}\n");
            sb.Append($"Shop: {Shop}\n");
            sb.Append($"Path: {Path}\n");
            sb.Append($"Weight: {Weight}\n");
            sb.Append($"Flags: {Flags}\n");
            sb.Append($"MaximumUses: {MaximumUses}\n");
            sb.Append($"MinimumStrengthToUse: {MinimumStrengthToUse}\n");
            sb.Append($"MinimumDamage: {MinimumDamage}\n");
            sb.Append($"MaximumDamage: {MaximumDamage}\n");
            sb.Append($"Accuracy: {Accuracy}\n");
            sb.Append($"Speed: {Speed}\n");
            sb.Append($"ArmorClass: {ArmorClass}\n");
            sb.Append($"DamageReduction: {DamageReduction}\n");
            sb.Append($"WeaponNumberOfHandsNeeded: {WeaponNumberOfHandsNeeded}\n");
            sb.Append($"Material: {Material}\n");
            sb.Append($"Body: {Body}\n");
            sb.Append($"DroppedBy: {DroppedBy}\n");
            sb.Append($"FromItem: {FromItem}\n");
            sb.Append($"BasePrice: {BasePrice}\n");

            sb.Append($"NegatesSpells: {string.Join(", ", NegatesSpells)}");
            sb.Append($"Classes: {string.Join(", ", Classes)}");
            sb.Append($"Races: {string.Join(", ", Races)}");

            foreach (KeyValuePair<Common.Abilities, short> ability in Abilities)
            {
                sb.Append($"Ability/Modifier: {Enum.GetName(typeof(Common.Abilities), ability.Key)}:{ability.Value}\n");
            }

            return sb.ToString();
        }
    }
}

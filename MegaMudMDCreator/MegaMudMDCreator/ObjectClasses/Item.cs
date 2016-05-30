using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    public class Item : IMDFileRecord
    {
        #region Enums
        public enum ItemType {
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

        public enum ItemEquippableSlot {
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

        public enum ItemEquippedOn {
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
            Legs =9,
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

        public enum ItemWeaponType {
            OneHandedBlunt = 0,
            TwoHandedBlunt = 1,
            OneHandedSharp = 2,
            TwoHandedSharp = 3,
        }

        public enum ItemArmorType {
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

        public enum ItemFlags {
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

        public int ID { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public ItemEquippableSlot Slot { get; set; }
        public ItemEquippedOn CurrentEquippedOn { get; set; }
        public int MinimumToKeep { get; set; }
        public int MaximumToGet { get; set; }
        public long Price { get; set; }
        public long Value { get; set; }
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
        public Dictionary<Common.Abilities, int> Abilities = new Dictionary<Common.Abilities, int>(); // Max 10
        public int WeaponNumberOfHandsNeeded { get; set; }
        public int Material { get; set; }                   // TODO:  What is this?  WeaponType and ArmorType?
        public int Body { get; set; }
        public List<int> NegatesSpells = new List<int>();   // Max 5 spell IDs
        public List<int> Classes { get; set; }              // Allowed classes, max 10
        public List<int> Races { get; set; }                // Allowed races, max 10
        public int DroppedBy { get; set; }
        public int FromItem { get; set; }
        public int BasePrice { get; set; }
        

        public new string ToString() {
            throw new NotImplementedException();

            /*
            string recordStr = string.Empty;

            recordStr += string.Format("ID: {0}\t", ID);
            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("Experience: {0}\n", ExperiencePercentage);
            recordStr += string.Format("Weapon Type: {0}\n", Enum.GetName(typeof(WeaponClasses), WeaponType));

            foreach (var ability in AbilitiesAndMods) {
                recordStr += string.Format("Ability/Modifier: {0}:{1}\n", Enum.GetName(typeof(AbilitiesAndModifiers), ability.Key), ability.Value);
            }
            return recordStr;
            */
        }
    }
}

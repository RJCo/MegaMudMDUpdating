using System;
using System.Collections.Generic;
using System.Text;

namespace MegaMudMDCreator
{
    public class Class : IMDFileRecord
    {
        #region Enums
        public enum WeaponClasses
        {
            Unknown = 0x00,
            AllWeapons = 0x08,
            OneHanded = 0x04,
            Staff = 0x09,
            BluntOnly = 0x07,
        }

        public enum ArmorClasses
        {
            Platemail = 0x09,
            Scalemail = 0x08,
            Chainmail = 0x07,
            Leather = 0x06,
            Ninja = 0x02,
            Silk = 0x01,
            Unknown = 0x00,
        }

        public enum MagicTypes
        {
            None = 0x00,
            Mage = 0x01,
            Priest = 0x02,
            Druid = 0x03,
            Bard = 0x04,
            Kai = 0x05,
        }


        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
        public int ExperiencePercentage { get; set; }
        public int Combat { get; set; }
        public int HitpointPerLevelMinimum { get; set; }
        public int HitpointPerLevelMaximum { get; set; }
        public WeaponClasses WeaponType { get; set; }
        public ArmorClasses ArmorType { get; set; }
        public int MagicLevel { get; set; }
        public MagicTypes MagicType { get; set; }
        public Dictionary<Common.Abilities, int> AbilitiesAndMods { get; set; }

        public new string ToString()
        {
            string classStr = string.Empty;

            classStr += string.Format("ID: {0}\t", ID);
            classStr += string.Format("Name: {0}\n", Name);
            classStr += string.Format("Experience: {0}\n", ExperiencePercentage);
            classStr += string.Format("Combat: {0}\n", Combat);
            classStr += string.Format("HP Per Level (min): {0}\t", HitpointPerLevelMinimum);
            classStr += string.Format("HP Per Level (max): {0}\n", HitpointPerLevelMaximum);
            classStr += string.Format("Weapon Type: {0}\t", Enum.GetName(typeof(WeaponClasses), WeaponType));
            classStr += string.Format("Armor Type: {0}\n", Enum.GetName(typeof(ArmorClasses), ArmorType));
            classStr += string.Format("Magic Type: {0}\t", Enum.GetName(typeof(MagicTypes), MagicType));
            classStr += string.Format("Magic Level: {0}\n", MagicLevel);

            foreach (var ability in AbilitiesAndMods)
            {
                classStr += string.Format("Ability/Modifier: {0}:{1}\n", Enum.GetName(typeof(Common.Abilities), ability.Key), ability.Value);
            }

            return classStr;
        }

        private const ushort _recordLengthWithoutID = 88;  // 0x58
        public byte[] Serialize()
        {
            ushort myLength = (ushort)(_recordLengthWithoutID + Convert.ToUInt16(ID.ToString().Length));
            byte[] record = new byte[myLength];
            /* 
             e.g. Warrior:
                59 01 31 00 00 00 00 00 80 01 00 57 61 72 72 69 
                6F 72 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
                00 00 00 00 00 00 00 00 00 64 00 06 06 0A 08 09 
                00 00 1F 00 00 00 00 00 00 00 00 00 00 00 00 00 
                00 00 00 00 00 00 00 00 9D FF 9D FF 9D FF 9D FF 
                9D FF 00 00 00 00 00 00 00 20
            */

            int i = 0;
            record[i++] = ushortToByte(myLength);
            record[i++] = 0x01;

            foreach (byte x in Encoding.ASCII.GetBytes(ID.ToString()))
            {
                record[i++] = x;
            }

            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x80;

            byte[] idAsBytes = ushortToByteArray((ushort)ID);
            record[i++] = idAsBytes[0];
            record[i++] = idAsBytes[1];

            foreach (byte x in Encoding.ASCII.GetBytes(Name))
            {
                record[i++] = x;
            }

            for (int j = 0; j < Common.CLASS_NAME_LEN /*30*/ - Name.Length; j++)
            {
                record[i++] = 0x00;
            }

            byte[] exp = ushortToByteArray((ushort)ExperiencePercentage);
            record[i++] = exp[0];
            record[i++] = exp[1];

            record[i++] = intToByte(Combat);
            record[i++] = intToByte(HitpointPerLevelMinimum);
            record[i++] = intToByte(HitpointPerLevelMaximum);
            record[i++] = (byte)WeaponType;
            record[i++] = (byte)ArmorType;
            record[i++] = (byte)MagicLevel;
            record[i++] = (byte)MagicType;

            int abilitiesStartIndex = i;
            // Initialize the abilities & mods section with 0x00; to the end of the record
            for (int j = abilitiesStartIndex; j < record.Length; j++)
            {
                record[j] = 0x00;
            }

            foreach (var kvp in AbilitiesAndMods)
            {
                byte[] abilityCode = ushortToByteArray((ushort)kvp.Key);
                byte[] abilityValue = ushortToByteArray((ushort)kvp.Value);

                // NOTE:  20 is  the offset between the abilities list and their values
                record[i] = abilityCode[0];
                record[i + 20] = abilityValue[0];
                i++;

                record[i] = abilityCode[1];
                record[i + 20] = abilityValue[1];
                i++;
            }

            record[record.Length - 1] = 0x20;
            return record;
        }

        private byte intToByte(int intValue)
        {
            return ushortToByte((ushort)intValue);
        }

        private byte ushortToByte(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result[0];
        }

        private byte[] ushortToByteArray(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result;
        }

        private byte[] intToByteArray(int intValue)
        {
            byte[] intBytes = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;
            return result;
        }
    }
}

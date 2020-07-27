using Records;
using System;
using System.Collections.Generic;
using System.Text;


namespace MegaMudMDCreator
{
    public class ClassesMDWriter<T> : MDWriterFactory<T>
        where T : Class
    {
        private const ushort _recordLengthWithoutID = 88;  // 0x58

        public override byte[] Serialize(T rec)
        {
            Class classToWrite = rec;
            if (rec == null)
                throw new Exception($"Got a record that isn't a Class.  Type is {rec.GetType()}");

            ushort _recordLength = (ushort)(_recordLengthWithoutID + Convert.ToUInt16(classToWrite.ID.ToString().Length));
            byte[] record = new byte[_recordLength];
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
            record[i++] = UshortToByte(_recordLength);
            record[i++] = 0x01;

            foreach (byte x in Encoding.ASCII.GetBytes(classToWrite.ID.ToString()))
            {
                record[i++] = x;
            }

            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x00;
            record[i++] = 0x80;

            byte[] idAsBytes = UshortToByteArray((ushort)classToWrite.ID);
            record[i++] = idAsBytes[0];
            record[i++] = idAsBytes[1];

            foreach (byte x in Encoding.ASCII.GetBytes(classToWrite.Name))
            {
                record[i++] = x;
            }

            for (int j = 0; j < Common.CLASS_NAME_LEN /*30*/ - classToWrite.Name.Length; j++)
            {
                record[i++] = 0x00;
            }

            byte[] exp = UshortToByteArray((ushort)classToWrite.ExperiencePercentage);
            record[i++] = exp[0];
            record[i++] = exp[1];

            record[i++] = IntToByte(classToWrite.Combat);
            record[i++] = IntToByte(classToWrite.HitpointPerLevelMinimum);
            record[i++] = IntToByte(classToWrite.HitpointPerLevelMaximum);
            record[i++] = (byte)classToWrite.WeaponType;
            record[i++] = (byte)classToWrite.ArmorType;
            record[i++] = (byte)classToWrite.MagicLevel;
            record[i++] = (byte)classToWrite.MagicType;

            int abilitiesStartIndex = i;
            // Initialize the abilities & mods section with 0x00; to the end of the record
            for (int j = abilitiesStartIndex; j < record.Length; j++)
            {
                record[j] = 0x00;
            }

            foreach (KeyValuePair<Common.Abilities, int> kvp in classToWrite.AbilitiesAndMods)
            {
                byte[] abilityCode = UshortToByteArray((ushort)kvp.Key);
                byte[] abilityValue = UshortToByteArray((ushort)kvp.Value);

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
    }
}

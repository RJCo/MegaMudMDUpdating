using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public abstract class MDWriterFactory<T> : IWriterFactory<T> 
        where T : class
    {
        public abstract List<byte[]> GetListOfRecordBytes();
        public abstract void WriteFile();

        public static byte[] CombineArrays(byte[] a1, byte[] a2)
        {
            byte[] newArray = new byte[a1.Length + a2.Length];
            Array.Copy(a1, newArray, a1.Length);
            Array.Copy(a2, 0, newArray, a1.Length, a2.Length);
            return newArray;
        }

        // TODO:  This seems wrong?
        internal static byte IntToByte(int intValue)
        {
            return UshortToByte((ushort)intValue);
        }

        internal static byte UshortToByte(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result[0];
        }

        internal static byte[] UshortToByteArray(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result;
        }

        internal static byte[] IntToByteArray(int intValue)
        {
            byte[] intBytes = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;
            return result;
        }
    }
}

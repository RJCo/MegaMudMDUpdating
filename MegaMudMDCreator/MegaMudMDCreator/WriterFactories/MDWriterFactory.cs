using Records;
using System;

namespace MegaMudMDCreator
{
    public abstract class MDWriterFactory<T> : IWriterFactory<T>
    {
        public abstract byte[] Serialize(T record);

        internal byte IntToByte(int intValue)
        {
            return UshortToByte((ushort)intValue);
        }

        internal byte UshortToByte(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result[0];
        }

        internal byte[] UshortToByteArray(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result;
        }

        internal byte[] IntToByteArray(int intValue)
        {
            byte[] intBytes = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;
            return result;
        }
    }
}

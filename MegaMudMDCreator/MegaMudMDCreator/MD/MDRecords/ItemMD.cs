using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    // TODO:  ItemMD fields and update Size in StructLayout
    [StructLayout(LayoutKind.Sequential, Size = 162, Pack = 1)]
    public struct ItemMD
    {
        // Offset: 0x00
        public byte UnusedByte;

        // Offset: 0x01
        public ushort ItemId;

        // Offset: 0x03
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string ItemName;

        // Offset: 0x21
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BoughtAndSoldAt;

        // Offset: 0x49
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string IfNeededDoPath;

        // Offset: 0x56    00 00 ??????????????????????
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] UNKNOWN_BYTES_1;

        // Offset: 0x58
        public ushort MinimumToKeep;

        // Offset: 0x5a
        public ushort MaximumToGet;

        // Offset: 0x5c
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] ItemType;

        // Offset: 0x5e
        public ushort Weight;

        // Offset: 0x60
        public uint Cost;

        // Offset: 0x64
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Flags;

        // Offset: 0x67    00 01 00 FF FF ??????????????????????
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] UNKNOWN_BYTES_2;

        // Offset: 0x6C    3C 00 required strength
        public ushort RequiredStrength;

        // Offset: 0x6E    08 00 minimum damage
        public ushort MinimumDamage;

        // Offset: 0x70    15 00 maximum damage
        public ushort MaximumDamage;

        // Offset: 0x72    05 00 accuracy bonus?
        public short AccuracyModifier;

        // Offset: 0x74    06 00 weapon speed?
        public ushort WeaponSpeed;

        // Offset = 0x76    14 00 ac bonus 10x?
        public short AC; // Note: 12 == 120

        // Offset = 0x78    00 00 dr bonus 10x?
        public short DR; // Note: 1.5 == 15

        // Offset - 0x7A
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability1Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability2Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability3Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability4Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability5Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability6Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability7Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability8Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability9Key;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability10Key;

        // Offset - 0x8E
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability1Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability2Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability3Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability4Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability5Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability6Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability7Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability8Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability9Value;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Ability10Value;

    }
}

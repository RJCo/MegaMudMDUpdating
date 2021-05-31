using System.Runtime.InteropServices;


namespace MegaMudMDCreator
{
    // TODO:  MonsterMD fields and update Size in StructLayout
    [StructLayout(LayoutKind.Sequential, Size = 162, Pack = 1)]
    public struct MonsterMD
    {
        // Offset: 0x00
        public byte UnusedByte;

        // Offset: 0x01
        public ushort MonsterId;

        // Offset: 0x03
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string MonsterName;

        // Offset: 0x1F
        public byte AttackPriority;

        // Offset: 0x20
        public byte AttackModifiers;

        // Offset: 0x21
        public byte UNKNOWN_BYTE_1;

        // Offset: 0x22
        public byte UNKNOWN_BYTE_2;

        // Offset: 0x23
        public byte FearLevel;

        // Offset: 0x24
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string PreattackSpellCode;

        // Offset: 0x29
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string AttackSpellCode;

        // Offset: 0x2A
        public byte SexFlag;

        // Offset: 0x2B 
        public ushort MonsterLevel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] UNKNOWN_BYTES_2;

        public ushort Hitpoints;

        public ushort Energy;

        public short MagicResistance;

        public short Accuracy;

        public short ArmorClass;

        public short DamageReduction;

        public short EnslaveLevel;

        // TODO:  Location?

    }
}

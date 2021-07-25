using System.Runtime.InteropServices;


namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MonsterMD
    {
        public ushort MonsterId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string MonsterName;

        public byte AttackPriority;

        public byte AttackModifiers;

        public byte UNKNOWN_BYTE_1;

        public byte UNKNOWN_BYTE_2;

        public byte FearLevel;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string PreattackSpellCode;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string AttackSpellCode;

        public byte SexFlag;

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

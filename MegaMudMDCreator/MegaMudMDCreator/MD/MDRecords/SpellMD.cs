using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpellMD
    {
        // 01 00
        public short SpellId;

        // 6D 61 67 69 63 20 6D 69 73 73 69 6C 65 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string SpellName;

        // 6D 6D 69 73 00 00 00 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Abbreviation;

        // 64 00 
        public ushort Flags;

        // Offset: 41
        // 00 40
        public ushort UNKNOWN;  // Always 0x0000 or 0x4000 (or possibly 0x0040)

        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Command;

        // 01
        public byte Level;

        // 01
        public byte LevelMultiplier;

        public short ManaCost; // 01 00 
        public short EnergyCost; // E8 03 
        public short MinimumDamage; // 04 00
        public short MaximumDamage; // 0C 00
        public short DurationInRounds; // 00 00
        public short SCModifier; // 0F 00

        public byte IsAreaOfEffect; // 08
        public byte Type; // 04
        public byte SpellClass; // 04

        // offset 101 -> 0x65
        // 11 00 13 00 14 00 15 00 16 00 17 00 18 00 19 00 1A 00 1B 00 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityKeys;

        // offset 121
        //public ushort UNKNOWN2;

        // offset 121 -> 123 if above is uncommented
        // 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0A 00
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityValues;

        // 0B 00 0C 00 00 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] // 3
        public byte[] UNKNOWN_BYTES;

        // offset 146
        // 77 00
        public ushort LearnedFromItemId;

        // offset 148
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] UNKNOWN_BYTES_2; // Appears to always be zeros
    }
}

using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpellMD
    {
        public short SpellId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string SpellName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Abbreviation;

        public ushort Flags;

        public ushort UnusedFlagsHighBits; // 0x4000 = Changed, 0x8000 = Deleted

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Command;

        public byte Level;
        public byte LevelMultiplier; // e.g. in "12 to (30 + 1 * level / 5)", LevelMultiplier = 1

        public short ManaCost;
        public short EnergyCost;
        public short MinimumDamage;
        public short MaximumDamage;
        public short DurationInRounds;
        public short SCModifier;

        public byte AreaOfEffect;
        public byte Type;
        public byte SpellClass;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityKeys;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityValues;

        public byte MaximumLevel;
        public byte LevelDivider; // e.g. in "12 to (30 + 1 * level / 5)", LevelDivider = 5
        public byte UseLevel;
        public byte IncEvery;
        public byte CastType;
        public ushort LearnedFromItemId;

        // offset 148
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] UNKNOWN_BYTES_2; // Appears to always be zeros
    }
}

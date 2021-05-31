using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    // TODO:  SpellMD fields and update Size in StructLayout
    [StructLayout(LayoutKind.Sequential, Size = 0, Pack = 1)]
    public struct SpellMD
    {
        public byte UnusedByte;

        public short SpellId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string SpellName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Abbreviation;

        public int Flags;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Command;

        public byte Level;

        public byte LevelMultiplier;

        public short ManaCost;
        public short EnergyCost;
        public short MinimumDamage;
        public short MaximumDamage;
        public short DurationInRounds;
        public short SCModifier;

        public byte IsAreaOfEffect;
        public byte Type;
        public byte SpellClass;
    }
}

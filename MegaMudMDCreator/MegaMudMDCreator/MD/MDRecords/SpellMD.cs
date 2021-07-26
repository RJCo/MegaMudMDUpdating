﻿using System.Runtime.InteropServices;

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
        
        public ushort UNKNOWN;  // Always 0x0000 or 0x4000 (or possibly 0x0040)

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

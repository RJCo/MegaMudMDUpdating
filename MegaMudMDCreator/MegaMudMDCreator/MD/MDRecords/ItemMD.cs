using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ItemMD
    {
        public ushort ItemId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string ItemName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BoughtAndSoldAt;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string IfNeededDoPath;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] UNKNOWN_BYTES_1;

        public ushort MinimumToKeep;

        public ushort MaximumToGet;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] ItemType;

        public ushort Weight;

        public uint Cost;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Flags;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] UNKNOWN_BYTES_2;

        public ushort RequiredStrength;

        public ushort MinimumDamage;

        public ushort MaximumDamage;

        public short AccuracyModifier;

        public ushort WeaponSpeed;

        public short AC; // Note: 12 == 120

        public short DR; // Note: 1.5 == 15

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityKeys;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityValues;
    }
}

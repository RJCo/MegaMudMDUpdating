using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Size = 81, Pack = 1)]
    public struct ClassMD
    {
        public byte UnusedByte1;
        public ushort ClassId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string ClassName;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] ExperienceBase;

        public byte CombatLevel;
        public byte MinHPPerLevel;
        public byte MaxHPPerLevel;
        public byte WeaponsUsable;
        public byte ArmorUseable;
        public byte MagicLevel;

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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] UnusedByteArray;

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

        public byte EndChar;
    }
}

using System.Runtime.InteropServices;


namespace MegaMudMDCreator
{
    // TODO:  RaceMD fields and update Size in StructLayout
    [StructLayout(LayoutKind.Sequential, Size = 0, Pack = 1)]
    public struct RaceMD
    {
        public byte UnusedByte;

        public ushort RaceId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string RaceName;

        public byte MinimumStrength;
        public byte MaximumStrength;
        public byte MinimumIntellect;
        public byte MaximumIntellect;
        public byte MinimumWillpower;
        public byte MaximumWillpower;
        public byte MinimumAgility;
        public byte MaximumAgility;
        public byte MinimumHealth;
        public byte MaximumHealth;
        public byte MinimumCharm;
        public byte MaximumCharm;
        public byte HitpointModifierPerLevel;
        public ushort ExperiencePercentage;
        
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
        public byte[] UnusedByteArray1;

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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] UnusedByteArray2;
    }
}
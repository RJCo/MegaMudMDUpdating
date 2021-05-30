using System.Runtime.InteropServices;


namespace MegaMudMDCreator
{
    // TODO:  RaceMD fields and update Size in StructLayout
    [StructLayout(LayoutKind.Sequential, Size = 0, Pack = 1)]
    public struct RaceMD
    {
        public ushort RaceId;

        // TODO:  Size
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0)]
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
        public byte ExperiencePercentage;
        
        // TODO:  Below is copied from ClassMD - probably not the same for Race
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
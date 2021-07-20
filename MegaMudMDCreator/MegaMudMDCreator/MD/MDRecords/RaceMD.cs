using System.Runtime.InteropServices;


namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RaceMD
    {
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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] AbilityKeys;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] UnusedByteArray1;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] AbilityValues;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] UnusedByteArray2;
    }
}
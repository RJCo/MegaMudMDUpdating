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
        public byte MinimumIntellect;
        public byte MinimumAgility;
        public byte MinimumWillpower;
        public byte MinimumHealth;
        public byte MinimumCharm;
        public byte MaximumStrength;
        public byte MaximumIntellect;
        public byte MaximumAgility;
        public byte MaximumWillpower;
        public byte MaximumHealth;
        public byte MaximumCharm;

        public byte HitpointModifierPerLevel;
        public ushort ExperiencePercentage;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityKeys;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityValues;
    }
}
using System.Runtime.InteropServices;

namespace MegaMudMDCreator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ClassMD
    {
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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityKeys;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] AbilityValues;

        public byte EndChar;
    }
}

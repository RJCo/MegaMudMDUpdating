using System.IO;

namespace MegaMudMDCreator
{
    public static class MDFiles
    {
        public static string MEGAMUD_PATH = Properties.Settings.Default.MegaMudRootPath;
        public static string DEFAULT_PATH = Path.Combine(MEGAMUD_PATH, Properties.Settings.Default.DefaultRelativePath);
        public static string BBS_PATH = Path.Combine(MEGAMUD_PATH, Properties.Settings.Default.BBSRelativePath);
        public static string CHARS_PATH = Path.Combine(MEGAMUD_PATH, Properties.Settings.Default.CharactersRelativePath);

        public static string CLASSES_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.ClassesFile);
        public static string ITEMS_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.ItemsFile);
        public static string MESSAGES_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.MessagesFile);
        public static string MONSTERS_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.MonstersFile);
        public static string PATHS_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.PathsFile);
        public static string RACES_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.RacesFile);
        public static string SPELLS_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.SpellsFile);
        public static string ROOMS_FILE = Path.Combine(DEFAULT_PATH, Properties.Settings.Default.RoomsFile);
    }
}

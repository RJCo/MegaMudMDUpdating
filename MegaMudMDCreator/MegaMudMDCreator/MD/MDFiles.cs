using System.IO;


namespace MegaMudMDCreator
{
    public static class MDFiles
    {
        public static string MEGAMUD_PATH = @"C:\Program Files (x86)\Megamud\";
        public static string DEFAULT_PATH = Path.Combine(MEGAMUD_PATH, @"Default");
        public static string BBS_PATH = Path.Combine(MEGAMUD_PATH, @"BBS");
        public static string CHARS_PATH = Path.Combine(MEGAMUD_PATH, @"Chars");

        public static string CLASSES_FILE = Path.Combine(DEFAULT_PATH, @"Classes.md");
        public static string ITEMS_FILE = Path.Combine(DEFAULT_PATH, @"Items.md");
        public static string MESSAGES_FILE = Path.Combine(DEFAULT_PATH, @"Messages.md");
        public static string MONSTERS_FILE = Path.Combine(DEFAULT_PATH, @"Monsters.md");
        public static string PATHS_FILE = Path.Combine(DEFAULT_PATH, @"Paths.md");
        public static string RACES_FILE = Path.Combine(DEFAULT_PATH, @"Races.md");
        public static string SPELLS_FILE = Path.Combine(DEFAULT_PATH, @"Spells.md");
        public static string ROOMS_FILE = Path.Combine(DEFAULT_PATH, @"Rooms.md");
    }
}

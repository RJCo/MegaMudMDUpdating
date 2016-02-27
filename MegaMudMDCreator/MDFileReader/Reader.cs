using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDFileUtil {
    public class Reader {
        static void Main(string[] args) {
            /*
             *  Classes.md
             *  Items.md
             *  Messages.md
             *  Monsters.md
             *  Paths.md
             *  Races.md
             *  Spells.md
             *  Rooms.md <-- different format
             */
            FileReader(CLASSES_FILE);
            FileReader(ITEMS_FILE);
            FileReader(MESSAGES_FILE);
            FileReader(MONSTERS_FILE);
            FileReader(PATHS_FILE);
            FileReader(RACES_FILE);
            FileReader(SPELLS_FILE);
            FileReader(ROOMS_FILE);
        }

        public static string MEGAMUD_PATH = @"C:\Program Files (x86)\Megamud\";
        public static string DEFAULT_PATH = MEGAMUD_PATH + @"Default\";
        public static string BBS_PATH =     MEGAMUD_PATH + @"BBS\";
        public static string CHARS_PATH = MEGAMUD_PATH + @"Chars\";

        public static string CLASSES_FILE = DEFAULT_PATH + @"Classes.md";
        public static string ITEMS_FILE = DEFAULT_PATH + @"Items.md";
        public static string MESSAGES_FILE = DEFAULT_PATH + @"Messages.md";
        public static string MONSTERS_FILE = DEFAULT_PATH + @"Monsters.md";
        public static string PATHS_FILE = DEFAULT_PATH + @"Paths.md";
        public static string RACES_FILE = DEFAULT_PATH + @"Races.md";
        public static string SPELLS_FILE = DEFAULT_PATH + @"Spells.md";
        public static string ROOMS_FILE = DEFAULT_PATH + @"Rooms.md";

        public static List<List<byte>> FileReader(string file) {
            return (file == ROOMS_FILE) ? RoomsFileReader(file) : MDFileReader(file);
        }

        private static List<List<byte>> RoomsFileReader(string file) {
            throw new NotImplementedException();
        }

        private static List<List<byte>> MDFileReader(string file) {
            try {
                var parsedRawData = new List<List<byte>>();

                using (var fsSource = new FileStream(file, FileMode.Open, FileAccess.Read)) {

                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0) {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }

                    // read 0x400 bytes at a time
                    for (int i = 0; i < bytes.Length - 1; i += 0x400) {
                        // if the 0x400 starts with 01, skip it
                        // if the 0x400 begins with 00 00 xx, parse it and print to console or file
                        if (bytes[i] != 0x00) {
                            continue;
                        }

                        int rowCount = bytes[i + 2];

                        // first record will be i+12
                        int nextLocation = i + 12;
                        while (nextLocation > 0) {
                            if (bytes[nextLocation] == 0x00) {
                                nextLocation = 0;
                                continue;
                            }

                            int rowLength = bytes[nextLocation];

                            var hexOutput = string.Empty;
                            var rowInformation = new List<byte>();
                            for (int j = 0; j < rowLength; j++) {
                                hexOutput += String.Format("{0:X2} ", bytes[nextLocation + j]);
                                rowInformation.Add(bytes[nextLocation+j]);
                            }

                            //Console.WriteLine(hexOutput);
                            parsedRawData.Add(rowInformation);
                            nextLocation += rowLength+1;
                        }
                    }

                }
                return parsedRawData;
            }
            catch (Exception e) {
                Console.WriteLine("Reading file {0} failed:  " + e.Message, file);
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDFileUtil
{
    public class Writer
    {
        public static void Main(string[] args)
        {
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
            //FileWriter(Files.CLASSES_FILE);
            //FileWriter(Files.ITEMS_FILE);
            //FileWriter(Files.MESSAGES_FILE);
            //FileWriter(Files.MONSTERS_FILE);
            //FileWriter(Files.PATHS_FILE);
            //FileWriter(Files.RACES_FILE);
            //FileWriter(Files.SPELLS_FILE);
            //RoomsFileWriter(Files.ROOMS_FILE);
        }

        public static bool FileWriter(string file, byte[] content)
        {
            return MDFileWriter(file, content);
        }

        public static bool RoomsFileWriter(string file, byte[] content)
        {
            try
            {
                List<string> rooms = new List<string>();
                string line = string.Empty;
                StreamReader fileStream = new StreamReader(file);
                while ((line = fileStream.ReadLine()) != null)
                {
                    rooms.Add(line);
                }
                fileStream.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading file {0} failed:  " + e.Message, file);
            }

            return false;
        }

        private static bool MDFileWriter(string file, byte[] content)
        {
            try
            {
                File.WriteAllBytes(file, content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading file {0} failed:  " + e.Message, file);
            }
        }
    }
}

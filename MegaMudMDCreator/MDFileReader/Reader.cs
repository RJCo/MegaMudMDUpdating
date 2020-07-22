using System;
using System.Collections.Generic;
using System.IO;


namespace MDFileUtil
{
    public class Reader
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
            FileReader(Files.CLASSES_FILE);
            FileReader(Files.ITEMS_FILE);
            FileReader(Files.MESSAGES_FILE);
            FileReader(Files.MONSTERS_FILE);
            FileReader(Files.PATHS_FILE);
            FileReader(Files.RACES_FILE);
            FileReader(Files.SPELLS_FILE);
            RoomsFileReader(Files.ROOMS_FILE);
        }

        public static List<List<byte>> FileReader(string file)
        {
            return MDFileReader(file);
        }

        public static List<string> RoomsFileReader(string file)
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

                return rooms;
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading file {0} failed:  " + e.Message, file);
            }

            return null;
        }

        private static List<List<byte>> MDFileReader(string file)
        {
            try
            {
                var parsedRawData = new List<List<byte>>();

                using (var fsSource = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }

                    // read 0x400 bytes at a time
                    for (int i = 0; i < bytes.Length - 1; i += 0x400)
                    {
                        // if the 0x400 starts with 01, skip it
                        // if the 0x400 begins with 00 00 xx, parse it and print to console or file
                        if (bytes[i] != 0x00)
                        {
                            continue;
                        }

                        int rowCount = bytes[i + 2];

                        // first record will be i+12
                        int nextLocation = i + 12;
                        while (nextLocation > 0)
                        {
                            if (bytes[nextLocation] == 0x00)
                            {
                                nextLocation = 0;
                                continue;
                            }

                            int rowLength = bytes[nextLocation];

                            var hexOutput = string.Empty;
                            var rowInformation = new List<byte>();
                            for (int j = 0; j < rowLength; j++)
                            {
                                hexOutput += String.Format("{0:X2} ", bytes[nextLocation + j]);
                                rowInformation.Add(bytes[nextLocation + j]);
                            }

                            //Console.WriteLine(hexOutput);
                            parsedRawData.Add(rowInformation);
                            nextLocation += rowLength + 1;
                        }
                    }

                }
                return parsedRawData;
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading file {0} failed:  " + e.Message, file);
            }

            return null;
        }
    }
}

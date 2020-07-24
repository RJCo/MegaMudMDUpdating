using System;
using System.Collections.Generic;
using System.IO;


namespace MegaMudMDCreator
{
    public class MDFileWriter
    {
        public static bool FileWriter(string file, byte[] content)
        {
            return WriteToMDFile(file, content);
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
                Console.WriteLine($"Writing file {file} failed:  {e.Message}");
            }

            return false;
        }

        private static bool WriteToMDFile(string file, byte[] content)
        {
            try
            {
                File.WriteAllBytes(file, content);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Writing file {file} failed:  {e.Message}");
            }

            return false;
        }
    }
}

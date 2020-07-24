using Records;
using System;
using System.Collections.Generic;

namespace MegaMudMDCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // PrintAllClasses();
            // PrintAllRaces();
            var classReader = new ClassesMDReader<Class>();
            var classWriter = new ClassesMDWriter<Class>();

            List<Class> allClasses = classReader.GetAllRecords();
            List<byte[]> classesToWrite = new List<byte[]>(allClasses.Count);

            foreach (Class c in allClasses)
                classesToWrite.Add(classWriter.Serialize(c));

            // TODO:  Write to MD file using MDFileUtil
        }

        private static void PrintAllClasses()
        {
            var classMDReader = new ClassesMDReader<Class>();
            var allClasses = classMDReader.GetAllRecords();

            foreach (var cls in allClasses)
            {
                Console.WriteLine(cls.ToString());
            }
        }

        private static void PrintAllRaces()
        {
            var racesMDReader = new RacesMDReader<Race>();
            var allRaces = racesMDReader.GetAllRecords();

            foreach (var race in allRaces)
            {
                Console.WriteLine(race.ToString());
            }
        }
    }
}

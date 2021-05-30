using Records;
using System;
using System.Collections.Generic;

namespace MegaMudMDCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintAllClasses();
            PrintAllRaces();
            
            //var classReader = new ClassesMDReader<Class>();
            //var classWriter = new ClassesMDWriter<Class>();

            //List<Class> allClasses = classReader.GetAllRecords();
            //List<byte[]> classesToWrite = new List<byte[]>(allClasses.Count);

            //foreach (Class c in allClasses)
            //{
            //    classesToWrite.Add(classWriter.Serialize(c));
            //}

            // TODO:  Write to MD file using MDFileUtil
            Console.Read();
        }

        private static void PrintAllClasses()
        {
            var classMDReader = new ClassesMDReader<Class>();
            List<Class> allClasses = classMDReader.GetAllRecords();

            foreach (Class cls in allClasses)
            {
                Console.WriteLine(cls.ToString());
            }
        }

        private static void PrintAllRaces()
        {
            var racesMDReader = new RacesMDReader<Race>();
            List<Race> allRaces = racesMDReader.GetAllRecords();

            foreach (Race race in allRaces)
            {
                Console.WriteLine(race.ToString());
            }
        }
    }
}

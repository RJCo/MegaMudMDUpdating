using Records;
using System;


namespace MegaMudMDCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // PrintAllClasses();
            PrintAllRaces();
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

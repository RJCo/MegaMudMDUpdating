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
            var allClasses = ClassesCreator.GetAllRecords();

            foreach (var cls in allClasses)
            {
                Console.WriteLine(cls.ToString());
            }
        }

        private static void PrintAllRaces()
        {
            var allRaces = RacesCreator.GetAllRecords();

            foreach (var race in allRaces)
            {
                Console.WriteLine(race.ToString());
            }
        }
    }
}

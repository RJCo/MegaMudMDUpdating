using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    class Program
    {
        static void Main(string[] args) {
            // PrintAllClasses();
            PrintAllRaces();
        }

        private static void PrintAllClasses() {
            var allClasses = ClassesCreator.GetAllRecords();

            foreach (var cls in allClasses) {
                Console.WriteLine(cls.ToString());
            }
        }

        private static void PrintAllRaces() {
            var allRaces = RacesCreator.GetAllRecords();

            foreach (var race in allRaces) {
                Console.WriteLine(race.ToString());
            }
        }
    }
}

using Records;
using System;
using System.Collections.Generic;

namespace MegaMudMDCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // MegaMud MD input, MegaMud MD output
            //PrintAllClasses();
            //PrintAllRaces();
            //PrintAllSpells();
            PrintAllItems();
            //PrintAllMonsters();
            // Rooms?
            // Paths?

            // MME (MajorMUD Explorer) input, MegaMud MD output
            // PrintAllMMEClasses();

            Console.Read();
        }

        private static void PrintAllClasses()
        {
            Console.WriteLine("----------- CLASSES START -----------");
            var classMDReader = new ClassesMDReader<Class>();
            List<Class> allClasses = classMDReader.GetAllRecords();

            foreach (Class cls in allClasses)
            {
                Console.WriteLine(cls.ToString());
            }
            Console.WriteLine("----------- CLASSES END -----------");

            Console.WriteLine("----------- CLASSES START SERIALIZE-----------");
            var classMDWriter = new ClassesMDWriter<Class>(allClasses);
            classMDWriter.WriteFile();
            Console.WriteLine("----------- CLASSES END SERIALIZE-----------");
        }

        private static void PrintAllMMEClasses()
        {
            Console.WriteLine("----------- CLASSES START -----------");
            var classMMEReader = new ClassesMMEReader<Class>();
            List<Class> allClasses = classMMEReader.GetAllRecords();

            foreach (Class cls in allClasses)
            {
                Console.WriteLine(cls.ToString());
            }
            Console.WriteLine("----------- CLASSES END -----------");

            Console.WriteLine("----------- CLASSES START SERIALIZE-----------");
            var classMDWriter = new ClassesMDWriter<Class>(allClasses);
            classMDWriter.WriteFile();
            Console.WriteLine("----------- CLASSES END SERIALIZE-----------");
        }

        private static void PrintAllRaces()
        {
            Console.WriteLine("----------- RACES START -----------");
            var racesMDReader = new RacesMDReader<Race>();
            List<Race> allRaces = racesMDReader.GetAllRecords();

            foreach (Race race in allRaces)
            {
                Console.WriteLine(race.ToString());
            }
            Console.WriteLine("----------- RACES END -----------");

            Console.WriteLine("----------- RACES START SERIALIZE-----------");
            var racesMDWriter = new RacesMDWriter<Race>(allRaces);
            racesMDWriter.WriteFile();
            Console.WriteLine("----------- RACES END SERIALIZE-----------");

        }

        private static void PrintAllSpells()
        {
            Console.WriteLine("----------- SPELLS START -----------");
            var spellsMDReader = new SpellsMDReader<Spell>();
            List<Spell> allSpells = spellsMDReader.GetAllRecords();

            foreach (Spell spell in allSpells)
            {
                Console.WriteLine(spell.ToString());
            }
            Console.WriteLine("----------- SPELLS END -----------");
        }

        private static void PrintAllItems()
        {
            Console.WriteLine("----------- ITEMS START -----------");
            var itemsMDReader = new ItemsMDReader<Item>();
            List<Item> allItems = itemsMDReader.GetAllRecords();

            foreach (Item item in allItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("----------- ITEMS END -----------");
        }

        private static void PrintAllMonsters()
        {
            Console.WriteLine("----------- MONSTERS START -----------");
            var monstersMDReader = new MonstersMDReader<Monster>();
            List<Monster> allMonsters = monstersMDReader.GetAllRecords();

            foreach (Monster monster in allMonsters)
            {
                Console.WriteLine(monster.ToString());
            }
            Console.WriteLine("----------- MONSTERS END -----------");
        }
    }
}

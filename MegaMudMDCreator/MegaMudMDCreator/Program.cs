﻿using Records;
using System;
using System.Collections.Generic;

namespace MegaMudMDCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PrintAllClasses();
            //PrintAllRaces();
            //PrintAllSpells();
            PrintAllItems();
            
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
            Console.WriteLine("----------- CLASSES START -----------");
            var classMDReader = new ClassesMDReader<Class>();
            List<Class> allClasses = classMDReader.GetAllRecords();

            foreach (Class cls in allClasses)
            {
                Console.WriteLine(cls.ToString());
            }
            Console.WriteLine("----------- CLASSES END -----------");
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
    }
}

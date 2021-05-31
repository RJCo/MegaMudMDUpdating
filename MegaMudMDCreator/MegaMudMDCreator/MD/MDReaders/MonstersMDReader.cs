using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class MonstersMDReader<T> : MDReaderFactory<T>
        where T : Monster
    {
        public override List<T> GetAllRecords()
        {
            var monsters = new List<T>();

            List<MonsterMD> rawData = MDFileReader.FileReader<MonsterMD>(MDFiles.MONSTERS_FILE);
            if (rawData == null)
            {
                Console.WriteLine($"Unable to read file {MDFiles.MONSTERS_FILE} - not parsing Monsters");
                return monsters;
            }

            foreach (MonsterMD monster in rawData)
            {
                Monster newMonster = new Monster()
                {
                    MonsterId = monster.MonsterId,
                    MonsterName = monster.MonsterName,
                    AttackPriority = (Monster.Priority)monster.AttackPriority,
                    Attack = (Monster.AttackType)monster.AttackModifiers,
                    MonsterRelationship = (Monster.Relationship)monster.FearLevel,
                    PreAttackSpell = monster.PreattackSpellCode,
                    AttackSpell = monster.AttackSpellCode,
                    Sex = (Monster.Gender)monster.SexFlag,
                    Level = monster.MonsterLevel,
                    Hitpoints = monster.Hitpoints,
                    Energy = monster.Energy,
                    MagicResistance = monster.MagicResistance,
                    Accuracy = monster.Accuracy,
                    ArmorClass = monster.ArmorClass,
                    DamageReduction = monster.DamageReduction,
                    EnslaveLevel = monster.EnslaveLevel,
                };

                monsters.Add((T)newMonster);
            }

            return monsters;
        }
    }
}

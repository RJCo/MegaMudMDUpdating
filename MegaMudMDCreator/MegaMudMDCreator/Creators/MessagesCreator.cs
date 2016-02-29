using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator {
    public class MessagesCreator {
        /*
        public static int ClassIDOffset = 0;
        public static int ClassLength = 2;
        public static int ClassNameOffset = 2;
        public static int ClassNameLength = 28;
        public static int ExpOffset = 32;
        public static int ExpLength = 11;
        public static int CombatOffset = 34;
        public static int CombatLength = 1;
        public static int MinHPOffset = 35;
        public static int MinHPLength = 1;
        public static int MaxHPOffset = 36;
        public static int MaxHPLength = 1; 
        public static int WeaponsOffset = 37;
        public static int WeaponsLength = 1;
        public static int ArmorOffset = 38;
        public static int ArmorLength = 1;
        public static int MagicLevelOffset = 39;
        public static int MagicLevelLength = 1;
        public static int MagicTypeOffset = 40;
        public static int MagicTypeLength = 11;
        public static int AbilityKeysOffset = 41;
        public static int AbilityKeysLength = 20;
        public static int AbilityValuesOffset = 61;
        public static int AbilityValuesLength = 20;
        public static int MaxAbilities = 9;
        public static int AbilityKeyLength = 2;
        public static int AbilityValueLength = 2;
        */

        private static void UpdateOffsetsAndLengths(int headerOffset) {
            throw new NotImplementedException();
            /*
            ClassIDOffset += headerOffset;
            ClassNameOffset += headerOffset;
            ExpOffset += headerOffset;
            CombatOffset += headerOffset;
            MaxHPOffset += headerOffset;
            MinHPOffset += headerOffset;
            WeaponsOffset += headerOffset;
            ArmorOffset += headerOffset;
            MagicLevelOffset += headerOffset;
            MagicTypeOffset += headerOffset;
            AbilityKeysOffset += headerOffset;
            AbilityValuesOffset += headerOffset;
             * */
        }

        public static List<Message> GetAllDefaultClasses() {
            var rawData = MDFileUtil.Reader.FileReader(MDFileUtil.Reader.MESSAGES_FILE);

            var messages = new List<Message>();

            throw new NotImplementedException();

            /*
            foreach (var raw in rawData) {
                //Console.WriteLine("Length of raw: {0}", raw.Count);
                //string data = raw.Aggregate(string.Empty, (current, byt) => current + string.Format("{0:X2} ", byt));
                //Console.WriteLine("RawData: {0}", data);

                int classID = -1;
                string className = string.Empty;
                int expBasePercent = -1;
                int combatLevel = -1;
                int minHPPerLevel = -1;
                int maxHPPerLevel = -1;
                var weaponsUseable = Class.WeaponClasses.Unknown;
                var armorUseable = Class.ArmorClasses.Unknown;
                int magicLevel = 0;
                var magicType = Class.MagicTypes.None;
                var abilitiesAndModifiers = new Dictionary<Class.AbilitiesAndModifiers, int>();

                // Since headers on rows are variable length, we need to first get to a null and then 
                // find the index of the first bit of data past "0x80" and know that's where we start
                int firstNull = raw.IndexOf(0x00);
                int headerOffset = raw.IndexOf(0x80, firstNull) + 1;
                UpdateOffsetsAndLengths(headerOffset);




                string data = raw.Aggregate(string.Empty, (current, byt) => current + string.Format("{0:X2} ", byt));
                //Console.WriteLine("ClassIDOffset: {1}, RawData: {0}", data, ClassIDOffset);
                //UpdateOffsetsAndLengths(-headerOffset);
                //continue;


                // ClassID (reverse order because it's stored Little Endian
                var id = new byte[] {
                    raw[ClassIDOffset],
                    raw[ClassIDOffset+1],
                };
                classID = BitConverter.ToInt16(id, 0);

                // Class Name
                for (int i = ClassNameOffset; (i < ClassNameOffset + ClassNameLength) && (raw[i] != 0x00); i++) {
                    className += (char)raw[i];
                }

                // Exp
                var exp = new byte[] {
                    raw[ExpOffset],
                    raw[ExpOffset+1],
                };
                expBasePercent = BitConverter.ToInt16(exp, 0);

                // Combat Level
                combatLevel = Convert.ToInt32(raw[CombatOffset]);

                // Min HP Per Level
                minHPPerLevel = Convert.ToInt32(raw[MinHPOffset]);

                // Max HP Per Level
                maxHPPerLevel = Convert.ToInt32(raw[MaxHPOffset]);

                // Weapons Useable
                weaponsUseable = (Class.WeaponClasses)Convert.ToInt32(raw[WeaponsOffset]);

                // Armor Useable
                armorUseable = (Class.ArmorClasses)Convert.ToInt32(raw[ArmorOffset]);

                // Magic Level
                magicLevel = Convert.ToInt32(raw[MagicLevelOffset]);

                // Magic Type
                magicType = (Class.MagicTypes)Convert.ToInt32(raw[MagicTypeOffset]);

                // Modifiers and Abilities
                for (int i = 0; i < MaxAbilities; i++) {
                    var rawKey = new byte[] {
                        raw[AbilityKeysOffset + (i*AbilityKeyLength)],
                        raw[AbilityKeysOffset + (i*AbilityKeyLength) + 1],
                    };

                    var rawValue = new byte[] {
                        raw[AbilityValuesOffset + (i*AbilityValueLength)],
                        raw[AbilityValuesOffset + (i*AbilityValueLength) + 1],
                    };

                    var key = BitConverter.ToInt16(rawKey, 0);
                    var value = BitConverter.ToInt16(rawValue, 0);

                    if (key != 0) {
                        abilitiesAndModifiers.Add((Class.AbilitiesAndModifiers)key, value);
                    }
                }

                var thisClass = new Class {
                    ID = classID, 
                    Name = className, 
                    ExperiencePercentage = expBasePercent, 
                    Combat = combatLevel, 
                    HitpointPerLevelMinimum = minHPPerLevel, 
                    HitpointPerLevelMaximum = maxHPPerLevel, 
                    WeaponType = weaponsUseable, 
                    ArmorType = armorUseable, 
                    MagicLevel = magicLevel, 
                    MagicType = magicType, 
                    AbilitiesAndMods = abilitiesAndModifiers
                };

                UpdateOffsetsAndLengths(-headerOffset);
                classes.Add(thisClass);
            }
            */

            return messages;
        }
    }
}

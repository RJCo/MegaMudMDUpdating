using Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MegaMudMDCreator
{
    public class ClassesMDWriter<T> : MDWriterFactory<T>
        where T : Class
    {
        private readonly List<Class> _classes;
        public ClassesMDWriter(List<Class> classes)
        {
            _classes = classes;
        }

        public override List<byte[]> GetListOfRecordBytes()
        {
            List<byte[]> classesBytes = new List<byte[]>(_classes.Count);

            List<Class> sortedClasses = _classes.OrderBy(o => o.ID.ToString()).ToList();

            foreach (Class cls in sortedClasses)
            {
                byte[] serializedClass = Serialize(cls);
                classesBytes.Add(serializedClass);
            }

            return classesBytes;
        }

        public override void WriteFile()
        {
            string filename = MDFiles.CLASSES_OUTPUT_FILE;

            var file = new MDFileData(filename, GetListOfRecordBytes());
            file.WriteToFile();
        }

        private byte[] Serialize(Class rec)
        {
            ClassMD classMD = default;

            classMD.ClassId = (ushort)rec.ID;
            classMD.ClassName = rec.Name;
            classMD.ExperienceBase = UshortToByteArray((ushort)rec.ExperiencePercentage);
            Array.Reverse(classMD.ExperienceBase);

            classMD.CombatLevel = (byte)rec.Combat;
            classMD.MinHPPerLevel = (byte)rec.HitpointPerLevelMinimum;
            classMD.MaxHPPerLevel = (byte)rec.HitpointPerLevelMaximum;
            classMD.WeaponsUsable = (byte)rec.WeaponType;
            classMD.ArmorUseable = (byte)rec.ArmorType;
            classMD.MagicLevel = (byte)rec.MagicLevel;

            classMD.AbilityKeys = new byte[Common.MAX_BYTES_FOR_ABILITIES];
            classMD.AbilityValues = new byte[Common.MAX_BYTES_FOR_ABILITIES];

            int i = 0;
            foreach (KeyValuePair<Common.Abilities, short> kvp in rec.AbilitiesAndMods)
            {
                Common.Abilities ability = kvp.Key;
                short abilityMod = kvp.Value;

                if (i >= Common.MAX_BYTES_FOR_ABILITIES)
                {
                    Console.WriteLine($"{GetType().Name}.{nameof(Serialize)}: Got more than {classMD.AbilityKeys.Length / 2} abilities for {rec.Name}!  Can't add {ability}={abilityMod}");
                    continue;
                }

                byte[] k = BitConverter.GetBytes((short)ability);
                byte[] v = BitConverter.GetBytes(abilityMod);

                classMD.AbilityKeys[i] = k[1];
                classMD.AbilityKeys[i + 1] = k[0];

                classMD.AbilityValues[i] = v[1];
                classMD.AbilityValues[i + 1] = v[0];

                i += 2;
            }
            classMD.EndChar = 0x20;

            byte[] unusedByte = { 0x01 }; // Always 0x01
            byte[] classIdAsCharacters = Encoding.ASCII.GetBytes(classMD.ClassId.ToString());
            byte[] padding = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 };

            byte length = UshortToByteArray((ushort)(unusedByte.Length + classIdAsCharacters.Length + padding.Length + Marshal.SizeOf(classMD)))[1];

            var classHeaderParts = new List<byte[]>(4)
            {
                new byte[] { length },
                unusedByte,
                classIdAsCharacters,
                padding
            };

            byte[] classHeader = classHeaderParts.SelectMany(t => t).ToArray();
            byte[] classRecord = GetBytes(classMD);

            return CombineArrays(classHeader, classRecord);
        }

        internal byte[] GetBytes(ClassMD str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}

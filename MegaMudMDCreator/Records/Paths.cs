using System;
using System.Collections.Generic;


namespace Records
{
    public class Paths : IRecord
    {
        #region Enums
        public enum Flags
        {
            None = 0x00000000,
            PathIsLoop = 0x00000001,
            IgnoreItemIfPicklocks = 0x00000002,
            Activated = 0x01000000,             // Available to player
            OutOfDate = 0x02000000,             // Path need updating?
            Verified = 0x04000000,              // Path has been verified against database
        }
        #endregion

        public string Name { get; set; }
        public string Author { get; set; }
        public string Filename { get; set; }
        public Item ItemNeeded { get; set; }
        public Paths OnFailDo { get; set; }
        public Paths OnFinishDo { get; set; }
        public Room StartingRoom { get; set; }
        public Room EndingRoom { get; set; }
        public int RequiredGold { get; set; }
        public int LastExpRate { get; set; }
        public int StepCount { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Flags> PathFlags { get; set; }

        public new string ToString()
        {
            string recordStr = string.Empty;

            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("Author: {0}\n", Author);
            recordStr += string.Format("Filename: {0}\n", Filename);
            recordStr += string.Format("ItemNeeded: {0}\n", ItemNeeded.ItemName);
            recordStr += string.Format("OnFailDo: {0}\n", OnFailDo.Filename);
            recordStr += string.Format("OnFinishDo: {0}\n", OnFinishDo.Filename);
            recordStr += string.Format("StartingRoom: {0}\n", StartingRoom.Name);
            recordStr += string.Format("EndingRoom: {0}\n", EndingRoom.Name);
            recordStr += string.Format("RequiredGold: {0}\n", RequiredGold);
            recordStr += string.Format("LastExpRate: {0}\n", LastExpRate);
            recordStr += string.Format("StepCount: {0}\n", StepCount);

            foreach (Room room in Rooms)
            {
                recordStr += string.Format("Room: {0}\n", room.Name);
            }

            foreach (Flags flag in PathFlags)
            {
                recordStr += string.Format("Path Flag: {0}:{1}\n", Enum.GetName(typeof(Flags), flag), flag);
            }

            return recordStr;
        }
    }
}

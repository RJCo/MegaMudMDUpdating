

namespace Records
{
    public class Room : IRecord
    {
        #region Enums
        public enum Flags
        {
            NoFlags = 0x0000,
            Shop = 0x0002,
            Bank = 0x0004,
            Trainer = 0x0008,
            StopBeforeEntering = 0x0010,
            AvoidThisRoomIfPossible = 0x0020,
            HideInGoToList = 0x4040,
            SpecialRoom = 0x8000
        }

        public enum PathRoomFlags
        {
            None = 0x0000,
            DarkRoom = 0x0001,
            RestUpHere = 0x0002,
            DoNotRestHere = 0x0004,
            PitchBlack = 0x0008,
            StashPoint = 0x0010,
            DoNotAttackHere = 0x0040,
            RelearnRoom = 0x0080,
            SuspectUNKNOWN = 0x0100,
            DisarmTraps = 0x0200,
            CanPickLock = 0x0400,
            CycledUNKNOWN = 0x8000,
        }

        public enum Exits
        {
            North = 0x00001,
            DoorNorth = 0x00002,
            South = 0x00004,
            DoorSouth = 0x00008,
            East = 0x00010,
            DoorEast = 0x00020,
            West = 0x00040,
            DoorWest = 0x00080,
            Northeast = 0x00100,
            DoorNortheast = 0x00200,
            Northwest = 0x00400,
            DoorNorthwest = 0x00800,
            Southeast = 0x01000,
            DoorSoutheast = 0x02000,
            Southwest = 0x04000,
            DoorSouthwest = 0x08000,
            Up = 0x10000,
            DoorUp = 0x20000,
            Down = 0x40000,
            DoorDown = 0x80000,
        }
        #endregion

        public string Code { get; set; }
        public string Checksum { get; set; }
        public string Name { get; set; }
        public int WCCMap { get; set; }
        public int WCCRoom { get; set; }
        public string Group { get; set; }
        public string Map { get; set; }
        public Flags RoomFlags { get; set; }
        public Exits AvailableExits { get; set; }
        public int MinimumLevel { get; set; }
        public int MaximumLevel { get; set; }
        public int RestrictedToClassID { get; set; }

        public new string ToString()
        {
            string recordStr = string.Empty;

            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("Key: {0}\t", Checksum);
            recordStr += string.Format("Code: {0}\n", Code);
            recordStr += string.Format("WCC Map Room: {0} {1}\n", WCCMap, WCCRoom);
            recordStr += string.Format("Group: {0}\n", Group);
            recordStr += string.Format("Map: {0}\n", Map);
            recordStr += string.Format("MinimumLevel: {0}\n", MinimumLevel);
            recordStr += string.Format("MaximumLevel: {0}\n", MaximumLevel);
            recordStr += string.Format("RestrictedToClassID: {0}\n", RestrictedToClassID);
            recordStr += string.Format("AvailableExits: {0}\n", AvailableExits);
            recordStr += string.Format("Room Flags: {0}\n", RoomFlags);

            return recordStr;
        }
    }
}

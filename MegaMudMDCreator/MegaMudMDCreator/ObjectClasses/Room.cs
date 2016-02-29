using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator
{
    public class Room : IMDFileRecord
    {
        #region Enums
        public enum RoomFlags {
            NoFlags = 0x00000000,
            Shop = 0x00000002,
            Bank = 0x00000004,
            Trainer = 0x00000008,
            StopBeforeEntering = 0x00000010,
            AvoidThisRoomIfPossible = 0x00000020,
            HideInGoToList = 0x00004040,
            SpecialRoom = 0x00008000
        }

        public enum Exits {
            North           = 0x00001,
            DoorNorth       = 0x00002,
            South           = 0x00004,
            DoorSouth       = 0x00008,
            East            = 0x00010,
            DoorEast        = 0x00020,
            West            = 0x00040,
            DoorWest        = 0x00080,
            Northeast       = 0x00100,
            DoorNortheast   = 0x00200,
            Northwest       = 0x00400,
            DoorNorthwest   = 0x00800,
            Southeast       = 0x01000,
            DoorSoutheast   = 0x02000,
            Southwest       = 0x04000,
            DoorSouthwest   = 0x08000,
            Up              = 0x10000,
            DoorUp          = 0x20000,
            Down            = 0x40000,
            DoorDown        = 0x80000,
        }
        #endregion

        public string Key { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public RoomFlags Flags { get; set; }
        public Exits AvailableExits { get; set; }
        public int MinimumLevel { get; set; }
        public int MaximumLevel { get; set; }
        public int RestrictedToClassID { get; set; }

        public new string ToString() {
            string recordStr = string.Empty;

            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("Key: {0}\t", Key);
            recordStr += string.Format("Code: {0}\n", Code);
            recordStr += string.Format("Group: {0}\n", Group);
            recordStr += string.Format("MinimumLevel: {0}\n", MinimumLevel);
            recordStr += string.Format("MaximumLevel: {0}\n", MaximumLevel);
            recordStr += string.Format("RestrictedToClassID: {0}\n", RestrictedToClassID);
            recordStr += string.Format("RoomFlags: {0}\n", Flags);
            recordStr += string.Format("AvailableExits: {0}\n", AvailableExits);
          
            return recordStr;
        }
    }
}

using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class RoomsMDReader<T> : MDReaderFactory<T>
        where T : Room
    {
        public override List<T> GetAllRecords()
        {
            List<string> roomLines = MDFileUtil.Reader.RoomsFileReader(MDFileUtil.Reader.ROOMS_FILE);

            var rooms = new List<T>();

            foreach (string roomLine in roomLines)
            {
                // Room format:  CAB00180:00004040:0:0:0:AALY:Ancient Ruin:Ancient Ruin Dark Alley
                var roomParts = roomLine.Split(':');
                string ChecksumAndExits = roomParts[0];
                string RoomFlags = roomParts[1];
                string MinimumLevel = roomParts[2];
                string MaximumLevel = roomParts[3];
                string RestrictedToClassId = roomParts[4];
                string AbbrevCode = roomParts[5];
                string Group = roomParts[6];
                string Name = roomParts[7];

                string Checksum = ChecksumAndExits.Substring(0, 3);
                string Exits = ChecksumAndExits.Substring(3);

                Room r = new Room()
                {
                    Checksum = Checksum,
                    AvailableExits = (Room.Exits)Enum.Parse(typeof(Room.Exits), Exits),
                    RoomFlags = (Room.Flags)Enum.Parse(typeof(Room.Flags), RoomFlags),
                    MinimumLevel = int.Parse(MinimumLevel),
                    MaximumLevel = int.Parse(MaximumLevel),
                    RestrictedToClassID = int.Parse(RestrictedToClassId),
                    Code = AbbrevCode,
                    Group = Group,
                    Name = Name,
                };

                rooms.Add((T)r);
            }

            return rooms;
        }
    }
}

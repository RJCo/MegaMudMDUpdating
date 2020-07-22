using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class Message : IMDFileRecord
    {
        #region Enums
        public enum ActionToTake
        {
            Ignore = 0,
            CheckRoom = 1,
            WaitForItToEnd = 2,
            RestForHPs = 3,
            RestForMana = 4,
            RunAway = 5,
            Hangup = 6,
        }

        public enum Effect
        {
            None = 0x00000000,
            Blinded = 0x00000001,
            Confused = 0x00000002,
            Poisoned = 0x00000004,
            LosingHPs = 0x00000008,
            CannotMove = 0x00000010,
            CannotAttack = 0x00000020,
            Diseased = 0x00000040,
            RegeningHP = 0x00000080,
            FindAnywhereInText = 0x00000100,
            RegeningMana = 0x00000200,
            FindInConversation = 0x00000400,
            EndsCombat = 0x00001000,
            LastActionFailed = 0x00002000,
            UseWhenChasing = 0x00004000,
            Disabled = 0x00008000,
        }

        // Not sure here
        public enum MessageFlag
        {
            None = 0x00000000,
            Active = 0x00000001,
            Wait = 0x00000002,
            Parse1 = 0x00000004,
            Parse2 = 0x00000008,
        }

        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
        public string MessageText { get; set; }
        public string EndsWith { get; set; }
        public string Reply { get; set; }
        public List<MessageFlag> MessageFlags { get; set; }
        public List<Effect> Effects { get; set; }
        public ActionToTake Action { get; set; }


        public new string ToString()
        {
            string recordStr = string.Empty;

            recordStr += string.Format("ID: {0}\t", ID);
            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("MessageText: {0}\n", MessageText);
            recordStr += string.Format("EndsWith: {0}\n", EndsWith);
            recordStr += string.Format("Reply: {0}\n", Reply);
            recordStr += string.Format("Action: {0} {1}\n", Enum.GetName(typeof(ActionToTake), Action), Action);

            foreach (var flag in MessageFlags)
            {
                recordStr += string.Format("MessageFlags: {0}:{1}\n", Enum.GetName(typeof(MessageFlag), flag), flag);
            }

            foreach (var effect in Effects)
            {
                recordStr += string.Format("Effects: {0}:{1}\n", Enum.GetName(typeof(Effect), effect), effect);
            }

            return recordStr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public enum ActionType
    {
        GetAll,
        GetById,
        Add,
        Update,
        DeleteById,
        Error
    }
    public class Packet
    {
        protected const int headerLength = 5;

        public int Length { get; private set; }
        public ActionType ActionType { get; private set; }
        public List<byte> Payload { get; private set; }

        public Packet(int length, ActionType actionType, List<byte> payload)
        {
            Length = length;
            ActionType = actionType;
            Payload = payload;
        }
    }
}

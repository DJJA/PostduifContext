using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class CollectionManipulationPacket : Packet
    {
        public string CollectionName { get; private set; }

        public CollectionManipulationPacket(int length, ActionType actionType, string collectionName, List<byte> payload) 
            : base(length, actionType, payload)
        {
            CollectionName = collectionName;
        }
    }
}

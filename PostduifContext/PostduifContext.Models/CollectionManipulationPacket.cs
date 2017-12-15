using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class CollectionManipulationPacket : Packet
    {
        public ActionType ActionType { get; private set; }
        public string CollectionName { get; private set; }
        //public int Id { get; private set; }
        //public IEnumerable<byte> CollectionData { get; private set; }

        public CollectionManipulationPacket(ActionType actionType, string collectionName) 
            : base(headerLength + 1 + collectionName.Length, PacketType.Manipulation)
        {
            WriteBye((byte)actionType);
            WriteNullTerminatedString(collectionName);
        }

        public CollectionManipulationPacket(byte[] data)
            : base(data)
        {
            ActionType = (ActionType)ReadByte(headerLength);
            CollectionName = ReadNullTerminatedString(headerLength + 1);
            //CollectionData = ReadByteCollection(headerLength, data.Length - headerLength); // TODO Let readNullTerminatedString return bytes read
        }
    }
}

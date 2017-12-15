using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class CollectionManipulationPacket : Packet
    {
        public string CollectionName { get; private set; }
        public IEnumerable<byte> CollectionData { get; private set; }

        public CollectionManipulationPacket(ActionType actionType, string collectionName, byte[] collectionData) 
            : base(headerLength + 1 + collectionName.Length + collectionData.Length, PacketType.Manipulation)
        {
            WriteBye((byte)actionType);
            WriteNullTerminatedString(collectionName);
            WriteByteCollection(collectionData);
        }

        public CollectionManipulationPacket(byte[] data)
            : base(data)
        {
            CollectionName = ReadNullTerminatedString(headerLength);
            CollectionData = ReadByteCollection(headerLength, data.Length - headerLength);
        }
    }
}

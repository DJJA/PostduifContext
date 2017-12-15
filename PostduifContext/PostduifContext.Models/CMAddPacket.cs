using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class CMAddPacket : CollectionManipulationPacket
    {
        public IEnumerable<byte> CollectionData { get; private set; }

        public CMAddPacket(ActionType actionType, string collectionName, IEnumerable<byte> collectionData) 
            : base(actionType, collectionName)
        {
            WriteByteCollection(collectionData);
        }

        public CMAddPacket(byte[] data) 
            : base(data)
        {
        }
    }
}

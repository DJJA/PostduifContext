using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifServer.CollectionLogic
{
    public class CollectionItem
    {
        public int Id { get; private set; }
        public IEnumerable<byte> Data { get; set; }

        public CollectionItem(int id, IEnumerable<byte> data)
        {
            Id = id;
            Data = data;
        }
    }
}

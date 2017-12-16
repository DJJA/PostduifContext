using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifServer.CollectionLogic
{
    public class CollectionItem
    {
        private IEnumerable<byte> data;
        public int Id { get; private set; }

        public IEnumerable<byte> Data
        {
            get => data;
            set => data = value ?? throw new ArgumentNullException();
        }

        public CollectionItem(int id, IEnumerable<byte> data)
        {
            Id = id;
            Data = data;
        }
    }
}

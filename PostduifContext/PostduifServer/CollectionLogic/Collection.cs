using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostduifContext.Models;

namespace PostduifServer.CollectionLogic
{
    public class Collection
    {
        public string Name { get; private set; }
        private List<CollectionItem> collectionItems = new List<CollectionItem>();
        private int identity = 0;

        //public Collection(string name, IEnumerable<CollectionItem> collectionItems)
        //{
        //    Name = name;
        //    CollectionItems = collectionItems.ToList();
        //}

        public Collection(string name)
        {
            Name = name;
        }

        public int Add(IEnumerable<byte> data)
        {
            collectionItems.Add(new CollectionItem(++identity, data));
            return identity;
        }

        public void Update(int id, IEnumerable<byte> data)
        {
            GetById(id).Data = data;
        }

        public IEnumerable<CollectionItem> GetAll()
        {
            return collectionItems;
        }

        public CollectionItem GetById(int id)
        {
            try
            {
                return collectionItems.Single(s => s.Id == id);
            }
            catch (InvalidOperationException ioEx)
            {
                switch (ioEx.HResult)
                {
                    case -2146233079: throw new IdNotFoundException();
                    default: throw;
                }
            }
        }

        public void DeleteById(int id)
        {
            int index = -1;
            for (int i = 0; i < collectionItems.Count; i++)
            {
                if (collectionItems[i].Id == id)
                {
                    index = i;
                }
            }

            if(index == -1) throw new IdNotFoundException();

            collectionItems.RemoveAt(index);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostduifServer.CollectionLogic
{
    public class Collection
    {
        public string Name { get; private set; }
        private List<CollectionItem> CollectionItems;
        private int identity = 0;

        public Collection(string name, IEnumerable<CollectionItem> collectionItems)
        {
            Name = name;
            CollectionItems = collectionItems.ToList();
        }

        public Collection(string name)
        {
            Name = name;
        }

        public int Add(IEnumerable<byte> data)
        {
            CollectionItems.Add(new CollectionItem(++identity, data));
            return identity;
        }

        public void Update(int id, IEnumerable<byte> data)
        {
            CollectionItems.Single(s => s.Id == id).Data = data;
        }

        public IEnumerable<CollectionItem> GetAll()
        {
            return CollectionItems;
        }

        public CollectionItem GetById(int id)
        {
            return CollectionItems.Single(s => s.Id == id);
        }

        public void DeleteById(int id)
        {
            int index = -1;
            for (int i = 0; i < CollectionItems.Count; i++)
            {
                if (CollectionItems[i].Id == id)
                {
                    index = i;
                }
            }
            CollectionItems.RemoveAt(index);
        }
    }
}

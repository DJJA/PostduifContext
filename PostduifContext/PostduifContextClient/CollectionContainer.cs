using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostduifContextClient
{
    static class CollectionContainer
    {
        private static List<Collection> Collections = new List<Collection>();

        public static void Add(Collection collection)
        {
            Collections.Add(collection);
        }

        private static Collection GetCollectionByName(string collectionName)
        {
            return Collections.Single(s => s.Name == collectionName);
        }

        public static int AddToCollection(string collectionName, IEnumerable<byte> data)
        {
            return GetCollectionByName(collectionName).Add(data);
        }

        public static void UpdateCollection(string collectionName, int id, IEnumerable<byte> data)
        {
            GetCollectionByName(collectionName).Update(id, data);
        }

        public static IEnumerable<CollectionItem> GetAllFromCollection(string collectionName)
        {
            return GetCollectionByName(collectionName).GetAll();
        }

        public static CollectionItem GetById(string collectionName, int id)
        {
            return GetCollectionByName(collectionName).GetById(id);
        }

        public static void DeleteById(string collectionName, int id)
        {
            GetCollectionByName(collectionName).DeleteById(id);
        }
    }
}

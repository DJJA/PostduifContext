using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostduifContext.Models;

namespace PostduifServer.CollectionLogic
{
    public static class CollectionContainer
    {
        private static List<Collection> collections = new List<Collection>();

        private static void AddCollection(Collection collection)
        {
            collections.Add(collection);
        }

        private static Collection GetCollectionByName(string collectionName)
        {
            if (collectionName == null) throw new ArgumentNullException("collectionName");
            if (collectionName == string.Empty) throw new ArgumentException("CollectionName cannot be empty.");

            collectionName = collectionName.ToLower();
            Collection collection;
            try
            {
                collection = collections.Single(s => s.Name == collectionName);
            }
            catch (InvalidOperationException ioEx)
            {
                collection = new Collection(collectionName);
                AddCollection(collection);
            }
            return collection;
        }

        /// <summary>
        /// Adds item to a specified collection
        /// </summary>
        /// <param name="collectionName">The collection the item needs to be added to</param>
        /// <param name="data">The data to be added</param>
        /// <returns></returns>
        public static int AddToCollection(string collectionName, IEnumerable<byte> data)
        {
            return GetCollectionByName(collectionName).Add(data);
        }

        /// <summary>
        /// Updates item in a specified collection
        /// </summary>
        /// <param name="collectionName">The collection that contains the item to be updated</param>
        /// <param name="id">The id of the item that need to be updated</param>
        /// <param name="data">The data that needs to replace the old data</param>
        public static void UpdateCollection(string collectionName, int id, IEnumerable<byte> data)
        {
            GetCollectionByName(collectionName).Update(id, data);
        }

        /// <summary>
        /// Returns all items in a specified collection
        /// </summary>
        /// <param name="collectionName">The collection the items need to come from</param>
        /// <returns>A collection with CollectionItems</returns>
        public static IEnumerable<CollectionItem> GetAllFromCollection(string collectionName)
        {
            return GetCollectionByName(collectionName).GetAll();
        }

        /// <summary>
        /// Gets a item from a specified collection
        /// </summary>
        /// <param name="collectionName">The collection the items needs to come from</param>
        /// <param name="id">The id of the item</param>
        /// <returns>An CollectionItem</returns>
        public static CollectionItem GetById(string collectionName, int id)
        {
            return GetCollectionByName(collectionName).GetById(id);
        }

        /// <summary>
        /// Deletes an item in a collection by its id
        /// </summary>
        /// <param name="collectionName">The collection the item needs to be deleted from</param>
        /// <param name="id">The id of the item that needs to be deleted</param>
        public static void DeleteById(string collectionName, int id)
        {
            GetCollectionByName(collectionName).DeleteById(id);
        }

        /// <summary>
        /// Removes all collections from the memory
        /// </summary>
        public static void RemoveAllCollections()
        {
            collections = new List<Collection>();
        }
    }
}

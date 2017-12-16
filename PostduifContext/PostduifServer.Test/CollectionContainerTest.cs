using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostduifContext.Models;
using PostduifServer.CollectionLogic;

namespace PostduifServer.Test
{
    [TestClass]
    public class CollectionContainerTest
    {
        private byte[] bytes = new byte[] {0x01, 0x02, 0x03, 0x04};
        private byte[] reversedBytes = new byte[] {0x04, 0x03, 0x02, 0x01};

        [TestInitialize]
        public void Initialize()
        {
            //CollectionContainer.Add(new Collection("Test"));
        }

        /// <summary>
        /// This is run after every test
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            CollectionContainer.RemoveAllCollections();
        }

        #region Add
        [TestMethod]
        public void AddTest()
        {
            // Manipulate
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Check
            Assert.AreNotEqual(-1, id);
            CollectionAssert.AreEqual(bytes, CollectionContainer.GetById("Test", id).Data.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTestNullCollectionName()
        {
            // Manipulate
            var id = CollectionContainer.AddToCollection(null, bytes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTestEmptyCollectionName()
        {
            // Manipulate
            var id = CollectionContainer.AddToCollection("", bytes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTestNullByteArray()
        {
            // Manipulate
            CollectionContainer.AddToCollection("Test", null);
        }
        #endregion
        #region Update
        [TestMethod]
        public void UpdateTest()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.UpdateCollection("Test", id, reversedBytes);

            // Check
            CollectionAssert.AreEqual(reversedBytes, CollectionContainer.GetById("Test", id).Data.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTestNullCollectionName()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.UpdateCollection(null, id, reversedBytes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateTestEmptyCollectionName()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.UpdateCollection("", id, reversedBytes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTestNullByteArray()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.UpdateCollection("Test", id, null);
        }

        [TestMethod]
        [ExpectedException(typeof(IdNotFoundException))]
        public void UpdateTestIdNotFound()
        {
            // Manipulate
            CollectionContainer.UpdateCollection("Test", -1, bytes);
        }
        #endregion
        #region Delete
        [TestMethod]
        public void DeleteTest()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.DeleteById("test", id);

            // Check
            var items = CollectionContainer.GetAllFromCollection("test");
            Assert.IsTrue(items.All(s => s.Id != id));
        }

        [TestMethod]
        [ExpectedException(typeof(IdNotFoundException))]
        public void DeleteTestIdNotFound()
        {
            // Manipulate
            CollectionContainer.DeleteById("test", 11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteTestNullCollectionName()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.DeleteById(null, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTestEmptyCollectionName()
        {
            // Vars
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Manipulate
            CollectionContainer.DeleteById("", id);
        }
        #endregion
    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostduifServer.CollectionLogic;

namespace PostduifServer.Test
{
    [TestClass]
    public class CollectionContainerTest
    {
        [TestMethod]
        public void AddTest()
        {
            // Vars
            var bytes = new byte[] {0x01, 0x02, 0x03, 0x04};

            // Manipulate
            var id = CollectionContainer.AddToCollection("Test", bytes);

            // Check
            Assert.AreNotEqual(-1, id);
            CollectionAssert.AreEqual(bytes, CollectionContainer.GetById("Test", id).Data.ToList());
        }

        [TestMethod]
        public void UpdateTest()
        {
            
        }

        [TestMethod]
        public void DeleteTest()
        {
            
        }

    }
}

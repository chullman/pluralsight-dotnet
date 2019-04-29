using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Peek_At_Next_Item()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(1, queue.Peek());
        }

        [TestMethod]
        public void Can_Search_With_Contains()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.IsTrue(queue.Contains(2));
        }
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using WebpageScreensaver.App.Extension;
using System.Linq;

namespace WebpageScreensaver.Test.Extension
{
    [TestFixture]
    public class ListExtensionTest
    {
        [Test]
        public void Test_Shuffle_Ordered_List()
        {
            List<int> list = Enumerable.Range(0, 400).ToList();
            Assert.That(list, Is.Ordered);

            list.Shuffle();
            Assert.That(list, Is.Not.Ordered);
        }

        [Test]
        public void Test_Shuffle_Unordered_List()
        {
        }

        [Test]
        public void Test_Shuffle_Null_List()
        {
        }

        [Test]
        public void Test_Shuffle_Empty_List()
        {
        }
    }
}
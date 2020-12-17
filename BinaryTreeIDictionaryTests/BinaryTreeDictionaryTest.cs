using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeIDictionary;
using System.Collections.Generic;


namespace BinaryTreeIDictionaryTests
{
    [TestClass]
    public class BinaryTreeDictionaryTest
    {
        [TestMethod]
        public void TestAddAndContains()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            dictionary.Add(1, "one");

            Assert.IsTrue(dictionary.Contains(new KeyValuePair<int,string>(1,"one")));

        }

        [TestMethod]
        public void TestAddKeyValueAndContains()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            dictionary.Add(new KeyValuePair<int, string>(1, "one"));

            Assert.IsTrue(dictionary.Contains(new KeyValuePair<int, string>(1, "one")));

        }

        [TestMethod]
        public void TestAddMultipleAndGet()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(6, "six");
            dictionary.Add(4, "four");

            Assert.IsTrue(dictionary.ContainsKey(6));
        }

        [TestMethod]
        public void TestClear()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(6, "six");
            dictionary.Add(4, "four");

            dictionary.Clear();

            Assert.AreEqual(0, dictionary.Count);
        }

        [TestMethod]
        public void TestDontAddAndDontGet()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            Assert.IsFalse(dictionary.ContainsKey(1));
        }

        [TestMethod]
        public void TestCountEmpty()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            Assert.AreEqual(0, dictionary.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(6, "six");
            dictionary.Add(4, "four");

            Assert.AreEqual(4, dictionary.Count);
        }

        [TestMethod]
        public void TestDontCountTwice()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            dictionary.Add(8, "eight");
            dictionary.Add(8, "eight");

            Assert.AreEqual(1, dictionary.Count);
        }

        [TestMethod]
        public void TestRemoveNotAdded()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();

            Assert.IsFalse(dictionary.Remove(1)); ;
        }

        [TestMethod]
        public void TestRemoves()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");

            Assert.IsTrue(dictionary.Remove(8)); ;
            Assert.AreEqual(0, dictionary.Count); ;
        }

        [TestMethod]
        public void TestRemovesWihDeepTree()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(10, "ten");
            dictionary.Add(6, "six");
            dictionary.Add(1, "one");
            dictionary.Add(14, "fourteen");
            dictionary.Add(4, "four");
            dictionary.Add(7, "seven");

            Assert.IsTrue(dictionary.Remove(1)); ;
            Assert.AreEqual(7, dictionary.Count); ;
        }

        [TestMethod]
        public void TestRemovesKeyValueWihDeepTree()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(10, "ten");
            dictionary.Add(6, "six");
            dictionary.Add(1, "one");
            dictionary.Add(14, "fourteen");
            dictionary.Add(4, "four");
            dictionary.Add(7, "seven");

            Assert.IsTrue(dictionary.Remove(new KeyValuePair<int, string>(1, "one"))); ;
            Assert.AreEqual(7, dictionary.Count); ;
        }

        [TestMethod]
        public void TestCopyTo()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(10, "ten");
            dictionary.Add(6, "six");
            dictionary.Add(1, "one");
            dictionary.Add(14, "fourteen");
            dictionary.Add(4, "four");
            dictionary.Add(7, "seven");

            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[8];

            dictionary.CopyTo(array, 0);

            Assert.IsNotNull(array); ;
            Assert.AreEqual(array[0], new KeyValuePair<int, string>(1, "one")); ;
        }

        [TestMethod]
        public void TestGetValue()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            
            Assert.AreEqual("eight", dictionary[8]); ;
        }

        [TestMethod]
        public void TestSetValue()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary[8] = "eight";

            Assert.AreEqual("eight", dictionary[8]); ;
        }

        [TestMethod]
        public void TestGetKeys()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");

            var testList = dictionary.Keys;
            Assert.AreEqual(testList.Count, 2);
            Assert.IsTrue(testList.Contains(8)); ;
        }

        [TestMethod]
        public void TestGetValues()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");

            var testList = dictionary.Values;
            Assert.AreEqual(testList.Count, 2);
            Assert.IsTrue(testList.Contains("three")); ;
        }
    }
}

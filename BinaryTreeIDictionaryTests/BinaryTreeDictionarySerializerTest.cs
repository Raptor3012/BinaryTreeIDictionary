using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeIDictionary;
using Moq;
using System.IO;

namespace BinaryTreeIDictionaryTests
{
    [TestClass]
    public class BinaryTreeDictionarySerializerTest
    {
        [TestMethod]
        public void TestSerializeAndDeserialize()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(6, "six");
            dictionary.Add(4, "four");

            var name = "some-name";
            var stream = new MemoryStream();

            var storageMock = new Mock<IStorage>();
            storageMock.Setup(s => s.GetWriteStream(name))
                .Returns(stream);
            storageMock.Setup(s => s.GetReadStream(name))
                .Returns(stream);

            var serializer = new BinaryTreeDictionarySerializer(storageMock.Object);

            serializer.Save(name, dictionary, closeStream: false);
            stream.Position = 0;
            var newDictionary = serializer.Load<int, string>(name);

            Assert.AreEqual(dictionary.ToString(), newDictionary.ToString());
        }

        [TestMethod]
        public void TestSerialize()
        {
            var dictionary = new BinaryTreeDictionary<int, string>();
            dictionary.Add(8, "eight");
            dictionary.Add(3, "three");
            dictionary.Add(6, "six");
            dictionary.Add(4, "four");

            var name = "some-name";
            var stream = new MemoryStream();

            var storageMock = new Mock<IStorage>();
            storageMock.Setup(s => s.GetWriteStream(name))
                .Returns(stream);

            var serializer = new BinaryTreeDictionarySerializer(storageMock.Object);

            serializer.Save(name, dictionary, closeStream: false);
            stream.Position = 0;

            var serialized = Encoding.ASCII.GetString(stream.ToArray());

            Assert.AreEqual(dictionary.ToString(), serialized); ;
        }
    }
}

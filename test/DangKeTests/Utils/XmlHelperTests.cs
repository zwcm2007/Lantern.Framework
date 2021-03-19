using DangKeTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace DangKe.Utils.Tests
{
    [TestClass()]
    public class XmlHelperTests
    {
        [TestMethod()]
        public void ObjectToXmlSerializerTest()
        {
            var person = new Person { Id = 1, Name = "Fish Li" };
            string xml = person.ToXml(Encoding.UTF8);
            Console.WriteLine(xml);

            //Console.WriteLine("---------------------------------------");

            person = XmlHelper.FromXml<Person>(xml);
            Console.WriteLine("IntValue: " + person.Id.ToString());
            Console.WriteLine("StrValue: " + person.Name);

            ///
            //var str = @"<?xml version="1.0"?><Person><Id>1</Id><Name>冯珏庆</Name></Person>";

            //var person = XmlHelper.ObjectToXmlDESerializer<Person>(str);

            //Assert.IsTrue(person.Id == 1 && person.Name == "冯珏庆");
        }
    }
}
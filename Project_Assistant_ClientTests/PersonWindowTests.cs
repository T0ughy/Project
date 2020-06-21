using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Assistant_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assistant_Client.Tests
{
    [TestClass()]
    public class PersonWindowTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"Data\name.csv", "name#csv", DataAccessMethod.Sequential)]
        public void NameIsValidTest()
        {
            PersonWindow pw = new PersonWindow(null);
            string name = Convert.ToString(TestContext.DataRow["Name"].ToString());
            bool expected = Convert.ToBoolean(TestContext.DataRow["Expected"].ToString());
            bool result = pw.NameIsValid(name);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"Data\ssn.csv", "ssn#csv", DataAccessMethod.Sequential)]
        public void SocialSecurityNumberIsValid()
        {
            PersonWindow pw = new PersonWindow(null);
            string ssn = Convert.ToString(TestContext.DataRow["ssn"].ToString());
            bool expected = Convert.ToBoolean(TestContext.DataRow["expected"].ToString());
            bool result = pw.SocialSecurityNumberIsValid(ssn);
            Assert.AreEqual(expected, result);
        }
    }
}
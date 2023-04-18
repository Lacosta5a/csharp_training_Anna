using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Junior1", "Anna1");
            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.CheckContactPresence();

            app.Contact.Modify(0, newData);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[0].Name = newData.Name;
            oldContacts[0].Surname = newData.Surname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddingContact : AuthTestBase
    {
       
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i=0;i<5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20))
                {
                    Surname = GenerateRandomString(20)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void AddingContactTest(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData>newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts,newContacts);
        }
    }
}


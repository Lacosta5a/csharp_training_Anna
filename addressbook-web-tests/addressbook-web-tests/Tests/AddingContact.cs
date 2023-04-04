using System;
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
    public class AddingContact : TestBase
    {
       

        [Test]
        public void AddingContactTest()
        {
            ContactData contact = new ContactData("Anna", "Junior");

            app.Contact.Create(contact);
        }

        [Test]
        public void AddingEmptyContactTest()
        {
            ContactData contact = new ContactData("", "");

            app.Contact.Create(contact);
        }
    }
}


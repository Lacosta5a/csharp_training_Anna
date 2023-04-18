using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.DevTools.V108.Audits;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillInContactData(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            InitContactModification();
            FillInContactData(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(int v)
        {
            RemoveContact();
            return this;
        }

        public void CheckContactPresence()
        {
            manager.Navigator.ReturnToHomePage();

            if (IsElementPresent(By.Name("selected[]")))
            {
                return;
            }
            else
            {
                Create(new ContactData("aaa"));
            }
        }


        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }




        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

        public ContactHelper FillInContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Surname);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List <ContactData> contacts = new List<ContactData>();
            manager.Navigator.ReturnToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }
    }
}

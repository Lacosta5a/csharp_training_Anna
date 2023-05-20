using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests:AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(new GroupData("111"));
            }
            GroupData group = GroupData.GetAll()[0];

            if (ContactData.GetAll().Count == 0)
            {
                app.Contact.Create(new ContactData("Elena"));
            }

            app.Contact.CheckIfAllContactsIncluded();

            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

   

            app.Contact.AddContactToGroup(contact,group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}

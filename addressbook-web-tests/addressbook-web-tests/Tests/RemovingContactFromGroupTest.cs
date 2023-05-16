using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTest:AuthTestBase
    {
        [Test]

        public void TestRemovingContactFromGroup()
        {
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(new GroupData("111"));
            }
            GroupData group = GroupData.GetAll()[0];

            if (group.GetContacts().Count == 0)
            {
                if (ContactData.GetAll().Count == 0)
                {
                    app.Contact.Create(new ContactData("Elena"));
                    List<ContactData> list = ContactData.GetAll();
                    ContactData NewContact = list[0];
                    app.Contact.AddContactToGroup(NewContact, group);
                }
                ContactData ExistingContact = ContactData.GetAll().First();
                app.Contact.AddContactToGroup(ExistingContact, group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            app.Contact.CheckIfContactBelongsToGroup(contact, group);
            app.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);           
        }
    }
}

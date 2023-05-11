using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTest:AuthTestBase
    {
        [Test]

        public void TestRemovingContactFromGroup()
        {
            
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            app.Contact.CheckContactPresence();
            app.Groups.CheckGroupPresence();
            app.Contact.CheckIfContactBelongsToGroup(contact, group);

            app.Contact.RemoveContactFromGroup(contact,group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList,newList);
        }
    }
}

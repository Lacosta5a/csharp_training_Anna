using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
    
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.CheckGroupPresence();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);


            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData tobeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group. Id, tobeRemoved.Id);
            }
        }    
    }
}

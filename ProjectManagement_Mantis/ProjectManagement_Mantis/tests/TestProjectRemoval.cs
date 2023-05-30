using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace ProjectManagement_Mantis
{
    [TestFixture]
    public class TestProjectRemoval:AuthTestBase
    {
        [Test]
        public void ProjectRemoval()
        {
            app.Projects.CheckProjectPresence();

            MantisProjects.ProjectData[] oldProjects = app.Projects.GetProjectsList();

            app.Projects.Remove(0);

            MantisProjects.ProjectData[] newProjects = app.Projects.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

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
    public class TestNewProjectCreation:TestBase
    {
        [Test]
        public void ProjectCreation()
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            ProjectData newProject = new ProjectData("Test");


            app.Projects.Add(newProject);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

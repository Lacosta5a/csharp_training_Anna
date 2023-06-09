﻿using NUnit.Framework;
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
    public class TestNewProjectCreation:AuthTestBase
    {
        public static IEnumerable<ProjectData> RandomProjectNameProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for(int i = 0; i < 5; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(20)));
            }
            return projects;
        }

        [Test,TestCaseSource("RandomProjectNameProvider")]
        public void ProjectCreation(ProjectData project)
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Add(project);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

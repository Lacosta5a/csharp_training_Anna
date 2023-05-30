using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBrowser.WebDriver;
using System.Threading.Tasks;
using SimpleBrowser;
using OpenQA.Selenium.DevTools.V113.FedCm;

namespace ProjectManagement_Mantis
{
    public class ProjectsHelper:HelperBase
    {
        public ProjectsHelper(ApplicationManager manager) : base(manager)
        {

        }

        public MantisProjects.ProjectData[] GetProjectsList()
        {

            MantisProjects.MantisConnectPortTypeClient client = new MantisProjects.MantisConnectPortTypeClient();
            MantisProjects.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible("administrator", "root");
            foreach (MantisProjects.ProjectData project in mantisProjects)
            {
                project.Add(new ProjectData(project.name));
            }
            return mantisProjects;
        }

        public void Add(ProjectData project)
        {
            manager.Navigator.GoToManageProjectsPage();
            InitProjectCreation();
            FillInProjectForm(project);
            SubmitProjectCreation();
            return;
        }


        public ProjectsHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            return this;
        }

        public ProjectsHelper FillInProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            Type(By.Name("name"), project.Name);
            return this;
        }

        public ProjectsHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public void CheckProjectPresence()
        {
            manager.Navigator.GoToManageProjectsPage();
            if (IsElementPresent(By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]")))
            {
                return;
            }
            else
            {
                MantisProjects.MantisConnectPortTypeClient client = new MantisProjects.MantisConnectPortTypeClient();
                MantisProjects.ProjectData project = new MantisProjects.ProjectData();
                project.name = "*&^%$##GH";
                client.mc_project_add("administrator", "root", project);
            }

        }

        public ProjectsHelper Remove(int v)
        {
            driver.FindElement(By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;

        }
    }
}

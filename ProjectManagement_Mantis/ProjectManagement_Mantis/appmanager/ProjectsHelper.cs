using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Mantis
{
    public class ProjectsHelper:HelperBase
    {
        public ProjectsHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData>projects=new List<ProjectData>();

            manager.Navigator.GoToManageProjectsPage();
            ICollection<IWebElement> elements =driver.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]"));
            foreach(IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }
            return projects;
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
                Add(new ProjectData("*&^%$##GH"));
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

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
            CheckIfNameIsUnique(project.Name);
            SubmitProjectCreation();
            return;
        }

        public ProjectsHelper CheckIfNameIsUnique(string name)
        {
            throw new NotImplementedException();
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
    }
}

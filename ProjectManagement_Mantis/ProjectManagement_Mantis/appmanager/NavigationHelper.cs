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
    public class NavigationHelper : HelperBase
    {
        public string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL+ "/account_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToManageProjectsPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]/a/i")).Click();
            driver.Navigate().GoToUrl(baseURL+ "/manage_overview_page.php");
            driver.FindElement(By.LinkText("Manage Projects")).Click();
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }
    }
}

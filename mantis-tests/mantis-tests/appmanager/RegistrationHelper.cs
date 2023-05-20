using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper:HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm();
            SubmitRegistration();
        }

        public void OpenRegistrationForm()
        {
            driver.FindElement(By.LinkText("Signup for a new account")).Click();
        }

        public void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        public void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost:81/mantisbt-2.25.7/login_page.php";
        }
    }
}

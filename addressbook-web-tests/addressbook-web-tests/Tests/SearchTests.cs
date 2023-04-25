using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.DevTools.V108.Audits;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]

        public void TestSearch()
        {
            System.Console.Out.Write(app.Contact.GetNumberOfSearchResults());
        }
    }
}

using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager, string baseURL) : base(manager) 
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/mantisbt-2.25.4/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL+ "/mantisbt-2.25.4/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("#manage-user-delete-form .btn")).Click();
            driver.FindElement(By.CssSelector(".btn-white")).Click();
        }

        public bool IsAccountExists(AccountData account)
        {
            List<AccountData> accounts = GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                return true;
            }
            return false;
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "/mantisbt-2.25.4/login_page.php";
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[2]")).Click();
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("root");
            driver.FindElement(By.XPath("//input[3]")).Click();
            return driver;
        }
    }
}
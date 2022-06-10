using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) {}
        
        public void Create(AccountData account)
        {
            manager.James.Delete(account);
            manager.James.Add(account);
            manager.Registration.Register(account);
        }

        public void Login (string user, string password)
        {
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys(user);
            driver.FindElement(By.XPath("//input[2]")).Click();
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//input[3]")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.CssSelector(".fa:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector(".user-menu > li:nth-child(4) > a")).Click();
        }

    }
}
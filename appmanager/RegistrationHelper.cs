using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager){}

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("[href*='signup_page.php']")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://HomeServer:8080/mantisbt-2.25.4/login_page.php";
        }
        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }
    }
}
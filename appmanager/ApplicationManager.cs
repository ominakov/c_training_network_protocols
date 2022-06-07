using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://HomeServer:8080";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
        }

        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public RegistrationHelper Registration { get; set; }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance =  new ApplicationManager();
                newInstance.driver.Url = "http://HomeServer:8080/mantisbt-2.25.4/login_page.php";
                app.Value = newInstance;
            }
            return app.Value; 
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }
    }
}

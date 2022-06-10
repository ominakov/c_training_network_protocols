using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected readonly IWebDriver driver;
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
            Auth = new LoginHelper(this);
            Project = new ProjectManagementHelper(this);
            ManagementMenu = new ManagementMenuHelper(this);
            NavigationMenu = new MainMenuHelper(this);
            Navigator = new NavigationHelper(this, baseURL);
        }

        
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public RegistrationHelper Registration { get; set; }
        public LoginHelper Auth { get; set;  }
        public ProjectManagementHelper Project { get; set; }
        public ManagementMenuHelper ManagementMenu { get; set; }
        public MainMenuHelper NavigationMenu { get; set; }
        public NavigationHelper Navigator { get; set; }

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
                newInstance.Navigator.GoToHomePage();
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

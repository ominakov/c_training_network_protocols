using OpenQA.Selenium;
using System;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void Select(string menuItem)
        {
            switch (menuItem)
            {
                case "projectmanagement":
                    driver.FindElement(By.XPath("//a[contains(@href, '/manage_proj_page.php')]")).Click();
                    break;
                case "tags":
                    driver.FindElement(By.XPath("//a[contains(@href, '/manage_tags_page.php')]")).Click();
                    break;
                case "customfields":
                    driver.FindElement(By.XPath("//a[contains(@href, '/manage_custom_field_page.php')]")).Click();
                    break;
                case "profmenu":
                    driver.FindElement(By.XPath("//a[contains(@href, '/manage_prof_menu_page.php')]")).Click();
                    break;
                case "plugins":
                    driver.FindElement(By.XPath("//a[contains(@href, '/manage_plugin_page.php')]")).Click();
                    break;
                case "permissions":
                    driver.FindElement(By.XPath("//a[contains(@href, '/adm_permissions_report.php')]")).Click();
                    break;
            }
        }
    }
}

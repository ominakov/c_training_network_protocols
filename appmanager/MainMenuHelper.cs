using System;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class MainMenuHelper : HelperBase
    {
        public MainMenuHelper(ApplicationManager manager) : base(manager) { }

        public void NavigateTo(string menuItem)
        {
            switch (menuItem)
            {
                case "management":
                    driver.FindElement(By.CssSelector(".fa-gears")).Click();
                    break;
                case "overview":
                    driver.FindElement(By.CssSelector("li:nth-child(1) .menu-text")).Click();
                    break;
                case "taskList":
                    driver.FindElement(By.CssSelector("a > .fa-list-alt")).Click();
                    break;
                case "createTask":
                    driver.FindElement(By.CssSelector("li:nth-child(3) .menu-text")).Click();
                    break;
                case "journal":
                    driver.FindElement(By.CssSelector(".fa-road")).Click();
                    break;
                case "plan":
                    driver.FindElement(By.CssSelector(".fa-bar-chart-o")).Click();
                    break;
                case "subject":
                    driver.FindElement(By.CssSelector(".fa-gears")).Click();
                    break;
            }
        }
    }
}

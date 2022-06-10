using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }
        
        private List<ProjectData> projectCache = null;
        
        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.NavigationMenu.NavigateTo("management");
            manager.ManagementMenu.Select("projectmanagement");
            InitCreation();
            FillForm(project);
            SubmitCreation();
            return this;
        }

        public ProjectManagementHelper Remove()
        {
            manager.NavigationMenu.NavigateTo("management");
            manager.ManagementMenu.Select("projectmanagement");
            SelectProjectItem();
            InitRemoval();
            SubmitRemoval();
            return this;
        }

        private void InitRemoval()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
        }

        private void SubmitRemoval()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            projectCache = null;
        }

        private void SelectProjectItem()
        {
            driver.FindElement(By.XPath("//td/a")).Click();
        }

        public bool IsAnyProjectPresent()
        {
            manager.NavigationMenu.NavigateTo("management");
            manager.ManagementMenu.Select("projectmanagement");
            if (manager.Navigator.IsElementPresent(By.XPath("//td/a")))
            {
                return true;
            }
            return false;
        }

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.NavigationMenu.NavigateTo("management");
                manager.ManagementMenu.Select("projectmanagement");
                ICollection<IWebElement> elements = driver.FindElements(By.XPath
                    ("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr"));
                for (int i = 0; i < elements.Count-1; i++)
                {
                    projectCache.Add(new ProjectData(driver.FindElement(By.XPath("//tbody/tr["+(i+1)+"]/td[1]")).Text));
                }
            }
            return new List<ProjectData>(projectCache);
        }

        private void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            projectCache = null;
        }

        private void InitCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        private void FillForm(ProjectData project)
        {
            driver.FindElement(By.XPath("//input[@id='project-name']")).SendKeys(project.Name);
        }
    }
}

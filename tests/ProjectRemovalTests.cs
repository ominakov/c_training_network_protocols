using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            app.Auth.Login("administrator", "root");
            if (!app.Project.IsAnyProjectPresent())
            {
                ProjectData project = new ProjectData(GenerateRandomLatinString(5));
                app.Project.Create(project);
            }
            List<ProjectData> oldList = app.Project.GetProjectList();
            app.Project.Remove();
            oldList.RemoveAt(0);
            List<ProjectData> newList = app.Project.GetProjectList();
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
            app.Auth.Logout();
        }
       
        [Test]
        public void ProjectRemovalTestUsingAPI()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            if (!app.API.IsAnyProjectPresent(account))
            {
                ProjectData project = new ProjectData(GenerateRandomLatinString(5));
                app.API.Create(account, project);
            }
            List<ProjectData> oldList = app.API.GetProjectList(account);
            app.API.Remove(account, 0);
            oldList.RemoveAt(0);
            List<ProjectData> newList = app.API.GetProjectList(account);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

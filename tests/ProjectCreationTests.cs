using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData(GenerateRandomLatinString(5));
            app.Auth.Login("administrator", "root");
            List<ProjectData> oldList = app.Project.GetProjectList();
            app.Project.Create(project);
            oldList.Add(project);
            List<ProjectData> newList = app.Project.GetProjectList();
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
            app.Auth.Logout();
        }
        [Test]
        public void ProjectCreationTestUsingAPI()
        {
            ProjectData project = new ProjectData(GenerateRandomLatinString(5));
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            List<ProjectData> oldList = app.API.GetProjectList(account);
            app.API.Create(account, project);
            oldList.Add(project);
            List<ProjectData> newList = app.API.GetProjectList(account);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }}
}
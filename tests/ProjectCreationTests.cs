using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData("testProject11");
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
    }
}
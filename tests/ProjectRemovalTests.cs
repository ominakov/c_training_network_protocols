using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                ProjectData project = new ProjectData("NewProject");
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
    }
}

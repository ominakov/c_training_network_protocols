using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localfile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localfile);                
            }
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "test_user",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }
    }
}
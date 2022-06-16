using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
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
                Name = "testuser_" + GenerateRandomCyrillicString(5),
                Password = "password",
                Email = GenerateRandomCyrillicString(5) + "@localhost.localdomain"
            };
            app.Auth.Create(account);
        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }
    }
}
using System;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

        public static string GenerateRandomLatinString(int max)
        {
            StringBuilder builder = new StringBuilder();
            Char[] pwdChars = new Char[52] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < max; i++)
            {
                builder.Append(pwdChars[rnd.Next(0, 51)]);
            }
            return builder.ToString();
        }
        public static string GenerateRandomCyrillicString(int max)
        {
            StringBuilder builder = new StringBuilder();
            Char[] pwdChars = new Char[66] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
                'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ъ', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л',
                'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ъ', 'Э', 'Ю', 'Я' };
            for (int i = 0; i < max; i++)
            {
                builder.Append(pwdChars[rnd.Next(0, 65)]);
            }
            return builder.ToString();
        }

        public static string GenerateRandomNumericString(int max)
        {
            StringBuilder builder = new StringBuilder();
            Char[] pwdChars = new Char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < max; i++)
            {
                builder.Append(pwdChars[rnd.Next(0, 9)]);
            }
            return builder.ToString();
        }
    }
}

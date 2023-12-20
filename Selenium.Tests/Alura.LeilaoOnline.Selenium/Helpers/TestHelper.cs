using System.IO;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelper
    {
        public static string PastaDoExecutavel 
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string UrlBase
            => "http://localhost:5000";
    }
}
using System.IO;
using System.Text;

namespace _2048WinFormsApp
{
    public class FileProvider
    {
        public static void Append(string path, string value)
        {
            var writer = new StreamWriter(path, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        public static void Replace(string path, string value)
        {
            var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        public static string Show(string path)
        {
            var readResults = new StreamReader(path, Encoding.UTF8);
            var fileData = readResults.ReadToEnd();
            readResults.Close();
            return fileData;
        }

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}

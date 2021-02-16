using System;
using System.IO;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class MapSizeForm : Form
    {
        public int mapSize;
        private static string pathSize = "mapsize.txt";
        public MapSizeForm()
        {
            InitializeComponent();
           
        }
        public static int GetMapSize()
        {
            if (FileProvider.Exists(pathSize))
            {
                var reader = new StreamReader(pathSize);
                int size = Convert.ToInt32(reader.ReadLine());
                
                reader.Close();
                return size;
            }
            else
            {
                return 4;
            }
        }
        private void size4Button_Click(object sender, EventArgs e)
        {
            mapSize = 4;
            var writer = new StreamWriter(pathSize, false);
            writer.WriteLine(mapSize);
            writer.Close();
            Close();
        }

        private void size5Button_Click(object sender, EventArgs e)
        {
            mapSize = 5;
            var writer = new StreamWriter(pathSize, false);
            writer.WriteLine(mapSize);
            writer.Close();
            Close();
        }

        private void size6Button_Click(object sender, EventArgs e)
        {
            mapSize = 6;
            var writer = new StreamWriter(pathSize, false);
            writer.WriteLine(mapSize);
            writer.Close();
            Close();
        }
    }
}

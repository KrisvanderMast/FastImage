using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private const string PATH = @"C:\px\";
        private Stack<string> _images; // = new Stack<string>();
        private string _pathToCurrentImage;

        public Form1()
        {
            InitializeComponent();
            GetFiles();
            CreateSubfolders();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string key = e.KeyChar.ToString();
            var curFile = _pathToCurrentImage;

            string directoryName = Path.GetDirectoryName(_pathToCurrentImage);
            string fileName = Path.GetFileNameWithoutExtension(_pathToCurrentImage);
            string extension = Path.GetExtension(_pathToCurrentImage);
            string destination = Path.Combine(directoryName, key, $"{fileName}{extension}");

            try
            {
                File.Move(curFile, destination);
            }
            catch (Exception)
            {
                destination = Path.Combine(directoryName, key, $"{fileName}_{Guid.NewGuid()}{extension}");
                File.Move(curFile, destination);
            }

            if (_images.Count > 0)
            {
                ShowImage();
            }
        }

        private void GetFiles()
        {
            var ext = new List<string> { ".jpg", ".gif", ".png", ".jpeg" };
            var myFiles = Directory
                .EnumerateFiles(PATH, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => ext.Contains(Path.GetExtension(s).ToLowerInvariant()));

            _images = new Stack<string>(myFiles);

            if (_images.Count > 0)
            {
                ShowImage();
            }
        }

        private void CreateSubfolders()
        {
            var di = new DirectoryInfo(PATH);

            for (int i = 0; i < 10; i++)
            {
                di.CreateSubdirectory(i.ToString());
            }
        }

        private void ShowImage()
        {
            _pathToCurrentImage = _images.Pop();

            this.Text = $"{_images.Count} - {_pathToCurrentImage}";

            Image img;
            using (Image temp = Image.FromFile(_pathToCurrentImage))
            {
                img = new Bitmap(temp);
            }

            pictureBoxAll.Image = img;
        }
    }
}

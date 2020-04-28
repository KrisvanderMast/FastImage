using System;
using System.IO;
using System.Windows.Forms;

namespace FastImage
{
    public partial class ImageViewer : Form
    {
        private const string PATH = @"C:\px\";

        public ImageViewer()
        {
            InitializeComponent();
            GetFiles();
            CreateSubfolders();
        }

        private void GetFiles()
        {
            throw new NotImplementedException();
        }

        private void CreateSubfolders()
        {
            var di = new DirectoryInfo(PATH);

            for (int i = 0; i < 10; i++)
            {
                di.CreateSubdirectory(i.ToString());
            }
        }
    }
}

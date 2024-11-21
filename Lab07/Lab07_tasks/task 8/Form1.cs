using System;
using System.IO;
using System.Windows.Forms;

namespace lab07_task_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtLocation.Text = folderDialog.SelectedPath;
                    LoadImages(folderDialog.SelectedPath);
                }
            }
        }

        private void LoadImages(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.jpg");
            lblTotalPhotos.Text = "Total Photos: " + files.Length;

            if (files.Length > 0)
            {
                pictureBox.ImageLocation = files[0];  // Preview the first image
            }
        }
    }
}

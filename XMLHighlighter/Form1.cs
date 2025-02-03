using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO; 

namespace XMLHighlighter
{
    public partial class Form1 : Form
    {
        private TextBox inputPathTextBox = null!;
        private TextBox outputPathTextBox = null!;
        private Button inputBrowseButton = null!;
        private Button outputBrowseButton = null!;
        private Button processButton = null!;

        public Form1()
        {
            InitializeComponent();
        }

        private void InputBrowseButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputPathTextBox.Text = openFileDialog.FileName;


                    string directory = Path.GetDirectoryName(openFileDialog.FileName) ?? "";
                    string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    outputPathTextBox.Text = Path.Combine(directory, fileName + "_highlighted.html");
                }
            }
        }

        private void OutputBrowseButton_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "html";


                if (!string.IsNullOrEmpty(outputPathTextBox.Text))
                {
                    saveFileDialog.InitialDirectory = Path.GetDirectoryName(outputPathTextBox.Text);
                    saveFileDialog.FileName = Path.GetFileName(outputPathTextBox.Text);
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputPathTextBox.Text = saveFileDialog.FileName;
                }
            }
        }

        private void ProcessButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputPathTextBox.Text) || string.IsNullOrEmpty(outputPathTextBox.Text))
            {
                MessageBox.Show("Please select both input and output files.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("BLA BLA NE RADI JOS HEHE", "di si pozurija",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

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

            try
            {
                string inputText = File.ReadAllText(inputPathTextBox.Text);
                string highlightedHtml = HighlightXmlSyntax(inputText);
                File.WriteAllText(outputPathTextBox.Text, highlightedHtml);
                MessageBox.Show("File processed successfully!\nOutput saved to: " + outputPathTextBox.Text,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HighlightXmlSyntax(string input)
        {

            input = input.Replace("&", "&amp;")
                        .Replace("<", "&lt;")
                        .Replace(">", "&gt;");

            string highlighted = input;


            highlighted = Regex.Replace(highlighted,
                @"&lt;[\w/!?]+|/?&gt;",
                match => $"<span style='color: #0000FF'>{match.Value}</span>");


            highlighted = Regex.Replace(highlighted,
                @"(\s+[\w-]+)=(""[^""]*"")",
                match => $"<span style='color: #FF0000'>{match.Groups[1].Value}</span>=" +
                        $"<span style='color: #800000'>{match.Groups[2].Value}</span>");


            highlighted = Regex.Replace(highlighted,
                @"&lt;!--.*?--&gt;",
                match => $"<span style='color: #008000'>{match.Value}</span>",
                RegexOptions.Singleline);


            return $@"<!DOCTYPE html>
<html>
<head>
    <title>XML Highlighted</title>
    <style>
        body {{ 
            font-family: Consolas, monospace;
            background-color: #FFFFFF;
            padding: 20px;
            margin: 0;
        }}
        pre {{
            background-color: #F8F8F8;
            padding: 15px;
            border: 1px solid #E0E0E0;
            border-radius: 5px;
            margin: 0;
            white-space: pre-wrap;
            word-wrap: break-word;
        }}
        .container {{
            max-width: 1200px;
            margin: 0 auto;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <pre>{highlighted}</pre>
    </div>
</body>
</html>";
        }
    }
}
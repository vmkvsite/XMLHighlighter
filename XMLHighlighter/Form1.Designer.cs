namespace XMLHighlighter
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code



        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();


            Label inputLabel = new Label
            {
                Text = "Input File:",
                Location = new Point(10, 20),
                AutoSize = true
            };

            inputPathTextBox = new TextBox
            {
                Location = new Point(10, 40),
                Size = new Size(450, 20),
                ReadOnly = true
            };

            inputBrowseButton = new Button
            {
                Text = "📁",
                Location = new Point(470, 38),
                Size = new Size(30, 23)
            };
            inputBrowseButton.Click += new EventHandler(InputBrowseButton_Click);


            Label outputLabel = new Label
            {
                Text = "Output File:",
                Location = new Point(10, 70),
                AutoSize = true
            };

            outputPathTextBox = new TextBox
            {
                Location = new Point(10, 90),
                Size = new Size(450, 20),
                ReadOnly = true
            };

            outputBrowseButton = new Button
            {
                Text = "📁",
                Location = new Point(470, 88),
                Size = new Size(30, 23)
            };
            outputBrowseButton.Click += new EventHandler(OutputBrowseButton_Click);

            processButton = new Button
            {
                Text = "Convert file",
                Location = new Point(10, 120),
                Size = new Size(100, 30)
            };
            processButton.Click += new EventHandler(ProcessButton_Click);


            this.Controls.AddRange(new Control[] {
                inputLabel,
                inputPathTextBox,
                inputBrowseButton,
                outputLabel,
                outputPathTextBox,
                outputBrowseButton,
                processButton
            });

            this.Text = "XMLHighlighter";
            this.Size = new Size(600, 200);
        }

        #endregion
    }
}
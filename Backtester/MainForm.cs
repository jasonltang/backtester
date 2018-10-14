using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Backtester
{
    interface IMainForm
    {
        string GetInput();
    }

    class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            TextBoxWriter.SetTextBox(outputTextBox);
            WriteIntroText();
            inputTextBox.Select();
        }

        private TextBox outputTextBox;
        private TextBox inputTextBox;
        private Label inputBoxDescription;
        private Button submitButton;

        private void InitializeComponent()
        {
            this.submitButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputBoxDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(241, 51);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Simulate";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(12, 89);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(550, 450);
            this.outputTextBox.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(133, 25);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(300, 20);
            this.inputTextBox.TabIndex = 2;
            // 
            // inputBoxDescription
            // 
            this.inputBoxDescription.AutoSize = true;
            this.inputBoxDescription.Location = new System.Drawing.Point(229, 9);
            this.inputBoxDescription.Name = "inputBoxDescription";
            this.inputBoxDescription.Size = new System.Drawing.Size(101, 13);
            this.inputBoxDescription.TabIndex = 3;
            this.inputBoxDescription.Text = "Enter filename here:";
            // 
            // MainForm
            // 
            this.AcceptButton = this.submitButton;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.inputBoxDescription);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.submitButton);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string GetInput()
        {
            return inputTextBox.Text;
        }

        private void WriteIntroText()
        {
            TextBoxWriter.WriteMessage($"Please enter the name of the csv file containing the market data.\r\n" +
            $"If nothing is entered, the default is {CsvDataReader.DefaultFileName}");
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (!CsvDataReader.ValidateAndSetFileName(this, out string filename))
            {
                return;
            }
            IDataReader dataReader = new CsvDataReader(filename);
            IStrategy strategy = new TestStrategy();
            ISimulator simulator = new ConcreteSimulator(dataReader, strategy);
            simulator.Simulate(printTrades:true, printPnl:true);
        }
    }
}

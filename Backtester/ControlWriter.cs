using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Backtester
{
    public static class TextBoxWriter
    {
        private static TextBox _textBox;

        public static void SetTextBox(TextBox textBox)
        {
            _textBox = textBox;
        }

        public static void WriteLine()
        {
            _textBox.AppendText($"\r\n");
        }

        public static void WriteLine(string value)
        {
            _textBox.AppendText ($"{value}\r\n");
        }

        public static void WriteMessage(string value)
        {
            _textBox.AppendText($"{value}\r\n\r\n");
        }
    }
}

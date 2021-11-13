using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RPP_task_02
{
    /// <summary>
    /// A class that implements the display of buttons and text fields.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// A class constructor that implements component initialization.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog ofd = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            ofd.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            ofd.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                ofd.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                richTextBox1.LoadFile(ofd.FileName);
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void SaveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName);
            }
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            RTBMod.FindWord(richTextBox1, textBox1);
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            RTBMod.ReplaceWord(richTextBox1, textBox1, textBox2);
        }
    }

    /// <summary>
    /// A class that allows you to search for and replace words in a text box.
    /// </summary>
    public static class RTBMod
    {
        /// <summary>
        /// A method that implements the replacement of words in a text box.
        /// </summary>
        /// <param name="rtb">Rich text box.</param>
        /// <param name="textBox1">First text box.</param>
        /// <param name="textBox2">Second text box.</param>
        /// <returns></returns>
        public static RichTextBox ReplaceWord(RichTextBox rtb, TextBox textBox1, TextBox textBox2)
        {
            if (rtb.Text != string.Empty && textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                rtb.Text = rtb.Text.Replace(textBox1.Text, textBox2.Text);
            }
            return rtb;
        }
        /// <summary>
        /// A method that implements the search for words in a text box.
        /// </summary>
        /// <param name="rtb">Rich text box.</param>
        /// <param name="textBox">Text box.</param>
        /// <returns></returns>
        public static RichTextBox FindWord(RichTextBox rtb, TextBox textBox)
        {
            if (rtb.Text != string.Empty && textBox.Text != string.Empty)
            {
                int index = 0;
                rtb.SelectAll();
                rtb.SelectionColor = Color.Black;

                while (index <= rtb.Text.Length - textBox.Text.Length)
                {
                    index = rtb.Text.IndexOf(textBox.Text, index);
                    if (index < 0) break;
                    rtb.SelectionStart = index;
                    rtb.SelectionLength = textBox.Text.Length;
                    rtb.SelectionColor = Color.Blue;
                    index += textBox.Text.Length;
                }
            }
            return rtb;
        }
    }
}

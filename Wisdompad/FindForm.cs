using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wisdompad
{
    public partial class FindForm : Form
    {
        private RichTextBox rtbText;

        public FindForm(RichTextBox rtb)
        {
            InitializeComponent();
            rtbText = rtb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string findText = txtFind.Text;
                if (!string.IsNullOrEmpty(findText))
                {
                    int startIndex = rtbText.SelectionStart + rtbText.SelectionLength;
                    if (startIndex >= rtbText.TextLength)
                    {
                        startIndex = 0; // Start from the beginning if we are at the end
                    }

                    int wordStartIndex = rtbText.Find(findText, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex == -1 && startIndex != 0)
                    {
                        // If not found, start from the beginning
                        wordStartIndex = rtbText.Find(findText, 0, RichTextBoxFinds.None);
                    }

                    if (wordStartIndex != -1)
                    {
                        rtbText.Select(wordStartIndex, findText.Length);
                        rtbText.ScrollToCaret();
                    }
                    else
                    {
                        MessageBox.Show("Text not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter text to find.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while finding the text: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                string findText = txtFind.Text;
                if (string.IsNullOrEmpty(findText))
                {
                    MessageBox.Show("Please enter the text to find.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int startIndex = rtbText.SelectionStart - 1; // Start searching from just before the current selection

                if (startIndex < 0)
                {
                    startIndex = rtbText.TextLength - 1; // Start from the end if we are at the beginning
                }

                int wordStartIndex = rtbText.Find(findText, 0, startIndex, RichTextBoxFinds.Reverse);
                if (wordStartIndex != -1)
                {
                    rtbText.Select(wordStartIndex, findText.Length);
                    rtbText.ScrollToCaret();
                }
                else
                {
                    MessageBox.Show("Text not found.", "Find Previous",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while finding the text: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

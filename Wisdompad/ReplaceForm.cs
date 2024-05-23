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
    public partial class ReplaceForm : Form
    {
        private RichTextBox rtbText;

        public ReplaceForm(RichTextBox rtb)
        {
            InitializeComponent();
            rtbText = rtb;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                string findText = txtFind.Text;
                if (!string.IsNullOrEmpty(findText))
                {
                    int startIndex = rtbText.SelectionStart + rtbText.SelectionLength;
                    if (startIndex >= rtbText.TextLength)
                    {
                        startIndex = 0;
                    }

                    int wordStartIndex = rtbText.Find(findText, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex == -1 && startIndex != 0)
                    {
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

        private void btnReplace_Click(object sender, EventArgs e)
        {

            try
            {
                string findText = txtFind.Text;
                string replaceText = txtReplaceWith.Text;

                if (string.IsNullOrEmpty(findText))
                {
                    MessageBox.Show("Please enter the text to find.", "Find",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rtbText.SelectionLength > 0 && rtbText.SelectedText.Equals(findText))
                {
                    rtbText.SelectedText = replaceText;
                }
                else
                {
                    int startIndex = rtbText.SelectionStart + rtbText.SelectionLength;
                    if (startIndex >= rtbText.TextLength)
                    {
                        startIndex = 0; 
                    }

                    int wordStartIndex = rtbText.Find(findText, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex == -1 && startIndex != 0)
                    {
                        wordStartIndex = rtbText.Find(findText, 0, RichTextBoxFinds.None);
                    }

                    if (wordStartIndex != -1)
                    {
                        rtbText.Select(wordStartIndex, findText.Length);
                        rtbText.SelectedText = replaceText;
                        rtbText.ScrollToCaret();
                    }
                    else
                    {
                        MessageBox.Show("Text not found.", "Find",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while replacing text: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            try
            {
                string findText = txtFind.Text;
                string replaceText = txtReplaceWith.Text;

                if (string.IsNullOrEmpty(findText))
                {
                    MessageBox.Show("Please enter the text to find.", "Find",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int startIndex = 0;
                int foundIndex;
                bool foundAny = false;

                while ((foundIndex = rtbText.Find(findText, startIndex, RichTextBoxFinds.None)) != -1)
                {
                    rtbText.Select(foundIndex, findText.Length);
                    rtbText.SelectedText = replaceText;
                    startIndex = foundIndex + replaceText.Length;
                    foundAny = true;
                }
                if (foundAny)
                {
                    MessageBox.Show("All occurrences replaced.", "Replace All",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Text not found.", "Replace All",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while replacing text: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string findText = txtFind.Text;
                if (string.IsNullOrEmpty(findText))
                {
                    MessageBox.Show("Please enter the text to find.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int startIndex = rtbText.SelectionStart - 1; 

                if (startIndex < 0)
                {
                    startIndex = rtbText.TextLength - 1; 
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
    }
}

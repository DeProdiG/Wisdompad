using System.Windows.Forms;

namespace Wisdompad
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rtbText.TextChanged += rtbText_TextChanged;
            this.FormClosing += Form1_FormClosing;
            UpdateUndoRedoStatus();
        }
        /* Глобална променлива за File Menu*/
        string filePath = "";
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:/";
            openFileDialog1.Title = "Opening a text file!";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text files|*.txt|Word|*.doc|XML Document|*.docx|RTF files|*.rtf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = openFileDialog1.FileName;
                    rtbText.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                    statusLabel.Text = "Loaded file: " + filePath;
                }
                catch (FileNotFoundException) /*Улавя случаи, когато файлът не може да бъде намерен.*/
                {
                    MessageBox.Show("File not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException) /*: Улавя случаи на липса на права за достъп до файла.*/
                {
                    MessageBox.Show("You don't currently have the permission to access this file.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex) /*Улавя грешки при четене на файла (включително проблеми със самия файл).*/
                {
                    MessageBox.Show("Error reading from the file:" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) /*Улавя всички други неочаквани изключения.*/
                {
                    MessageBox.Show("An unexpected error occurred:" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateUndoRedoStatus()
        {
            undoToolStripMenuItem.Enabled = rtbText.CanUndo;
            undoToolStripMenuItem1.Enabled = rtbText.CanUndo;
            redoToolStripMenuItem.Enabled = rtbText.CanRedo;
            redoToolStripMenuItem1.Enabled = rtbText.CanRedo;
            undoBtn.Enabled = rtbText.CanUndo;
            redoBtn.Enabled = rtbText.CanRedo;
        }
        private void rtbText_TextChanged(object sender, EventArgs e)
        {
            UpdateUndoRedoStatus();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbText.CanUndo)
                {
                    rtbText.Undo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to undo: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateUndoRedoStatus();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbText.CanRedo)
                {
                    rtbText.Redo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to redo: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateUndoRedoStatus();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Paste();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasUnsavedChanges = false;

                // Проверка за незаписани промени
                if (string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(rtbText.Text))
                {
                    hasUnsavedChanges = true;
                }
                else if (!string.IsNullOrEmpty(filePath))
                {
                    string currentFileContent = File.ReadAllText(filePath);
                    if (!rtbText.Text.Equals(currentFileContent))
                    {
                        hasUnsavedChanges = true;
                    }
                }

                // Ако има незаписани промени, попитайте потребителя дали иска да ги запази
                if (hasUnsavedChanges)
                {
                    DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before creating a new document?",
                        "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                        if (string.IsNullOrEmpty(filePath)) // ако запазването е отменено
                        {
                            return;
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // Изчистване на съдържанието за нов документ
                rtbText.Clear();
                filePath = string.Empty;
                statusLabel.Text = "New file made.";

                // Обновяване на заглавието на формата
                this.Text = "Untitled - Text Editor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating a new document: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            using (Author authorForm = new Author())
            {
                authorForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasUnsavedChanges = false;
                if (string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(rtbText.Text))
                {
                    hasUnsavedChanges = true;
                }
                else if (!string.IsNullOrEmpty(filePath))
                {
                    string currentFileContent = File.ReadAllText(filePath);
                    if (!rtbText.Text.Equals(currentFileContent))
                    {
                        hasUnsavedChanges = true;
                    }
                }

                if (hasUnsavedChanges)
                {
                    DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before exiting?",
                        "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                        if (string.IsNullOrEmpty(filePath)) // if save was cancelled
                        {
                            return;
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    DialogResult result1 = MessageBox.Show("Are you sure you want to close the program?",
                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result1 == DialogResult.No)
                    {
                        return;
                    }
                }
                Application.Exit();
                using (Author authorForm = new Author())
                {
                    authorForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to exit the application: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    saveFileDialog1.Filter = "Text files|*.txt|Word|*.doc|XML Document|*.docx|RTF files|*.rtf";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog1.FileName;
                        File.WriteAllText(filePath, rtbText.Text);
                        statusLabel.Text = "File saved as: " + filePath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (filePath == "")
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    File.WriteAllText(filePath, rtbText.Text);
                    statusLabel.Text = "File saved in: " + filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.SelectAll();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem_Click(sender, e);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (rtbText.SelectionLength > 0)
                {
                    rtbText.SelectionFont = fontDialog1.Font;
                }
                else
                {
                    rtbText.Font = fontDialog1.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (rtbText.SelectionLength > 0)
                {
                    rtbText.SelectionColor = colorDialog1.Color;
                }
                else
                {
                    rtbText.ForeColor = colorDialog1.Color;
                }
            }
        }

        private void clearFormattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectionLength > 0)
            {
                // Ако е избран текст, променяме форматирането само на избрания текст
                int selectionStart = rtbText.SelectionStart;
                int selectionLength = rtbText.SelectionLength;

                // Изтриваме форматирането на избрания текст
                rtbText.SelectionFont = rtbText.Font;
                rtbText.SelectionColor = rtbText.ForeColor;

                // Възстановяваме позицията и дължината на избрания текст
                rtbText.Select(selectionStart, selectionLength);
            }
            else
            {
                // Ако няма избран текст, променяме форматирането на целия текст
                rtbText.SelectAll();
                rtbText.SelectionFont = rtbText.Font;
                rtbText.SelectionColor = rtbText.ForeColor;
            }

            // Премахваме избора на текст, за да не се селектира нищо след изтриването на форматирането
            rtbText.SelectionLength = 0;
        }

        private void italicBtn_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Italic);
        }

        private void boldBtn_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Bold);
        }

        private void underlineBtn_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Underline);
        }

        private void ChangeFontStyle(FontStyle style)
        {
            if (rtbText.SelectionLength > 0)
            {
                Font currentFont = rtbText.SelectionFont;
                FontStyle newFontStyle;

                if (currentFont.Style.HasFlag(style))
                {
                    newFontStyle = currentFont.Style & ~style;
                }
                else
                {
                    newFontStyle = currentFont.Style | style;
                }

                rtbText.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rtbText_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearFormattingToolStripMenuItem_Click(sender, e);
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void redoBtn_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
        }

        private void ChangeBackColor()
        {
            try
            {
                if (colorDialog2.ShowDialog() == DialogResult.OK)
                {
                    rtbText.BackColor = colorDialog2.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to change the background color: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void changeBackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackColor();
        }

        private void shortDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.AppendText(DateTime.Now.ToShortDateString());
        }

        private void longDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.AppendText(DateTime.Now.ToLongDateString());
        }

        private void shortTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.AppendText(DateTime.Now.ToShortTimeString());
        }

        private void longTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.AppendText(DateTime.Now.ToLongTimeString());
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReplaceForm replaceForm = new ReplaceForm(rtbText))
            {
                replaceForm.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FindForm findForm = new FindForm(rtbText))
            {
                findForm.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enjoy my Wisdompad Editor Pro! :D",
            "Wisdompad Editor Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            using (Author authorForm = new Author())
            {
                authorForm.ShowDialog();
            }
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Italic);
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Bold);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFontStyle(FontStyle.Underline);
        }

        private void helpToolStripButton_Click_1(object sender, EventArgs e)
        {
            using (AuthorAbout authorForm = new AuthorAbout())
            {
                authorForm.ShowDialog();
            }
        }
    }
}

namespace Wisdompad
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            txtFind = new TextBox();
            lblFind = new Label();
            btnFindNext = new Button();
            btnFindPrevious = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtFind
            // 
            txtFind.Location = new Point(64, 61);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(134, 23);
            txtFind.TabIndex = 4;
            // 
            // lblFind
            // 
            lblFind.AutoSize = true;
            lblFind.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFind.Location = new Point(15, 61);
            lblFind.Name = "lblFind";
            lblFind.Size = new Size(43, 21);
            lblFind.TabIndex = 3;
            lblFind.Text = "Find:";
            // 
            // btnFindNext
            // 
            btnFindNext.Font = new Font("Segoe UI", 10F);
            btnFindNext.Location = new Point(229, 12);
            btnFindNext.Name = "btnFindNext";
            btnFindNext.Size = new Size(106, 37);
            btnFindNext.TabIndex = 5;
            btnFindNext.Text = "Find next";
            btnFindNext.UseVisualStyleBackColor = true;
            btnFindNext.Click += button1_Click;
            // 
            // btnFindPrevious
            // 
            btnFindPrevious.Font = new Font("Segoe UI", 10F);
            btnFindPrevious.Location = new Point(229, 57);
            btnFindPrevious.Name = "btnFindPrevious";
            btnFindPrevious.Size = new Size(106, 37);
            btnFindPrevious.TabIndex = 6;
            btnFindPrevious.Text = "Find previous";
            btnFindPrevious.UseVisualStyleBackColor = true;
            btnFindPrevious.Click += btnFindPrevious_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(229, 100);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 37);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FindForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 160);
            Controls.Add(btnCancel);
            Controls.Add(btnFindPrevious);
            Controls.Add(btnFindNext);
            Controls.Add(txtFind);
            Controls.Add(lblFind);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FindForm";
            Text = "FindForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFind;
        private Label lblFind;
        private Button btnFindNext;
        private Button btnFindPrevious;
        private Button btnCancel;
    }
}
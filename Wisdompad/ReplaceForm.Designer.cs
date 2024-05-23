namespace Wisdompad
{
    partial class ReplaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceForm));
            lblFind = new Label();
            lblReplaceWith = new Label();
            txtFind = new TextBox();
            txtReplaceWith = new TextBox();
            btnFindNext = new Button();
            btnReplace = new Button();
            btnReplaceAll = new Button();
            btnCancel = new Button();
            btnFindPrevious = new Button();
            SuspendLayout();
            // 
            // lblFind
            // 
            lblFind.AutoSize = true;
            lblFind.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFind.Location = new Point(74, 59);
            lblFind.Name = "lblFind";
            lblFind.Size = new Size(43, 21);
            lblFind.TabIndex = 0;
            lblFind.Text = "Find:";
            // 
            // lblReplaceWith
            // 
            lblReplaceWith.AutoSize = true;
            lblReplaceWith.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReplaceWith.Location = new Point(16, 126);
            lblReplaceWith.Name = "lblReplaceWith";
            lblReplaceWith.Size = new Size(101, 21);
            lblReplaceWith.TabIndex = 1;
            lblReplaceWith.Text = "Replace with:";
            // 
            // txtFind
            // 
            txtFind.Location = new Point(123, 59);
            txtFind.Name = "txtFind";
            txtFind.Size = new Size(134, 23);
            txtFind.TabIndex = 2;
            // 
            // txtReplaceWith
            // 
            txtReplaceWith.Location = new Point(123, 126);
            txtReplaceWith.Name = "txtReplaceWith";
            txtReplaceWith.Size = new Size(134, 23);
            txtReplaceWith.TabIndex = 3;
            // 
            // btnFindNext
            // 
            btnFindNext.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFindNext.Location = new Point(274, 12);
            btnFindNext.Name = "btnFindNext";
            btnFindNext.Size = new Size(97, 32);
            btnFindNext.TabIndex = 4;
            btnFindNext.Text = "Find next";
            btnFindNext.UseVisualStyleBackColor = true;
            btnFindNext.Click += btnFindNext_Click;
            // 
            // btnReplace
            // 
            btnReplace.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReplace.Location = new Point(274, 88);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(97, 32);
            btnReplace.TabIndex = 5;
            btnReplace.Text = "Replace";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += btnReplace_Click;
            // 
            // btnReplaceAll
            // 
            btnReplaceAll.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReplaceAll.Location = new Point(274, 126);
            btnReplaceAll.Name = "btnReplaceAll";
            btnReplaceAll.Size = new Size(97, 32);
            btnReplaceAll.TabIndex = 6;
            btnReplaceAll.Text = "Replace all";
            btnReplaceAll.UseVisualStyleBackColor = true;
            btnReplaceAll.Click += btnReplaceAll_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(274, 164);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 32);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnFindPrevious
            // 
            btnFindPrevious.Font = new Font("Segoe UI", 9.75F);
            btnFindPrevious.Location = new Point(274, 50);
            btnFindPrevious.Name = "btnFindPrevious";
            btnFindPrevious.Size = new Size(97, 32);
            btnFindPrevious.TabIndex = 8;
            btnFindPrevious.Text = "Find previous";
            btnFindPrevious.UseVisualStyleBackColor = true;
            btnFindPrevious.Click += button1_Click;
            // 
            // ReplaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 206);
            Controls.Add(btnFindPrevious);
            Controls.Add(btnCancel);
            Controls.Add(btnReplaceAll);
            Controls.Add(btnReplace);
            Controls.Add(btnFindNext);
            Controls.Add(txtReplaceWith);
            Controls.Add(txtFind);
            Controls.Add(lblReplaceWith);
            Controls.Add(lblFind);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReplaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReplaceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFind;
        private Label lblReplaceWith;
        private TextBox txtFind;
        private TextBox txtReplaceWith;
        private Button btnFindNext;
        private Button btnReplace;
        private Button btnReplaceAll;
        private Button btnCancel;
        private Button btnFindPrevious;
    }
}
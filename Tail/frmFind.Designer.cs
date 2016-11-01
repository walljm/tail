namespace Tail
{
    partial class frmFind
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radLabel1 = new System.Windows.Forms.Label();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radLabel2 = new System.Windows.Forms.Label();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(70, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(444, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 14);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(60, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Find what:";
            // 
            // rbDown
            // 
            this.rbDown.Checked = true;
            this.rbDown.Location = new System.Drawing.Point(125, 44);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(53, 18);
            this.rbDown.TabIndex = 2;
            this.rbDown.TabStop = true;
            this.rbDown.Text = "Down";
            // 
            // rbUp
            // 
            this.rbUp.Location = new System.Drawing.Point(78, 44);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(46, 18);
            this.rbUp.TabIndex = 3;
            this.rbUp.Text = "Up";
            // 
            // btnFindNext
            // 
            this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindNext.Location = new System.Drawing.Point(419, 40);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(95, 24);
            this.btnFindNext.TabIndex = 5;
            this.btnFindNext.Text = "Find Next";
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(318, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(15, 45);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Direction: ";
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.Checked = true;
            this.chkIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreCase.Location = new System.Drawing.Point(182, 44);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(84, 18);
            this.chkIgnoreCase.TabIndex = 7;
            this.chkIgnoreCase.Text = "Ignore Case?";
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 76);
            this.Controls.Add(this.chkIgnoreCase);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.rbUp);
            this.Controls.Add(this.rbDown);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtSearch);
            this.KeyPreview = true;
            this.Name = "frmFind";
            this.ShowIcon = false;
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private  System.Windows.Forms.Label radLabel1;
        private  System.Windows.Forms.RadioButton rbDown;
        private  System.Windows.Forms.RadioButton rbUp;
        private  System.Windows.Forms.Button btnFindNext;
        private  System.Windows.Forms.Button btnCancel;
        private  System.Windows.Forms.Label radLabel2;
        private  System.Windows.Forms.CheckBox chkIgnoreCase;
    }
}
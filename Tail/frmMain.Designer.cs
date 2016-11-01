namespace Tail
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numLines = new System.Windows.Forms.NumericUpDown();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.syntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLines)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numLines);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectFile);
            this.splitContainer1.Panel1.Controls.Add(this.txtFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.syntaxBox);
            this.splitContainer1.Size = new System.Drawing.Size(890, 668);
            this.splitContainer1.SplitterDistance = 26;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(778, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lines:";
            // 
            // numLines
            // 
            this.numLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLines.Location = new System.Drawing.Point(819, 4);
            this.numLines.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numLines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLines.Name = "numLines";
            this.numLines.Size = new System.Drawing.Size(66, 20);
            this.numLines.TabIndex = 2;
            this.numLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLines.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numLines.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(731, 2);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(41, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 4);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(685, 20);
            this.txtFile.TabIndex = 0;
            // 
            // syntaxBox
            // 
            this.syntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBox.AllowBreakPoints = false;
            this.syntaxBox.AutoListPosition = null;
            this.syntaxBox.AutoListSelectedText = "a123";
            this.syntaxBox.AutoListVisible = false;
            this.syntaxBox.BackColor = System.Drawing.Color.White;
            this.syntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBox.CopyAsRTF = false;
            this.syntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxBox.Document = this.syntaxDocument1;
            this.syntaxBox.FontName = "Consolas";
            this.syntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBox.InfoTipCount = 1;
            this.syntaxBox.InfoTipPosition = null;
            this.syntaxBox.InfoTipSelectedIndex = 1;
            this.syntaxBox.InfoTipVisible = false;
            this.syntaxBox.Location = new System.Drawing.Point(0, 0);
            this.syntaxBox.LockCursorUpdate = false;
            this.syntaxBox.Name = "syntaxBox";
            this.syntaxBox.ReadOnly = true;
            this.syntaxBox.ShowGutterMargin = false;
            this.syntaxBox.ShowScopeIndicator = false;
            this.syntaxBox.Size = new System.Drawing.Size(890, 638);
            this.syntaxBox.SmoothScroll = true;
            this.syntaxBox.SplitView = false;
            this.syntaxBox.SplitviewH = -4;
            this.syntaxBox.SplitviewV = -4;
            this.syntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBox.TabIndex = 0;
            this.syntaxBox.Text = "syntaxTextBox";
            this.syntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.ReadOnly = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 668);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Tail";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numLines;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBox;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
    }
}


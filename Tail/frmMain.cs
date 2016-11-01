using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tail
{
    public partial class frmMain : Form
    {
        private readonly double _height;

        public frmMain()
        {
            InitializeComponent();

            //set font, size & style
            var f = new Font(syntaxBox.FontName, syntaxBox.FontSize);

            //create a bmp / graphic to use MeasureString on
            var b = new Bitmap(2200, 2200);
            var g = Graphics.FromImage(b);

            //measure the string
            var sizeOfString = new SizeF();
            sizeOfString = g.MeasureString("This is a text line", f);

            //use:
            _height = sizeOfString.Height - 1.5;
        }

        #region Status Log Search

        private frmFind _frmFind;

        private void _frmFind_FoundText(object sender, FoundTextEventHandlerArgs e)
        {
            Invoke(new Action(() =>
            {
                syntaxBox.GotoLine(e.Position);
                syntaxBox.ScrollIntoView(e.Position);
                syntaxBox.HighLightActiveLine = true;
            }));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg != WM_KEYDOWN) && (msg.Msg != WM_SYSKEYDOWN)) return base.ProcessCmdKey(ref msg, keys);

            switch (keys)
            {
                case Keys.Control | Keys.F:

                    if (_frmFind == null)
                    {
                        _frmFind = new frmFind(syntaxDocument1.Lines);
                        _frmFind.FoundText += _frmFind_FoundText;
                        _frmFind.FormClosed += (s, args) => { _frmFind = null; syntaxBox.HighLightActiveLine = false; };
                    }
                    _frmFind.Show(this);
                    break;

                case Keys.F3:
                    _frmFind?.FindNext();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keys);
        }

        #endregion Status Log Search

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
                // Create a new FileSystemWatcher and set its properties.
                var watcher = new FileSystemWatcher
                {
                    Path = Path.GetDirectoryName(ofd.FileName),
                    NotifyFilter = NotifyFilters.LastWrite,
                    Filter = Path.GetFileName(ofd.FileName)
                };

                // Add event handlers.
                watcher.Changed += statusLogWatcher_Changed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;
                setStatusLog(ofd.FileName);
            }
        }

        private void statusLogWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            setStatusLog(e.FullPath);
        }

        private void setStatusLog(string path)
        {
            using (var st = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                var lines = tail(st, Convert.ToInt32(numLines.Value));
                var h = Convert.ToInt32(syntaxBox.Height / _height);
                Invoke(new Action(() =>
                {
                    syntaxBox.Document.Text = string.Join("\r\n", lines);

                    if (lines.Length <= h + 1) return;

                    syntaxBox.GotoLine(lines.Length - 1);
                    syntaxBox.ScrollIntoView(lines.Length - h);
                }));
            }
        }

        ///<summary>Returns the end of a text reader.</summary>
        ///<param name="reader">The reader to read from.</param>
        ///<param name="lineCount">The number of lines to return.</param>
        ///<returns>The last lneCount lines from the reader.</returns>
        private static string[] tail(TextReader reader, int lineCount)
        {
            var buffer = new List<string>(lineCount);
            string line;
            for (var i = 0; i < lineCount; i++)
            {
                line = reader.ReadLine();
                if (line == null) return buffer.ToArray();
                buffer.Add(line);
            }

            var lastLine = lineCount - 1;           //The index of the last line read from the buffer.  Everything > this index was read earlier than everything <= this indes

            while (null != (line = reader.ReadLine()))
            {
                lastLine++;
                if (lastLine == lineCount) lastLine = 0;
                buffer[lastLine] = line;
            }

            if (lastLine == lineCount - 1) return buffer.ToArray();
            var retVal = new string[lineCount];
            buffer.CopyTo(lastLine + 1, retVal, 0, lineCount - lastLine - 1);
            buffer.CopyTo(0, retVal, lineCount - lastLine - 1, lastLine + 1);
            return retVal;
        }
    }
}
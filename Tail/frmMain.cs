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

            if ((msg.Msg != WM_KEYDOWN) && (msg.Msg != WM_SYSKEYDOWN))
                return base.ProcessCmdKey(ref msg, keys);

            switch (keys)
            {
                case Keys.Control | Keys.F:

                    launchFindForm();
                    break;

                case Keys.F3:
                    _frmFind?.FindNext();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keys);
        }

        private void launchFindForm()
        {
            if (_frmFind == null)
            {
                _frmFind = new frmFind(syntaxDocument1.Lines);
                _frmFind.FoundText += _frmFind_FoundText;
                _frmFind.FormClosed += (s, args) =>
                {
                    _frmFind = null;
                    syntaxBox.HighLightActiveLine = false;
                };
            }
            _frmFind.Show(this);
        }

        #endregion Status Log Search

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            // do nothing if the user doesn't select OK
            if (ofd.ShowDialog() != DialogResult.OK) return;

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

        /// <summary>
        /// When the tailed file changes, show the changes in the viewer.
        /// </summary>
        private void statusLogWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            setStatusLog(e.FullPath);
        }

        /// <summary>
        ///   opens the file and reads the last # of lines and sets the text in the viewer.
        /// </summary>
        /// <param name="path">Path to the file to tail</param>
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
        ///<param name="line_count">The number of lines to return.</param>
        ///<returns>The last <paramref name="line_count"/> lines from the reader.</returns>
        private static string[] tail(TextReader reader, int line_count)
        {
            // this was taken from StackOverflow, shamelessly.
            //   http://stackoverflow.com/questions/4619735/how-to-read-last-n-lines-of-log-file

            var buffer = new List<string>(line_count);
            string line;
            for (var i = 0; i < line_count; i++)
            {
                line = reader.ReadLine();
                if (line == null) return buffer.ToArray();
                buffer.Add(line);
            }

            //The index of the last line read from the buffer.  Everything > this index was read earlier than everything <= this indes
            var last_line = line_count - 1;

            while (null != (line = reader.ReadLine()))
            {
                last_line++;
                if (last_line == line_count) last_line = 0;
                buffer[last_line] = line;
            }

            if (last_line == line_count - 1) return buffer.ToArray();
            var return_value = new string[line_count];
            buffer.CopyTo(last_line + 1, return_value, 0, line_count - last_line - 1);
            buffer.CopyTo(0, return_value, line_count - last_line - 1, last_line + 1);
            return return_value;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var cm = new ContextMenuStrip();

            var mi_copy = new ToolStripMenuItem("&Copy");
            mi_copy.Click += (s, args) =>
            {
                syntaxBox.Copy();
            };
            mi_copy.Image = Properties.Resources.copy;
            cm.Items.Add(mi_copy);

            var mi_find = new ToolStripMenuItem("&Find");
            mi_find.Click += (s, args) =>
            {
                launchFindForm();
            };
            mi_find.Image = Properties.Resources.find;
            cm.Items.Add(mi_find);

            syntaxBox.ContextMenuStrip = cm;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tail
{
    public partial class frmFind : Form
    {
        private readonly string[] _text;
        private int _last = 0;
        private Dictionary<int, int> _found = new Dictionary<int, int>();

        public frmFind(string[] text)
        {
            InitializeComponent();
            _text = text;
        }

        #region Button Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            grdResults.Rows.Clear();
            _found.Clear();
            for (var i = 0; i < _text.Length; i++)
            {
                string found_text;
                if (find(_text[i], out found_text))
                {
                    grdResults.Rows.Add(i + 1, _text[i], found_text);
                    _found.Add(i, i + 1);
                }
            }
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        #endregion Button Handlers

        #region Find methods

        public void FindNext()
        {
            var start = rbDown.Checked ? ++_last : --_last;
            var found = false;
            var found_text = "";

            if (rbDown.Checked)
            {
                for (; _last < _text.Length; _last++)
                {
                    if (!find(_text[_last], out found_text)) continue;
                    found = true;
                    break;
                }

                if (!found)
                {
                    for (_last = 0; _last < start; _last++)
                    {
                        if (!find(_text[_last], out found_text)) continue;
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (; _last > 0; _last--)
                {
                    if (!find(_text[_last], out found_text)) continue;
                    found = true;
                    break;
                }

                if (!found)
                {
                    for (_last = _text.Length - 1; _last > start; _last--)
                    {
                        if (!find(_text[_last], out found_text)) continue;
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                MessageBox.Show(@"Text not found.");
                return;
            }

            if (!_found.ContainsKey(_last + 1))
            {
                grdResults.Rows.Add(_last + 1, _text[_last], found_text);
                _found.Add(_last + 1, _found.Count);
            }

            grdResults.Rows[_found[_last + 1]].Selected = true;
            grdResults.CurrentCell = grdResults.Rows[_found[_last + 1]].Cells[0];

            FoundText?.Invoke(this, new FoundTextEventHandlerArgs(txtSearch.Text, _last));
        }

        private bool find(string l, out string found_text)
        {
            if (chkIgnoreCase.Checked)
            {
                if (chkRegex.Checked)
                {
                    var m = Regex.Match(l, txtSearch.Text, RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        found_text = m.Value;
                        return true;
                    }
                }
                else
                {
                    if (l.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        found_text = txtSearch.Text;
                        return true;
                    }
                }
            }
            else
            {
                if (chkRegex.Checked)
                {
                    var m = Regex.Match(l, txtSearch.Text);
                    if (m.Success)
                    {
                        found_text = m.Value;
                        return true;
                    }
                }
                else
                {
                    if (l.Contains(txtSearch.Text))
                    {
                        found_text = txtSearch.Text;
                        return true;
                    }
                }
            }
            found_text = "";
            return false;
        }

        #endregion Find methods

        public event FoundTextEventHandler FoundText;

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            if (keys == Keys.Enter || keys == Keys.F3)
                FindNext();
            return base.ProcessCmdKey(ref msg, keys);
        }

        #region grid handlers

        private void grdResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FoundText?.Invoke(this, new FoundTextEventHandlerArgs(txtSearch.Text, Convert.ToInt32(grdResults.SelectedRows[0].Cells[0].Value) - 1));
        }

        private void grdResults_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // don't bother if the column isn't the line of text
            if (!(e.RowIndex >= 0 & e.ColumnIndex == 1)) return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            var sw = grdResults.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (!string.IsNullOrEmpty(sw))
            {
                var val = (string)e.FormattedValue;
                var sindx = val.ToLower().IndexOf(sw.ToLower(), StringComparison.Ordinal);
                if (sindx >= 0)
                {
                    var hl_rect = new Rectangle
                    {
                        Y = e.CellBounds.Y + 2,
                        Height = e.CellBounds.Height - 5
                    };

                    var sBefore = val.Substring(0, sindx);
                    var sWord = val.Substring(sindx, sw.Length);
                    var s1 = TextRenderer.MeasureText(e.Graphics, sBefore, e.CellStyle.Font, e.CellBounds.Size);
                    var s2 = TextRenderer.MeasureText(e.Graphics, sWord, e.CellStyle.Font, e.CellBounds.Size);

                    if (s1.Width > 5)
                    {
                        hl_rect.X = e.CellBounds.X + s1.Width - 5;
                        hl_rect.Width = s2.Width - 6;
                    }
                    else
                    {
                        hl_rect.X = e.CellBounds.X + 2;
                        hl_rect.Width = s2.Width - 6;
                    }

                    var hl_brush = default(SolidBrush);
                    if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
                    {
                        hl_brush = new SolidBrush(Color.DarkOrange);
                    }
                    else
                    {
                        hl_brush = new SolidBrush(Color.Yellow);

                        e.Graphics.FillRectangle(hl_brush, hl_rect);

                        hl_brush.Dispose();
                    }
                }
                e.PaintContent(e.CellBounds);
            }
        }

        #endregion grid handlers

        // A delegate type for hooking up change notifications.
        public delegate void FoundTextEventHandler(object sender, FoundTextEventHandlerArgs e);
    }

    public class FoundTextEventHandlerArgs : EventArgs
    {
        public string Search { get; set; }
        public int Position { get; set; }

        public FoundTextEventHandlerArgs(string search, int position)
        {
            Search = search;
            Position = position;
        }
    }
}
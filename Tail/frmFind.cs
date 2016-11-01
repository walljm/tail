using System;
using System.Windows.Forms;

namespace Tail
{
    public partial class frmFind : Form
    {
        private readonly string[] _text;
        private int _last = 0;

        public frmFind(string[] text)
        {
            InitializeComponent();
            _text = text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        public void FindNext()
        {
            var start = rbDown.Checked ? ++_last : --_last;
            var found = false;

            if (rbDown.Checked)
            {
                for (; _last < _text.Length; _last++)
                {
                    if (!find()) continue;
                    found = true;
                    break;
                }

                if (!found)
                {
                    for (_last = 0; _last < start; _last++)
                    {
                        if (!find()) continue;
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (; _last > 0; _last--)
                {
                    if (!find()) continue;
                    found = true;
                    break;
                }

                if (!found)
                {
                    for (_last = _text.Length - 1; _last > start; _last--)
                    {
                        if (!find()) continue;
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
            FoundText?.Invoke(this, new FoundTextEventHandlerArgs(txtSearch.Text, _last));
        }

        private bool find()
        {
            if (chkIgnoreCase.Checked)
            {
                if (_text[_last].ToLower().Contains(txtSearch.Text.ToLower()))
                    return true;
            }
            else
            {
                if (_text[_last].Contains(txtSearch.Text))
                    return true;
            }
            return false;
        }

        public event FoundTextEventHandler FoundText;

        protected override bool ProcessCmdKey(ref Message msg, Keys keys)
        {
            if (keys == Keys.Enter || keys == Keys.F3)
                FindNext();
            return base.ProcessCmdKey(ref msg, keys);
        }
    }

    // A delegate type for hooking up change notifications.
    public delegate void FoundTextEventHandler(object sender, FoundTextEventHandlerArgs e);

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
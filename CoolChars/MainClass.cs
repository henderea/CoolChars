using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoolChars
{
// ReSharper disable InconsistentNaming
    public partial class MainClass : Form
    {
        public MainClass()
        {
            InitializeComponent();
            //undoStack = new Stack<string>(0);
            //redoStack = new Stack<string>(0);
        }

        //private Stack<string> undoStack;
        //private Stack<string> redoStack;

        /*private bool Undo()
        {
            if (undoStack.Count <= 0)
                return false;
            return true;
        }

        private bool Redo()
        {
            if (redoStack.Count <= 0)
                return false;
            return true;
        }*/

        private void charButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button) sender;
                string s = b.Text;
                string t = textArea.Text;
                int i = textArea.SelectionStart;
                if (textArea.SelectionLength > 0)
                    t = t.Remove(i, textArea.SelectionLength);
                textArea.Text = t.Insert(i, s);
                textArea.Select(i + 1, 0);
                textArea.Focus();
            }
            catch {}
        }

        private void textArea_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
                textArea.SelectAll();
            else if (e.KeyCode == Keys.S && e.Control)
                fileChooserS.ShowDialog();
            else if (e.KeyCode == Keys.O && e.Control)
                fileChooserO.ShowDialog();
            //else if (e.KeyCode == Keys.C && e.Control)
            //    textArea.Copy();
            //else if (e.KeyCode == Keys.X && e.Control)
            //    textArea.Cut();
            //else if (e.KeyCode == Keys.V && e.Control)
            //    textArea.Paste();
        }

        private void fileChooserO_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileChooserO.FileName);
                textArea.Lines = lines;
            }
            catch {}
        }

        private void fileChooserS_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                File.WriteAllLines(fileChooserS.FileName, textArea.Lines);
            }
            catch {}
        }
    }

// ReSharper restore InconsistentNaming
}
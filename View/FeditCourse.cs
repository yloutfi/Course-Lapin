using Model;
using System;
using System.Windows.Forms;

namespace Utdl.View
{
    public partial class FeditCourse : Form
    {
        State state;
        ListBox.ObjectCollection items;
        int position;

        public FeditCourse(State state, ListBox.ObjectCollection items, int position)
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
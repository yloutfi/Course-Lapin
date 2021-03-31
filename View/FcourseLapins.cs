using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utdl.View {
    public partial class FcourseLapins:Form {
        public FcourseLapins() {
            InitializeComponent();
            btnAdd.Click += this.btnAdd_Click;
            btnEdit.Click += this.btnEdit_Click;
            btnDelete.Click += this.btnDelete_Click;
            btnSave.Click += this.btnSave_Click;
        }

        private void btnSave_Click(object sender,System.EventArgs e) {
            throw new System.NotImplementedException();
        }

        private void btnDelete_Click(object sender,System.EventArgs e) {
            throw new System.NotImplementedException();
        }

        private void btnEdit_Click(object sender,System.EventArgs e) {
            throw new System.NotImplementedException();
        }

        private void btnAdd_Click(object sender,System.EventArgs e) {
            throw new System.NotImplementedException();
        }


    }
}

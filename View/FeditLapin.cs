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
    public partial class FeditLapin:Form {
        public FeditLapin() {
            InitializeComponent();
            btnValider.Click += this.btnValider_Click;
        }

        private void btnValider_Click(object sender,EventArgs e) {
            throw new NotImplementedException();
        }
    }
}

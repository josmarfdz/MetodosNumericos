using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MétodosNuméricos
{
    public partial class ctrlMenú : UserControl
    {
        ctrlEcuaciones sistemas = new ctrlEcuaciones();
        public ctrlMenú()
        {
            InitializeComponent();
        }

        private void btnSistemas_Click(object sender, EventArgs e)
        {
            this.Hide();
            sistemas.Show();
        }

        private void btnRaices_Click(object sender, EventArgs e)
        {

        }

        private void btnDerivacion_Click(object sender, EventArgs e)
        {
        }

        private void btnIntegracion_Click(object sender, EventArgs e)
        {
        }
    }
}

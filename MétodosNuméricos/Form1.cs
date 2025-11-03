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
    public partial class fmMétodos : Form
    {
        public fmMétodos()
        {
            InitializeComponent();
            ctrlSistmas.Hide();
            btnHome.Hide();
            ctrlRaices.Hide();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.Hide();
            pnlMenú.Show();
            btnClose.Show();
            ctrlSistmas.Hide();
            ctrlRaices.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult Cerrar = MessageBox.Show("¿Realmente desea cerrar el programa?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Cerrar == DialogResult.Yes)
                this.Close();
        }

        private void Menú()
        {
            btnClose.Hide();
            pnlMenú.Hide();
            btnHome.Show();
        }

        private void btnSistemas_Click(object sender, EventArgs e)
        {
            Menú();
            ctrlSistmas.Show();
            MessageBox.Show("En un sistema de ecuaciones, se sigue la forma:\na1x1 + b1x2 + c1x3 = d1\na2x1 + b2x2 + c2x3 = d2\na3x1 + b3x2 + c3x3 = d3\nEjemplo:\n3x1 + 4x2 - 5x3 = 6\nx1 + 2x2 + x3 = 28\n- 2x1 + 3x2 + 8x3 = 73", "Sistemas de ecuaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIntegracion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lamentamos las molestias.\nEl apartado de integración numérica aún se encuentra en mantenimiento. Recuerda estar al tanto de futuras actualizaciones", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDerivacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lamentamos las molestias.\nEl apartado de derivación numérica aún se encuentra en mantenimiento. Recuerda estar al tanto de futuras actualizaciones", "En desarollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRaices_Click(object sender, EventArgs e)
        {
            Menú();
            ctrlRaices.Show();
            MessageBox.Show("Para ingresar la función, siga la forma ±ax^n1 ± bx^n2 ± cx ± d\n\nEjemplo:\n3x^2 -2x -5", "Raíces de funciones polinomiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

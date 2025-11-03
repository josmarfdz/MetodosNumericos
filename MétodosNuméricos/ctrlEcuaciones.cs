using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MétodosNuméricos
{
    public partial class ctrlEcuaciones : UserControl
    {
        int n = 0;
        double[,] X;
        double[] Res;
        bool estatus = false;
        double delta, determinante;
        public ctrlEcuaciones()
        {
            InitializeComponent();
            txtX11.TextChanged += validarNúmero;
            txtX12.TextChanged += validarNúmero;
            txtX13.TextChanged += validarNúmero;
            txtX21.TextChanged += validarNúmero;
            txtX22.TextChanged += validarNúmero;
            txtX23.TextChanged += validarNúmero;
            txtX31.TextChanged += validarNúmero;
            txtX32.TextChanged += validarNúmero;
            txtX33.TextChanged += validarNúmero;
            txtR1.TextChanged += validarNúmero;
            txtR2.TextChanged += validarNúmero;
            txtR3.TextChanged += validarNúmero;
        }

        void Limpiar()
        {
            txtX11.Clear();
            txtX12.Clear();
            txtX13.Clear();
            txtR1.Clear();
            txtX21.Clear();
            txtX22.Clear();
            txtX23.Clear();
            txtR2.Clear();
            txtX31.Clear();
            txtX32.Clear();
            txtX33.Clear();
            txtR3.Clear();
            rb22.Checked = false;
            rb33.Checked = false;
            rbGauss.Checked = false;
            Bloqueo();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Antes de continuar, ¿Ha revisado que los valores se ingresaron correctamente?", "Por revisar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (rbCramer.Checked)
                    Cramer();
                else if (rbGauss.Checked)
                    Gauss();
                else if (rbInversa.Checked)
                    Inversa();
                else if (rbCofactores.Checked)
                    Cofactores();
                else
                    MessageBox.Show("Seleccione un método de resolución primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rb22_CheckedChanged(object sender, EventArgs e)
        {
            Bloqueo();
            txtX11.Enabled = true;
            txtX12.Enabled = true;
            txtX21.Enabled = true;
            txtX22.Enabled = true;
            txtR1.Enabled = true;
            txtR2.Enabled = true;
            n = 2;
        }
        private void rb33_CheckedChanged(object sender, EventArgs e)
        {
            txtX11.Enabled = true;
            txtX12.Enabled = true;
            txtX13.Enabled = true;
            txtX21.Enabled = true;
            txtX22.Enabled = true;
            txtX23.Enabled = true;
            txtX31.Enabled = true;
            txtX32.Enabled = true;
            txtX33.Enabled = true;
            txtR1.Enabled = true;
            txtR2.Enabled = true;
            txtR3.Enabled = true;
            n = 3;
        }

        void Procedimiento()
        {
            for (int k = 0; k < n; k++)
            {
                double pivote = X[k, k];
                if (pivote == 0)
                {
                    bool cambiado = false;
                    for (int i = k + 1; i < n; i++)
                    {
                        if (X[i, k] != 0)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                double temp = X[k, j];
                                X[k, j] = X[i, j];
                                X[i, j] = temp;
                            }
                            double tempRes = Res[k];
                            Res[k] = Res[i];
                            Res[i] = tempRes;

                            cambiado = true;
                            pivote = X[k, k];
                            break;
                        }
                    }
                    if (!cambiado)
                    {
                        MessageBox.Show("No se puede dividir entre 0 ni intercambiar filas válidas.\nSistema sin solución única.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (int j = 0; j < n; j++)
                    X[k, j] /= pivote;
                Res[k] /= pivote;
                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        double factor = X[i, k];
                        for (int j = 0; j < n; j++)
                            X[i, j] -= factor * X[k, j];
                        Res[i] -= factor * Res[k];
                    }
                }
            }
        }


        void Bloqueo()
        {
            txtX11.Enabled = false;
            txtX12.Enabled = false;
            txtX13.Enabled = false;
            txtX21.Enabled = false;
            txtX22.Enabled = false;
            txtX23.Enabled = false;
            txtX31.Enabled = false;
            txtX32.Enabled = false;
            txtX33.Enabled = false;
            txtR1.Enabled = false;
            txtR2.Enabled = false;
            txtR3.Enabled = false;
        }

        private bool NúmeroVálido(string valor)
        {
            double resultado;
            return double.TryParse(valor, out resultado);
        }
        private void validarNúmero(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string valor = textBox.Text.Trim();
            if (string.IsNullOrEmpty(valor))
                return;
            if (valor == "-" || valor == "." || valor == "-.")
                return;
            if (!double.TryParse(valor, out _))
            {
                MessageBox.Show("Ingrese un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }

        public void Verificador()
        {
            estatus = false;
            if (rb22.Checked)
            {
                if (txtX11.Text != "" && txtX12.Text != "" && txtX21.Text != "" && txtX22.Text != "" && txtR1.Text != "" && txtR2.Text != "")
                {
                    estatus = true;
                }
                else
                    MessageBox.Show("No se pueden dejar campos vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rb33.Checked)
            {
                if (txtX11.Text != "" && txtX12.Text != "" && txtX13.Text != "" && txtX21.Text != "" && txtX22.Text != "" && txtX23.Text != "" && txtX31.Text != "" && txtX32.Text != "" && txtX33.Text != "" && txtR1.Text != "" && txtR2.Text != "" && txtR3.Text != "")
                {
                    estatus = true;
                }
                else
                    MessageBox.Show("No se pueden dejar campos vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Seleccione un tamaño de matriz", "Tamaño no especificado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void DeltaDos()
        {
            delta = (X[0, 0] * X[1, 1]) - (X[0, 1] * X[1, 0]);
        }
        public void DeltaTres()
        {
            delta = (X[0, 0] * ((X[1, 1] * X[2, 2]) - (X[1, 2] * X[2, 1]))) - (X[0, 1] * ((X[1, 0] * X[2, 2]) - (X[1, 2] * X[2, 0]))) + (X[0, 2] * ((X[1, 0] * X[2, 1]) - (X[1, 1] * X[2, 0])));
        }

        public void Puente()
        {
            if (estatus == true)
            {
                if (rbGauss.Checked)
                {
                    if (rb22.Checked)
                    {
                        Matriz2p2();
                        DeltaDos();
                        if (delta != 0)
                            Procedimiento();
                        else
                            MessageBox.Show("La matriz tiene soluciones infinitas o no tiene una", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (rb33.Checked)
                    {
                        Matriz3p3();
                        DeltaTres();
                        if (delta != 0)
                            Procedimiento();
                        else
                            MessageBox.Show("La matriz tiene soluciones infinitas o no tiene una", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rbCramer.Checked)
                {
                    if (rb22.Checked)
                    {
                        Matriz2p2();
                        DeltaDos();
                        if (delta != 0)
                            ProcedimientoCramer();
                        else
                            MessageBox.Show("La matriz tiene soluciones infinitas o no tiene una", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (rb33.Checked)
                    {
                        Matriz3p3();
                        DeltaTres();
                        if (delta != 0)
                            ProcedimientoCramer();
                        else
                            MessageBox.Show("La matriz tiene soluciones infinitas o no tiene una", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rbInversa.Checked)
                {
                    if (rb22.Checked)
                    {
                        Matriz2p2();
                        DeltaDos();
                        if (delta != 0)
                            ProcedimientoInversa();
                        else
                            MessageBox.Show("La matriz tiene soluciones infinitas o no tiene una", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (rb33.Checked)
                    {
                        Matriz3p3();
                        DeltaTres();
                        if (delta != 0)
                            ProcedimientoInversa();
                        else
                            MessageBox.Show("La matriz tiene soluciones infinitas o no tiene una", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void Resultado()
        {
            if (rbGauss.Checked)
            {
                string ResFinal = "";
                for (int i = 0; i < n; i++)
                {
                    ResFinal += $"\nX{i + 1}: {Res[i]}";
                }
                MessageBox.Show(ResFinal, "Resultado");
            }
        }

        public void Gauss()
        {
            Verificador();
            Puente();
            Resultado();
        }

        public void Cramer()
        {
            Verificador();
            Puente();
        }

        public void Inversa()
        {
            Verificador();
            Puente();
        }

        public void Cofactores()
        {

        }
        public void ProcedimientoCramer()
        {
            double a11, a12, a21, a22;
            double DetMatriz2x2 = delta;
            double newA11, newA21, newA12, newA22, xT, yT, xxt, yyt;
            double b11, b12, b13, b21, b22, b23, b31, b32, b33;
            double DetMat3x3;
            double N11, N21, N31;
            double X1, X2, X3;

            if (rb22.Checked)
            {
                determinante = (X[0, 0] * X[1, 1]) - (X[1, 0] * X[0, 1]);
                a11 = Convert.ToDouble(txtX11.Text);
                a12 = Convert.ToDouble(txtX12.Text);
                a21 = Convert.ToDouble(txtX21.Text);
                a22 = Convert.ToDouble(txtX22.Text);
                newA11 = Convert.ToDouble(txtR1.Text);
                newA21 = Convert.ToDouble(txtR2.Text);
                xT = (newA11 * a22) - (newA21 * a12);
                xxt = xT / DetMatriz2x2;
                newA12 = Convert.ToDouble(txtR1.Text);
                newA22 = Convert.ToDouble(txtR2.Text);
                yT = (a11 * newA22) - (a21 * newA12);
                yyt = yT / DetMatriz2x2;
                MessageBox.Show("X1: " + xxt + "\nX2: " + yyt);
            }
            if (rb33.Checked)
            {
                determinante = ((X[0, 0]) * ((X[1, 1] * X[2, 2]) - (X[2, 1] * X[1, 2]))) + ((-(X[0, 1])) * ((X[1, 0] * X[2, 2]) - (X[2, 0] * X[1, 2]))) + ((X[0, 2]) * ((X[1, 0] * X[2, 1]) - (X[2, 0] * X[1, 1])));
                b11 = Convert.ToDouble(txtX11.Text);
                b12 = Convert.ToDouble(txtX12.Text);
                b13 = Convert.ToDouble(txtX13.Text);
                b21 = Convert.ToDouble(txtX21.Text);
                b22 = Convert.ToDouble(txtX22.Text);
                b23 = Convert.ToDouble(txtX23.Text);
                b31 = Convert.ToDouble(txtX31.Text);
                b32 = Convert.ToDouble(txtX32.Text);
                b33 = Convert.ToDouble(txtX33.Text);
                DetMat3x3 = delta;

                N11 = Convert.ToDouble(txtR1.Text);
                N21 = Convert.ToDouble(txtR2.Text);
                N31 = Convert.ToDouble(txtR3.Text);

                // Δx (sustituir la primera columna por N’s)
                double Dx = (N11 * (b22 * b33 - b23 * b32))
                          - (b12 * (N21 * b33 - b23 * N31))
                          + (b13 * (N21 * b32 - b22 * N31));

                // Δy (sustituir la segunda columna por N’s)
                double Dy = (b11 * (N21 * b33 - b23 * N31))
                          - (N11 * (b21 * b33 - b23 * b31))
                          + (b13 * (b21 * N31 - N21 * b31));

                // Δz (sustituir la tercera columna por N’s)
                double Dz = (b11 * (b22 * N31 - N21 * b32))
                          - (b12 * (b21 * N31 - N21 * b31))
                          + (N11 * (b21 * b32 - b22 * b31));

                // Soluciones
                X1 = Dx / DetMat3x3;
                X2 = Dy / DetMat3x3;
                X3 = Dz / DetMat3x3;


                MessageBox.Show("X1: " + X1 + "\nX2: " + X2 + "\nX3: " + X3);
            }
        }
        public void Matriz2p2()
        {
            X = new double[n, n];
            Res = new double[n];
            X[0, 0] = double.Parse(txtX11.Text);
            X[0, 1] = double.Parse(txtX12.Text);
            Res[0] = double.Parse(txtR1.Text);
            X[1, 0] = double.Parse(txtX21.Text);
            X[1, 1] = double.Parse(txtX22.Text);
            Res[1] = double.Parse(txtR2.Text);
        }

        public void Matriz3p3()
        {
            X = new double[n, n];
            Res = new double[n];
            X[0, 0] = double.Parse(txtX11.Text);
            X[0, 1] = double.Parse(txtX12.Text);
            X[0, 2] = double.Parse(txtX13.Text);
            Res[0] = double.Parse(txtR1.Text);
            X[1, 0] = double.Parse(txtX21.Text);
            X[1, 1] = double.Parse(txtX22.Text);
            X[1, 2] = double.Parse(txtX23.Text);
            Res[1] = double.Parse(txtR2.Text);
            X[2, 0] = double.Parse(txtX31.Text);
            X[2, 1] = double.Parse(txtX32.Text);
            X[2, 2] = double.Parse(txtX33.Text);
            Res[2] = double.Parse(txtR3.Text);
        }

        public void ProcedimientoInversa()
        {
            // Caso 2x2
            if (rb22.Checked)
            {
                double a1 = double.Parse(txtX11.Text);
                double a2 = double.Parse(txtX12.Text);
                double b1 = double.Parse(txtX21.Text);
                double b2 = double.Parse(txtX22.Text);

                // Si el primer elemento es 0, intercambiar filas automáticamente
                if (a1 == 0)
                {
                    double temp1 = a1; a1 = b1; b1 = temp1;
                    double temp2 = a2; a2 = b2; b2 = temp2;

                    // También intercambiamos los resultados independientes
                    string tempR = txtR1.Text;
                    txtR1.Text = txtR2.Text;
                    txtR2.Text = tempR;
                }

                double det = (a1 * b2) - (a2 * b1);
                if (det == 0)
                {
                    MessageBox.Show("La determinante es igual a cero, por lo tanto el sistema no tiene solución");
                    return;
                }

                // Matriz identidad
                double i1 = 1, i2 = 0, i3 = 0, i4 = 1;

                // Copias originales (para comprobación)
                double a = a1, aa = a2, b = b1, bb = b2;

                // Paso 1
                double divisor1 = a1;
                if (divisor1 != 0)
                {
                    a2 /= divisor1;
                    i1 /= divisor1;
                    i2 /= divisor1;
                    a1 /= divisor1;
                }

                // Paso 2
                double multiplicador1 = b1;
                b2 -= (multiplicador1 * a2);
                i3 -= (multiplicador1 * i1);
                i4 -= (multiplicador1 * i2);
                b1 -= (multiplicador1 * a1);

                // Paso 3
                double divisor2 = b2;
                if (divisor2 != 0)
                {
                    i3 /= divisor2;
                    i4 /= divisor2;
                    b1 /= divisor2;
                    b2 /= divisor2;
                }

                // Paso 4
                double multiplicador2 = a2;
                a1 -= (multiplicador2 * b1);
                i1 -= (multiplicador2 * i3);
                i2 -= (multiplicador2 * i4);
                a2 -= (multiplicador2 * b2);

                // Resultados finales
                double ind1 = double.Parse(txtR1.Text), ind2 = double.Parse(txtR2.Text);
                double x1 = (i1 * ind1) + (i2 * ind2);
                double x2 = (i3 * ind1) + (i4 * ind2);

                double com1 = (a * x1) + (aa * x2);
                double com2 = (b * x1) + (bb * x2);

                string resultado = $"x1 = {x1}\n" +
                                   $"x2 = {x2}";

                MessageBox.Show(resultado, "Resultados finales");
            }

            // Caso 3x3
            else if (rb33.Checked)
            {
                double a11 = double.Parse(txtX11.Text);
                double a12 = double.Parse(txtX12.Text);
                double a13 = double.Parse(txtX13.Text);
                double a21 = double.Parse(txtX21.Text);
                double a22 = double.Parse(txtX22.Text);
                double a23 = double.Parse(txtX23.Text);
                double a31 = double.Parse(txtX31.Text);
                double a32 = double.Parse(txtX32.Text);
                double a33 = double.Parse(txtX33.Text);

                // Si el primer pivote es 0, buscar una fila inferior para intercambiar
                if (a11 == 0)
                {
                    if (a21 != 0)
                    {
                        // Intercambiar fila 1 con fila 2
                        (a11, a21) = (a21, a11);
                        (a12, a22) = (a22, a12);
                        (a13, a23) = (a23, a13);

                        // Intercambiar resultados
                        string tempR = txtR1.Text;
                        txtR1.Text = txtR2.Text;
                        txtR2.Text = tempR;
                    }
                    else if (a31 != 0)
                    {
                        // Intercambiar fila 1 con fila 3
                        (a11, a31) = (a31, a11);
                        (a12, a32) = (a32, a12);
                        (a13, a33) = (a33, a13);

                        // Intercambiar resultados
                        string tempR = txtR1.Text;
                        txtR1.Text = txtR3.Text;
                        txtR3.Text = tempR;
                    }
                    else
                    {
                        MessageBox.Show("No es posible intercambiar filas, todas tienen 0 en la primera columna.", "Error");
                        return;
                    }
                }

                double det = a11 * (a22 * a33 - a23 * a32) -
                             a12 * (a21 * a33 - a23 * a31) +
                             a13 * (a21 * a32 - a22 * a31);

                if (det == 0)
                {
                    MessageBox.Show("La determinante es igual a cero, por lo tanto el sistema no tiene solución");
                    return;
                }

                // Matriz identidad inicial
                double i11 = 1, i12 = 0, i13 = 0;
                double i21 = 0, i22 = 1, i23 = 0;
                double i31 = 0, i32 = 0, i33 = 1;

                // Copias originales (para comprobación)
                double a = a11, aa = a12, aaa = a13, b = a21, bb = a22, bbb = a23, c = a31, cc = a32, ccc = a33;

                // Proceso de inversión (sin mostrar pasos)
                double divisor1 = a11;
                a12 /= divisor1; a13 /= divisor1;
                i11 /= divisor1; i12 /= divisor1; i13 /= divisor1; a11 /= divisor1;

                double mult1 = a21;
                a22 -= mult1 * a12; a23 -= mult1 * a13;
                i21 -= mult1 * i11; i22 -= mult1 * i12; i23 -= mult1 * i13; a21 -= mult1 * a11;

                double mult2 = a31;
                a32 -= mult2 * a12; a33 -= mult2 * a13;
                i31 -= mult2 * i11; i32 -= mult2 * i12; i33 -= mult2 * i13; a31 -= mult2 * a11;

                double divisor2 = a22;
                a23 /= divisor2; i21 /= divisor2; i22 /= divisor2; i23 /= divisor2; a22 /= divisor2;

                double mult3 = a12;
                a13 -= mult3 * a23; i11 -= mult3 * i21; i12 -= mult3 * i22; i13 -= mult3 * i23; a12 -= mult3 * a22;

                double mult4 = a32;
                a33 -= mult4 * a23; i31 -= mult4 * i21; i32 -= mult4 * i22; i33 -= mult4 * i23; a32 -= mult4 * a22;

                double divisor3 = a33;
                i31 /= divisor3; i32 /= divisor3; i33 /= divisor3; a33 /= divisor3;

                double mult5 = a13;
                a11 -= mult5 * a31; a12 -= mult5 * a32;
                i11 -= mult5 * i31; i12 -= mult5 * i32; i13 -= mult5 * i33; a13 -= mult5 * a33;

                double mult6 = a23;
                a21 -= mult6 * a31; a22 -= mult6 * a32;
                i21 -= mult6 * i31; i22 -= mult6 * i32; i23 -= mult6 * i33; a23 -= mult6 * a33;

                // Resultados finales
                double ind1 = double.Parse(txtR1.Text), ind2 = double.Parse(txtR2.Text), ind3 = double.Parse(txtR3.Text);
                double x1 = (i11 * ind1) + (i12 * ind2) + (i13 * ind3);
                double x2 = (i21 * ind1) + (i22 * ind2) + (i23 * ind3);
                double x3 = (i31 * ind1) + (i32 * ind2) + (i33 * ind3);

                double com1 = (a * x1) + (aa * x2) + (aaa * x3);
                double com2 = (b * x1) + (bb * x2) + (bbb * x3);
                double com3 = (c * x1) + (cc * x2) + (ccc * x3);

                string resultado = $"x1 = {x1}\n" +
                                   $"x2 = {x2}\n" +
                                   $"x3 = {x3}";

                MessageBox.Show(resultado, "Resultados finales");
            }
        }

        public void ProcedimientoCofactores()
        {
            // ----- CASO 2x2 -----
            if (rb22.Checked)
            {
                double a11 = double.Parse(txtX11.Text);
                double a12 = double.Parse(txtX12.Text);
                double a21 = double.Parse(txtX21.Text);
                double a22 = double.Parse(txtX22.Text);
                double r1 = double.Parse(txtR1.Text);
                double r2 = double.Parse(txtR2.Text);

                // Matriz adjunta (cofactores)
                double[,] adjunta = new double[2, 2];
                adjunta[0, 0] = a22;
                adjunta[0, 1] = -a12;
                adjunta[1, 0] = -a21;
                adjunta[1, 1] = a11;

                // Transpuesta (para 2x2 es igual que invertir diagonal)
                double[,] transpuesta = new double[2, 2];
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        transpuesta[j, i] = adjunta[i, j];

                // Multiplicación por vector de resultados
                double[] res = new double[2];
                res[0] = (transpuesta[0, 0] * r1 + transpuesta[0, 1] * r2) / delta;
                res[1] = (transpuesta[1, 0] * r1 + transpuesta[1, 1] * r2) / delta;

                string msg = $"x1 = {res[0]:F4}\n" +
                             $"x2 = {res[1]:F4}";
                MessageBox.Show(msg, "Resultados (Método de Cofactores)");
            }

            // ----- CASO 3x3 -----
            else if (rb33.Checked)
            {
                double[,] A = new double[3, 3];
                double[,] adjunta = new double[3, 3];
                double[,] transpuesta = new double[3, 3];
                double[] b = new double[3];

                // Matriz de coeficientes
                A[0, 0] = double.Parse(txtX11.Text);
                A[0, 1] = double.Parse(txtX12.Text);
                A[0, 2] = double.Parse(txtX13.Text);
                A[1, 0] = double.Parse(txtX21.Text);
                A[1, 1] = double.Parse(txtX22.Text);
                A[1, 2] = double.Parse(txtX23.Text);
                A[2, 0] = double.Parse(txtX31.Text);
                A[2, 1] = double.Parse(txtX32.Text);
                A[2, 2] = double.Parse(txtX33.Text);

                // Vector de resultados
                b[0] = double.Parse(txtR1.Text);
                b[1] = double.Parse(txtR2.Text);
                b[2] = double.Parse(txtR3.Text);

                // Calcular matriz de cofactores
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        double[,] sub = Submatriz3x3(A, i, j);
                        double signo = ((i + j) % 2 == 0) ? 1 : -1;
                        adjunta[i, j] = signo * CalcularDet2x2(sub);
                    }
                }

                // Transpuesta (adjunta^T)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        transpuesta[j, i] = adjunta[i, j];

                // Multiplicación (A^-1 * b = adjunta^T * b / delta)
                double[] resultado = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    resultado[i] = (transpuesta[i, 0] * b[0] +
                                    transpuesta[i, 1] * b[1] +
                                    transpuesta[i, 2] * b[2]) / delta;
                }

                string msg = $"x1 = {resultado[0]:F4}\n" +
                             $"x2 = {resultado[1]:F4}\n" +
                             $"x3 = {resultado[2]:F4}";
                MessageBox.Show(msg, "Resultados (Método de Cofactores)");
            }
        }

        private static double CalcularDet2x2(double[,] m)
        {
            return (m[0, 0] * m[1, 1]) - (m[0, 1] * m[1, 0]);
        }

        // Extrae la submatriz 2x2 al eliminar fila i y columna j
        private static double[,] Submatriz3x3(double[,] m, int fila, int col)
        {
            double[,] sub = new double[2, 2];
            int x = 0, y;

            for (int i = 0; i < 3; i++)
            {
                if (i == fila) continue;
                y = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (j == col) continue;
                    sub[x, y] = m[i, j];
                    y++;
                }
                x++;
            }
            return sub;
        }

    }
}
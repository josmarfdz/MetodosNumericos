using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NCalc;

namespace MétodosNuméricos
{
    public partial class ctrlRaices : UserControl
    {
        private float x0, x1, errorDeseado;
        private int iteraciones;
        private float raiz, errorFinal;
        private List<IteracionSecante> tablaIteraciones;
        private List<IteracionBolzano> tablaBolzano;

        public ctrlRaices()
        {
            InitializeComponent();
            pnlNewton.Hide();
            pnlGeneral.Hide();
        }

        // ---------------------------
        // CLASES AUXILIARES
        // ---------------------------
        private class IteracionSecante
        {
            public int Iteracion { get; set; }
            public float X0 { get; set; }
            public float XI { get; set; }
            public float Fx0 { get; set; }
            public float FxI { get; set; }
            public float X2 { get; set; }
            public float Error { get; set; }
        }

        private class IteracionBolzano
        {
            public int Iteracion { get; set; }
            public float A { get; set; }
            public float B { get; set; }
            public float Xi { get; set; }
            public float Fxi { get; set; }
            public float Error { get; set; }
        }

        // ---------------------------
        // MÉTODO DE LA SECANTE
        // ---------------------------
        private void CalcularSecante()
        {
            tablaIteraciones = new List<IteracionSecante>();

            float xi0 = x0;
            float xi1 = x1;
            float errorActual = 1f;
            int iter = 0;

            float fx0 = EvaluarFuncion(xi0);
            float fx1 = EvaluarFuncion(xi1);
            float x2 = CalcularX2(xi0, xi1, fx0, fx1);

            tablaIteraciones.Add(new IteracionSecante
            {
                Iteracion = 1,
                X0 = xi0,
                XI = xi1,
                Fx0 = fx0,
                FxI = fx1,
                X2 = x2,
                Error = 1f
            });

            iter++;
            errorActual = Math.Abs((x2 - xi1) / x2);
            xi0 = xi1;
            xi1 = x2;

            while (errorActual > errorDeseado && iter < 100)
            {
                fx0 = EvaluarFuncion(xi0);
                fx1 = EvaluarFuncion(xi1);
                x2 = CalcularX2(xi0, xi1, fx0, fx1);

                if (float.IsNaN(x2) || float.IsInfinity(x2))
                    throw new Exception("El método divergió o se produjo una división por cero.");

                errorActual = Math.Abs((x2 - xi1) / x2);

                tablaIteraciones.Add(new IteracionSecante
                {
                    Iteracion = iter + 1,
                    X0 = xi0,
                    XI = xi1,
                    Fx0 = fx0,
                    FxI = fx1,
                    X2 = x2,
                    Error = errorActual
                });

                xi0 = xi1;
                xi1 = x2;
                iter++;
            }

            if (errorActual > errorDeseado)
                throw new Exception("No se encontró raíz en 100 iteraciones.");

            iteraciones = iter;
            raiz = x2;
            errorFinal = errorActual;
        }

        // ---------------------------
        // MÉTODO DE BOLZANO (BISECCIÓN)
        // ---------------------------
        private void CalcularBolzano()
        {
            tablaBolzano = new List<IteracionBolzano>();

            float a = x0;
            float b = x1;
            float fa = EvaluarFuncion(a);
            float fb = EvaluarFuncion(b);

            if (fa * fb > 0)
                throw new Exception("f(a) y f(b) tienen el mismo signo. El método no puede aplicarse.");

            float xi = 0, fxi = 0, errorActual = 1f, xiAnterior = 0;
            int iter = 0;

            while (errorActual > errorDeseado && iter < 100)
            {
                xi = (a + b) / 2;
                fxi = EvaluarFuncion(xi);

                if (iter > 0)
                    errorActual = Math.Abs((xi - xiAnterior) / xi);

                tablaBolzano.Add(new IteracionBolzano
                {
                    Iteracion = iter + 1,
                    A = a,
                    B = b,
                    Xi = xi,
                    Fxi = fxi,
                    Error = errorActual
                });

                if (fa * fxi < 0)
                {
                    b = xi;
                    fb = fxi;
                }
                else
                {
                    a = xi;
                    fa = fxi;
                }

                xiAnterior = xi;
                iter++;
            }

            if (errorActual > errorDeseado)
                throw new Exception("No se encontró raíz en 100 iteraciones.");

            iteraciones = iter;
            raiz = xi;
            errorFinal = errorActual;
        }

        // ---------------------------
        // FUNCIÓN GENERAL DE EVALUACIÓN
        // ---------------------------
        private float EvaluarFuncion(float x)
        {
            try
            {
                string funcion = txtFuncion.Text.Trim();

                // ✅ Reemplazar potencias tipo x^3 → Pow(x,3)
                funcion = System.Text.RegularExpressions.Regex.Replace(
                    funcion,
                    @"(\w+|\([^()]+\))\^(\d+(\.\d+)?)",
                    "Pow($1,$2)"
                );

                // ✅ Asegurar multiplicación implícita: 2x → 2*x
                funcion = System.Text.RegularExpressions.Regex.Replace(
                    funcion,
                    @"(\d)(x)",
                    "$1*$2"
                );

                // ✅ Evaluar la expresión con NCalc
                Expression expr = new Expression(funcion);
                expr.Parameters["x"] = (double)x;
                object result = expr.Evaluate();

                return Convert.ToSingle(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al evaluar la función. Revise la sintaxis.\nDetalles: {ex.Message}");
            }
        }


        // ---------------------------
        // BOTÓN CALCULAR
        // ---------------------------
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea continuar con el cálculo?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                // 🔹 Determinar método seleccionado primero
                if (rbNewton.Checked)
                {
                    // ✅ Validación específica para Newton-Raphson
                    if (string.IsNullOrWhiteSpace(txtXNewton.Text) ||
                        string.IsNullOrWhiteSpace(txtError.Text) ||
                        string.IsNullOrWhiteSpace(txtFuncion.Text))
                    {
                        MessageBox.Show("Por favor complete todos los campos para Newton-Raphson.", "Campos vacíos",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!float.TryParse(txtXNewton.Text, out x0) ||
                        !float.TryParse(txtError.Text, out errorDeseado))
                    {
                        MessageBox.Show("Ingrese valores numéricos válidos.", "Error de formato",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataIteracion.DataSource = null;
                    CalcularNewton();
                    MostrarResultadosNewton();
                }
                else
                {
                    // ✅ Validación para los otros métodos (Secante, Bolzano, Regula)
                    if (string.IsNullOrWhiteSpace(txtX0.Text) ||
                        string.IsNullOrWhiteSpace(txtX1.Text) ||
                        string.IsNullOrWhiteSpace(txtError.Text) ||
                        string.IsNullOrWhiteSpace(txtFuncion.Text))
                    {
                        MessageBox.Show("Por favor complete todos los campos.", "Campos vacíos",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!float.TryParse(txtX0.Text, out x0) ||
                        !float.TryParse(txtX1.Text, out x1) ||
                        !float.TryParse(txtError.Text, out errorDeseado))
                    {
                        MessageBox.Show("Ingrese valores numéricos válidos.", "Error de formato",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataIteracion.DataSource = null;

                    if (rbSecante.Checked)
                        CalcularSecante();
                    else if (rbBolzano.Checked)
                        CalcularBolzano();
                    else if (rbRegula.Checked)
                        CalcularRegula();
                    else
                    {
                        MessageBox.Show("Seleccione un método (Secante, Bolzano o Regula Falsi).",
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Mostrar resultados
                    if (rbSecante.Checked) MostrarResultadosSecante();
                    if (rbBolzano.Checked) MostrarResultadosBolzano();
                    if (rbRegula.Checked) MostrarResultadosRegula();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error de cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ---------------------------
        // MOSTRAR RESULTADOS SECANTE
        // ---------------------------
        private void MostrarResultadosSecante()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Iteración");
            dt.Columns.Add("x0");
            dt.Columns.Add("x1");
            dt.Columns.Add("f(x0)");
            dt.Columns.Add("f(x1)");
            dt.Columns.Add("x2");
            dt.Columns.Add("ε");

            foreach (var iter in tablaIteraciones)
            {
                dt.Rows.Add(iter.Iteracion, iter.X0.ToString("F6"), iter.XI.ToString("F6"),
                            iter.Fx0.ToString("E4"), iter.FxI.ToString("E4"),
                            iter.X2.ToString("F6"), iter.Error.ToString("E4"));
            }

            dataIteracion.DataSource = dt;

            MessageBox.Show($"Método de la Secante\n\n" +
                            $"Raíz aproximada: {raiz:F6}\nError final: {errorFinal:E4}\nIteraciones: {iteraciones}",
                            "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------------------------
        // MOSTRAR RESULTADOS BOLZANO
        // ---------------------------
        private void MostrarResultadosBolzano()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Iteración");
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Columns.Add("Xi");
            dt.Columns.Add("f(Xi)");
            dt.Columns.Add("Error");

            foreach (var iter in tablaBolzano)
            {
                dt.Rows.Add(iter.Iteracion, iter.A.ToString("F6"), iter.B.ToString("F6"),
                            iter.Xi.ToString("F6"), iter.Fxi.ToString("E4"), iter.Error.ToString("E4"));
            }

            dataIteracion.DataSource = dt;

            MessageBox.Show($"Método de Bolzano (Bisección)\n\n" +
                            $"Raíz aproximada: {raiz:F6}\nError final: {errorFinal:E4}\nIteraciones: {iteraciones}",
                            "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------------------------
        // AUXILIAR SECANTE
        // ---------------------------
        private float CalcularX2(float x0, float x1, float fx0, float fx1)
        {
            if (Math.Abs(fx1 - fx0) < 1e-6)
                throw new Exception("División por cero: f(x1) ≈ f(x0).");

            return x1 - (fx1 * (x1 - x0)) / (fx1 - fx0);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dataIteracion.DataSource == null)
            {
                MessageBox.Show("Primero debe realizar un cálculo antes de exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbSecante.Checked)
                GenerarPDF("Secante", dataIteracion);
            else if (rbBolzano.Checked)
                GenerarPDF("Bolzano", dataIteracion);
            else if (rbRegula.Checked)
                GenerarPDF("Regula_Falsi", dataIteracion);
            else if (rbNewton.Checked)
                GenerarPDF("Newton_Raphson", dataIteracion);
            else
                MessageBox.Show("Seleccione un método antes de exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GenerarPDF(string metodo, DataGridView tabla)
        {
            try
            {
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar a PDF.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Tabla_{metodo}.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Título
                    Paragraph titulo = new Paragraph($"Método de {metodo}\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(titulo);

                    PdfPTable pdfTable = new PdfPTable(tabla.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Encabezados
                    foreach (DataGridViewColumn column in tabla.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }

                    // Filas
                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                                pdfTable.AddCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                            else
                                pdfTable.AddCell("");
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ---------------------------
        // BOTONES Y EVENTOS EXTRA
        // ---------------------------
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtX0.Clear();
            txtX1.Clear();
            txtError.Clear();
            txtFuncion.Clear();
            dataIteracion.DataSource = null;
        }

        private void rbBolzano_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Show();
            pnlNewton.Hide();
        }

        private void rbSecante_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Show();
            pnlNewton.Hide();
        }
        private class IteracionRegula
        {
            public int Iteracion { get; set; }
            public float A { get; set; }
            public float B { get; set; }
            public float FA { get; set; }
            public float FB { get; set; }
            public float Xi { get; set; }
            public float FXi { get; set; }
            public float Error { get; set; }
        }

        private class IteracionNewton
        {
            public int Iteracion { get; set; }
            public float X0 { get; set; }
            public float FX0 { get; set; }
            public float FDX0 { get; set; }
            public float Xi { get; set; }
            public float Error { get; set; }
        }

        private List<IteracionRegula> tablaRegula;

        private void CalcularRegula()
        {
            tablaRegula = new List<IteracionRegula>();

            float a = x0;
            float b = x1;
            float fa = EvaluarFuncion(a);
            float fb = EvaluarFuncion(b);

            if (fa * fb > 0)
                throw new Exception("f(a) y f(b) tienen el mismo signo. No se puede aplicar el método de Regula Falsi.");

            float xi = 0, fxi = 0, errorActual = 1f, xiAnterior = 0;
            int iter = 0;

            while (errorActual > errorDeseado && iter < 100)
            {
                xi = b - (fb * (b - a)) / (fb - fa);
                fxi = EvaluarFuncion(xi);

                if (iter > 0)
                    errorActual = Math.Abs((xi - xiAnterior) / xi);

                tablaRegula.Add(new IteracionRegula
                {
                    Iteracion = iter + 1,
                    A = a,
                    B = b,
                    FA = fa,
                    FB = fb,
                    Xi = xi,
                    FXi = fxi,
                    Error = errorActual
                });

                if (fa * fxi < 0)
                {
                    b = xi;
                    fb = fxi;
                }
                else
                {
                    a = xi;
                    fa = fxi;
                }

                xiAnterior = xi;
                iter++;
            }

            if (errorActual > errorDeseado)
                throw new Exception("No se encontró raíz en 100 iteraciones.");

            iteraciones = iter;
            raiz = xi;
            errorFinal = errorActual;
        }

        private void MostrarResultadosRegula()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Iteración");
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Columns.Add("f(a)");
            dt.Columns.Add("f(b)");
            dt.Columns.Add("Xi");
            dt.Columns.Add("f(Xi)");
            dt.Columns.Add("Error");

            foreach (var iter in tablaRegula)
            {
                dt.Rows.Add(iter.Iteracion, iter.A.ToString("F6"), iter.B.ToString("F6"),
                            iter.FA.ToString("E4"), iter.FB.ToString("E4"),
                            iter.Xi.ToString("F6"), iter.FXi.ToString("E4"), iter.Error.ToString("E4"));
            }

            dataIteracion.DataSource = dt;

            MessageBox.Show($"Método de Regula Falsi\n\n" +
                            $"Raíz aproximada: {raiz:F6}\nError final: {errorFinal:E4}\nIteraciones: {iteraciones}",
                            "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private List<IteracionNewton> tablaNewton;

        private void rbNewton_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Hide();
            pnlNewton.Show();
        }

        private void rbRegula_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Show();
            pnlNewton.Hide();
        }

        private void CalcularNewton()
        {
            tablaNewton = new List<IteracionNewton>();

            float x = x0;
            float xiAnterior, errorActual = 1f;
            int iter = 0;

            while (errorActual > errorDeseado && iter < 100)
            {
                float fx = EvaluarFuncion(x);
                float fdx = DerivarFuncion(x);

                if (Math.Abs(fdx) < 1e-6)
                    throw new Exception("La derivada es cero o muy pequeña. No se puede continuar.");

                float xi = x - fx / fdx;
                if (iter > 0)
                    errorActual = Math.Abs((xi - x) / xi);

                tablaNewton.Add(new IteracionNewton
                {
                    Iteracion = iter + 1,
                    X0 = x,
                    FX0 = fx,
                    FDX0 = fdx,
                    Xi = xi,
                    Error = errorActual
                });

                x = xi;
                iter++;
            }

            if (errorActual > errorDeseado)
                throw new Exception("No se encontró raíz en 100 iteraciones.");

            iteraciones = iter;
            raiz = x;
            errorFinal = errorActual;
        }

        // Derivada numérica central
        private float DerivarFuncion(float x)
        {
            float h = 1e-4f;
            return (EvaluarFuncion(x + h) - EvaluarFuncion(x - h)) / (2 * h);
        }

        private void MostrarResultadosNewton()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Iteración");
            dt.Columns.Add("x0");
            dt.Columns.Add("f(x0)");
            dt.Columns.Add("f'(x0)");
            dt.Columns.Add("xi");
            dt.Columns.Add("Error");

            foreach (var iter in tablaNewton)
            {
                dt.Rows.Add(iter.Iteracion, iter.X0.ToString("F6"), iter.FX0.ToString("E4"),
                            iter.FDX0.ToString("E4"), iter.Xi.ToString("F6"), iter.Error.ToString("E4"));
            }

            dataIteracion.DataSource = dt;

            MessageBox.Show($"Método de Newton-Raphson\n\n" +
                            $"Raíz aproximada: {raiz:F6}\nError final: {errorFinal:E4}\nIteraciones: {iteraciones}",
                            "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MétodosNuméricos
{
    public partial class ctrlRaices : UserControl
    {
        private float x0, x1, errorDeseado;
        private int iteraciones;
        private float raiz, errorFinal;
        private List<IteracionSecante> tablaIteraciones;
        public ctrlRaices()
        {
            InitializeComponent();
            pnlNewton.Hide();
            pnlGeneral.Hide();
        }
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

        private float EvaluarFuncion(float x)
        {
            string funcion = txtFuncion.Text;
            if (string.IsNullOrWhiteSpace(funcion))
                throw new Exception("Debe ingresar una función válida.");

            // Reemplazar '^' por Math.Pow simple
            string expr = funcion.Replace("^", "**").Replace("x", x.ToString(System.Globalization.CultureInfo.InvariantCulture));

            while (expr.Contains("**"))
            {
                int idx = expr.IndexOf("**");
                int start = idx - 1;
                int end = idx + 2;

                string baseNum = expr[start].ToString();
                string exponente = expr[end].ToString();
                string powRepl = Math.Pow(double.Parse(baseNum), double.Parse(exponente)).ToString(System.Globalization.CultureInfo.InvariantCulture);

                expr = expr.Substring(0, start) + powRepl + expr.Substring(end + 1);
            }

            var dt = new DataTable();
            var result = dt.Compute(expr, "");
            return Convert.ToSingle(result);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtX0.Clear();
            txtX1.Clear();
            txtError.Clear();
            txtFuncion.Clear();
            dataIteracion.DataSource = null;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica que haya iteraciones para incluir en el PDF
                if (tablaIteraciones == null || tablaIteraciones.Count == 0)
                {
                    MessageBox.Show("No se han realizado iteraciones. No se puede generar el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crea la ruta y el nombre del archivo PDF
                string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string nombreArchivo = Path.Combine(carpeta, $"Resultados_Secante_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                // Crear el PDF
                using (var fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var doc = new iTextSharp.text.Document())
                using (var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs))
                {
                    doc.Open();

                    // Título
                    var titulo = new iTextSharp.text.Paragraph("Método de la Secante\n\n",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                    titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    // Información general
                    var info = new iTextSharp.text.Paragraph(
                        $"Función: {txtFuncion.Text}\n" +
                        $"x0 = {x0},  x1 = {x1}\n" +
                        $"Error deseado = {errorDeseado}\n" +
                        $"Iteraciones realizadas: {iteraciones}\n" +
                        $"Raíz aproximada: {raiz:F6}\n" +
                        $"Error final: {errorFinal:F6}\n\n",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11));
                    doc.Add(info);

                    // Crear tabla PDF
                    // Usamos el mismo DataTable que se usa en MostrarResultados
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Iteración");
                    dt.Columns.Add("x0");
                    dt.Columns.Add("x1");
                    dt.Columns.Add("f(x0)");
                    dt.Columns.Add("f(x1)");
                    dt.Columns.Add("x2");
                    dt.Columns.Add("ε");

                    // Añadir las filas de la tablaIteraciones
                    foreach (var iter in tablaIteraciones)
                    {
                        dt.Rows.Add(
                            iter.Iteracion,
                            iter.X0.ToString("F6"),
                            iter.XI.ToString("F6"),
                            iter.Fx0.ToString("F6"),
                            iter.FxI.ToString("F6"),
                            iter.X2.ToString("F6"),
                            iter.Error.ToString("F6")
                        );
                    }

                    // Crear la tabla en el PDF con los datos
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(dt.Columns.Count);
                    table.WidthPercentage = 100;

                    // Encabezados
                    foreach (DataColumn col in dt.Columns)
                    {
                        var cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(col.ColumnName))
                        {
                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
                            HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        };
                        table.AddCell(cell);
                    }

                    // Filas
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(new iTextSharp.text.Phrase(item.ToString()));
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                // Mostrar mensaje de éxito
                MessageBox.Show($"El PDF se generó correctamente en:\n{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}",
                                "PDF generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbNewton_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Hide();
            pnlNewton.Show();
        }

        private void rbBolzano_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Show();
            pnlNewton.Hide();
        }

        private void rbRegula_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Show();
            pnlNewton.Hide();
        }

        private void rbSecante_CheckedChanged(object sender, EventArgs e)
        {
            pnlGeneral.Show();
            pnlNewton.Hide();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Confirmación antes de ejecutar el cálculo
            if (MessageBox.Show("Revise por última vez. ¿La función es correcta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Si el usuario responde "No", salimos
            }

            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(txtX0.Text) || string.IsNullOrWhiteSpace(txtX1.Text) ||
                    string.IsNullOrWhiteSpace(txtError.Text) || string.IsNullOrWhiteSpace(txtFuncion.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtX0.Text, out x0) ||
                    !float.TryParse(txtX1.Text, out x1) ||
                    !float.TryParse(txtError.Text, out errorDeseado))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (errorDeseado <= 0)
                {
                    MessageBox.Show("El error debe ser positivo.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ejecutar cálculo
                CalcularSecante();
                MostrarResultados();  // Llamada a la función de mostrar resultados
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error de cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarResultados()
        {
            // Mostrar los resultados de las iteraciones en el DataGridView
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
                dt.Rows.Add(
                    iter.Iteracion,
                    iter.X0.ToString("F6"),
                    iter.XI.ToString("F6"),
                    iter.Fx0.ToString("F6"),
                    iter.FxI.ToString("F6"),
                    iter.X2.ToString("F6"),
                    iter.Error.ToString("F6")
                );
            }

            // Asignar el DataTable al DataGridView
            dataIteracion.DataSource = dt;

            // Mostrar el resumen en un MessageBox
            string resumen = $"Método de la Secante\n\n" +
                             $"Función: {txtFuncion.Text}\n" +
                             $"x0 = {x0},  x1 = {x1}\n" +
                             $"Error deseado = {errorDeseado}\n\n" +
                             $"Iteraciones realizadas: {iteraciones}\n" +
                             $"Raíz aproximada: {raiz:F6}\n" +
                             $"Error final: {errorFinal:F6}";

            MessageBox.Show(resumen, "Resumen del cálculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private float CalcularX2(float x0, float x1, float fx0, float fx1)
        {
            if (Math.Abs(fx1 - fx0) < 1e-6)
                throw new Exception("División por cero: f(x1) ≈ f(x0).");

            return x1 - (fx1 * (x1 - x0)) / (fx1 - fx0);
        }
    }
}

namespace MétodosNuméricos
{
    partial class ctrlRaices
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.lblFunción = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.dataIteracion = new System.Windows.Forms.DataGridView();
            this.gbMétodos = new System.Windows.Forms.GroupBox();
            this.rbSecante = new System.Windows.Forms.RadioButton();
            this.rbNewton = new System.Windows.Forms.RadioButton();
            this.rbRegula = new System.Windows.Forms.RadioButton();
            this.rbBolzano = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.pnlNewton = new System.Windows.Forms.Panel();
            this.txtXNewton = new System.Windows.Forms.TextBox();
            this.lblXNewton = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataIteracion)).BeginInit();
            this.gbMétodos.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.pnlNewton.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFuncion
            // 
            this.txtFuncion.Location = new System.Drawing.Point(112, 40);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.Size = new System.Drawing.Size(176, 22);
            this.txtFuncion.TabIndex = 0;
            // 
            // lblFunción
            // 
            this.lblFunción.AutoSize = true;
            this.lblFunción.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunción.Location = new System.Drawing.Point(19, 40);
            this.lblFunción.Name = "lblFunción";
            this.lblFunción.Size = new System.Drawing.Size(87, 24);
            this.lblFunción.TabIndex = 1;
            this.lblFunción.Text = "Función:";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRango.Location = new System.Drawing.Point(6, 11);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(106, 24);
            this.lblRango.TabIndex = 3;
            this.lblRango.Text = "[        ,        ]";
            // 
            // txtX0
            // 
            this.txtX0.Location = new System.Drawing.Point(19, 14);
            this.txtX0.Name = "txtX0";
            this.txtX0.Size = new System.Drawing.Size(31, 22);
            this.txtX0.TabIndex = 4;
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(66, 14);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(31, 22);
            this.txtX1.TabIndex = 5;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(19, 78);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(57, 24);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "Error:";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(112, 77);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(175, 22);
            this.txtError.TabIndex = 7;
            // 
            // dataIteracion
            // 
            this.dataIteracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataIteracion.Location = new System.Drawing.Point(3, 207);
            this.dataIteracion.Name = "dataIteracion";
            this.dataIteracion.RowHeadersWidth = 51;
            this.dataIteracion.RowTemplate.Height = 24;
            this.dataIteracion.Size = new System.Drawing.Size(641, 196);
            this.dataIteracion.TabIndex = 8;
            // 
            // gbMétodos
            // 
            this.gbMétodos.Controls.Add(this.rbSecante);
            this.gbMétodos.Controls.Add(this.rbNewton);
            this.gbMétodos.Controls.Add(this.rbRegula);
            this.gbMétodos.Controls.Add(this.rbBolzano);
            this.gbMétodos.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMétodos.Location = new System.Drawing.Point(296, 48);
            this.gbMétodos.Name = "gbMétodos";
            this.gbMétodos.Size = new System.Drawing.Size(353, 100);
            this.gbMétodos.TabIndex = 9;
            this.gbMétodos.TabStop = false;
            this.gbMétodos.Text = "Métodos:";
            // 
            // rbSecante
            // 
            this.rbSecante.AutoSize = true;
            this.rbSecante.Font = new System.Drawing.Font("Montserrat Medium", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbSecante.Location = new System.Drawing.Point(156, 61);
            this.rbSecante.Name = "rbSecante";
            this.rbSecante.Size = new System.Drawing.Size(98, 26);
            this.rbSecante.TabIndex = 3;
            this.rbSecante.TabStop = true;
            this.rbSecante.Text = "Secante";
            this.rbSecante.UseVisualStyleBackColor = true;
            this.rbSecante.CheckedChanged += new System.EventHandler(this.rbSecante_CheckedChanged);
            // 
            // rbNewton
            // 
            this.rbNewton.AutoSize = true;
            this.rbNewton.Font = new System.Drawing.Font("Montserrat Medium", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbNewton.Location = new System.Drawing.Point(156, 27);
            this.rbNewton.Name = "rbNewton";
            this.rbNewton.Size = new System.Drawing.Size(175, 26);
            this.rbNewton.TabIndex = 2;
            this.rbNewton.TabStop = true;
            this.rbNewton.Text = "Newton-Raphson";
            this.rbNewton.UseVisualStyleBackColor = true;
            this.rbNewton.CheckedChanged += new System.EventHandler(this.rbNewton_CheckedChanged);
            // 
            // rbRegula
            // 
            this.rbRegula.AutoSize = true;
            this.rbRegula.Font = new System.Drawing.Font("Montserrat Medium", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbRegula.Location = new System.Drawing.Point(7, 62);
            this.rbRegula.Name = "rbRegula";
            this.rbRegula.Size = new System.Drawing.Size(129, 26);
            this.rbRegula.TabIndex = 1;
            this.rbRegula.TabStop = true;
            this.rbRegula.Text = "Regula Falsi";
            this.rbRegula.UseVisualStyleBackColor = true;
            this.rbRegula.CheckedChanged += new System.EventHandler(this.rbRegula_CheckedChanged);
            // 
            // rbBolzano
            // 
            this.rbBolzano.AutoSize = true;
            this.rbBolzano.Font = new System.Drawing.Font("Montserrat Medium", 9.5F, System.Drawing.FontStyle.Bold);
            this.rbBolzano.Location = new System.Drawing.Point(7, 28);
            this.rbBolzano.Name = "rbBolzano";
            this.rbBolzano.Size = new System.Drawing.Size(96, 26);
            this.rbBolzano.TabIndex = 0;
            this.rbBolzano.TabStop = true;
            this.rbBolzano.Text = "Bolzano";
            this.rbBolzano.UseVisualStyleBackColor = true;
            this.rbBolzano.CheckedChanged += new System.EventHandler(this.rbBolzano_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(136, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(358, 27);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Raíces de funciones polinomiales";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(19, 172);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(87, 30);
            this.btnCalcular.TabIndex = 11;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(141, 172);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 30);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Location = new System.Drawing.Point(472, 172);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(155, 30);
            this.btnPDF.TabIndex = 13;
            this.btnPDF.Text = "Generar PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.txtX1);
            this.pnlGeneral.Controls.Add(this.txtX0);
            this.pnlGeneral.Controls.Add(this.lblRango);
            this.pnlGeneral.Location = new System.Drawing.Point(142, 108);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(121, 43);
            this.pnlGeneral.TabIndex = 14;
            // 
            // pnlNewton
            // 
            this.pnlNewton.Controls.Add(this.txtXNewton);
            this.pnlNewton.Controls.Add(this.lblXNewton);
            this.pnlNewton.Location = new System.Drawing.Point(19, 110);
            this.pnlNewton.Name = "pnlNewton";
            this.pnlNewton.Size = new System.Drawing.Size(94, 41);
            this.pnlNewton.TabIndex = 15;
            // 
            // txtXNewton
            // 
            this.txtXNewton.Location = new System.Drawing.Point(56, 12);
            this.txtXNewton.Name = "txtXNewton";
            this.txtXNewton.Size = new System.Drawing.Size(31, 22);
            this.txtXNewton.TabIndex = 6;
            // 
            // lblXNewton
            // 
            this.lblXNewton.AutoSize = true;
            this.lblXNewton.Font = new System.Drawing.Font("Montserrat Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXNewton.Location = new System.Drawing.Point(9, 12);
            this.lblXNewton.Name = "lblXNewton";
            this.lblXNewton.Size = new System.Drawing.Size(41, 24);
            this.lblXNewton.TabIndex = 16;
            this.lblXNewton.Text = "X0=";
            // 
            // ctrlRaices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNewton);
            this.Controls.Add(this.pnlGeneral);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbMétodos);
            this.Controls.Add(this.dataIteracion);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblFunción);
            this.Controls.Add(this.txtFuncion);
            this.Name = "ctrlRaices";
            this.Size = new System.Drawing.Size(649, 408);
            ((System.ComponentModel.ISupportInitialize)(this.dataIteracion)).EndInit();
            this.gbMétodos.ResumeLayout(false);
            this.gbMétodos.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            this.pnlNewton.ResumeLayout(false);
            this.pnlNewton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.Label lblFunción;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.DataGridView dataIteracion;
        private System.Windows.Forms.GroupBox gbMétodos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbRegula;
        private System.Windows.Forms.RadioButton rbBolzano;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.RadioButton rbSecante;
        private System.Windows.Forms.RadioButton rbNewton;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.Panel pnlNewton;
        private System.Windows.Forms.TextBox txtXNewton;
        private System.Windows.Forms.Label lblXNewton;
    }
}

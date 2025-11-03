namespace MétodosNuméricos
{
    partial class fmMétodos
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHome = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMenú = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSistemas = new System.Windows.Forms.Button();
            this.btnIntegracion = new System.Windows.Forms.Button();
            this.btnRaices = new System.Windows.Forms.Button();
            this.btnDerivacion = new System.Windows.Forms.Button();
            this.ctrlRaices = new MétodosNuméricos.ctrlRaices();
            this.ctrlSistmas = new MétodosNuméricos.ctrlEcuaciones();
            this.pnlMenú.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Image = global::MétodosNuméricos.Properties.Resources.home_40dp_000000_FILL0_wght400_GRAD0_opsz40;
            this.btnHome.Location = new System.Drawing.Point(23, 38);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(50, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(255, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(304, 34);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Cerrar el programa";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMenú
            // 
            this.pnlMenú.Controls.Add(this.label1);
            this.pnlMenú.Controls.Add(this.btnSistemas);
            this.pnlMenú.Controls.Add(this.btnIntegracion);
            this.pnlMenú.Controls.Add(this.btnRaices);
            this.pnlMenú.Controls.Add(this.btnDerivacion);
            this.pnlMenú.Location = new System.Drawing.Point(149, 72);
            this.pnlMenú.Name = "pnlMenú";
            this.pnlMenú.Size = new System.Drawing.Size(503, 307);
            this.pnlMenú.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 32);
            this.label1.TabIndex = 92;
            this.label1.Text = "Seleccione el tipo de ejercicio";
            // 
            // btnSistemas
            // 
            this.btnSistemas.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnSistemas.Location = new System.Drawing.Point(12, 66);
            this.btnSistemas.Name = "btnSistemas";
            this.btnSistemas.Size = new System.Drawing.Size(235, 112);
            this.btnSistemas.TabIndex = 88;
            this.btnSistemas.Text = "Sistemas de ecuaciones";
            this.btnSistemas.UseVisualStyleBackColor = true;
            this.btnSistemas.Click += new System.EventHandler(this.btnSistemas_Click);
            // 
            // btnIntegracion
            // 
            this.btnIntegracion.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnIntegracion.Location = new System.Drawing.Point(253, 184);
            this.btnIntegracion.Name = "btnIntegracion";
            this.btnIntegracion.Size = new System.Drawing.Size(235, 112);
            this.btnIntegracion.TabIndex = 91;
            this.btnIntegracion.Text = "Integración numérica";
            this.btnIntegracion.UseVisualStyleBackColor = true;
            this.btnIntegracion.Click += new System.EventHandler(this.btnIntegracion_Click);
            // 
            // btnRaices
            // 
            this.btnRaices.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnRaices.Location = new System.Drawing.Point(253, 66);
            this.btnRaices.Name = "btnRaices";
            this.btnRaices.Size = new System.Drawing.Size(235, 112);
            this.btnRaices.TabIndex = 89;
            this.btnRaices.Text = "Raíces de funciones polinomiales";
            this.btnRaices.UseVisualStyleBackColor = true;
            this.btnRaices.Click += new System.EventHandler(this.btnRaices_Click);
            // 
            // btnDerivacion
            // 
            this.btnDerivacion.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnDerivacion.Location = new System.Drawing.Point(12, 184);
            this.btnDerivacion.Name = "btnDerivacion";
            this.btnDerivacion.Size = new System.Drawing.Size(235, 112);
            this.btnDerivacion.TabIndex = 90;
            this.btnDerivacion.Text = "Derivación numérica";
            this.btnDerivacion.UseVisualStyleBackColor = true;
            this.btnDerivacion.Click += new System.EventHandler(this.btnDerivacion_Click);
            // 
            // ctrlRaices
            // 
            this.ctrlRaices.Location = new System.Drawing.Point(79, 38);
            this.ctrlRaices.Name = "ctrlRaices";
            this.ctrlRaices.Size = new System.Drawing.Size(649, 386);
            this.ctrlRaices.TabIndex = 95;
            // 
            // ctrlSistmas
            // 
            this.ctrlSistmas.Location = new System.Drawing.Point(126, 72);
            this.ctrlSistmas.Name = "ctrlSistmas";
            this.ctrlSistmas.Size = new System.Drawing.Size(563, 291);
            this.ctrlSistmas.TabIndex = 93;
            // 
            // fmMétodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMenú);
            this.Controls.Add(this.ctrlRaices);
            this.Controls.Add(this.ctrlSistmas);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHome);
            this.Name = "fmMétodos";
            this.Text = "Métodos numéricos";
            this.pnlMenú.ResumeLayout(false);
            this.pnlMenú.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnClose;
        private ctrlEcuaciones ctrlSistmas;
        private ctrlRaices ctrlRaices;
        private System.Windows.Forms.Panel pnlMenú;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSistemas;
        private System.Windows.Forms.Button btnIntegracion;
        private System.Windows.Forms.Button btnRaices;
        private System.Windows.Forms.Button btnDerivacion;
    }
}


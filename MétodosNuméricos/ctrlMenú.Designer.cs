namespace MétodosNuméricos
{
    partial class ctrlMenú
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
            this.btnSistemas = new System.Windows.Forms.Button();
            this.btnRaices = new System.Windows.Forms.Button();
            this.btnDerivacion = new System.Windows.Forms.Button();
            this.btnIntegracion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSistemas
            // 
            this.btnSistemas.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnSistemas.Location = new System.Drawing.Point(3, 49);
            this.btnSistemas.Name = "btnSistemas";
            this.btnSistemas.Size = new System.Drawing.Size(235, 112);
            this.btnSistemas.TabIndex = 83;
            this.btnSistemas.Text = "Sistemas de ecuaciones";
            this.btnSistemas.UseVisualStyleBackColor = true;
            this.btnSistemas.Click += new System.EventHandler(this.btnSistemas_Click);
            // 
            // btnRaices
            // 
            this.btnRaices.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnRaices.Location = new System.Drawing.Point(244, 49);
            this.btnRaices.Name = "btnRaices";
            this.btnRaices.Size = new System.Drawing.Size(235, 112);
            this.btnRaices.TabIndex = 84;
            this.btnRaices.Text = "Raíces de funciones polinomiales";
            this.btnRaices.UseVisualStyleBackColor = true;
            this.btnRaices.Click += new System.EventHandler(this.btnRaices_Click);
            // 
            // btnDerivacion
            // 
            this.btnDerivacion.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnDerivacion.Location = new System.Drawing.Point(3, 167);
            this.btnDerivacion.Name = "btnDerivacion";
            this.btnDerivacion.Size = new System.Drawing.Size(235, 112);
            this.btnDerivacion.TabIndex = 85;
            this.btnDerivacion.Text = "Derivación numérica";
            this.btnDerivacion.UseVisualStyleBackColor = true;
            this.btnDerivacion.Click += new System.EventHandler(this.btnDerivacion_Click);
            // 
            // btnIntegracion
            // 
            this.btnIntegracion.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold);
            this.btnIntegracion.Location = new System.Drawing.Point(244, 167);
            this.btnIntegracion.Name = "btnIntegracion";
            this.btnIntegracion.Size = new System.Drawing.Size(235, 112);
            this.btnIntegracion.TabIndex = 86;
            this.btnIntegracion.Text = "Integración numérica";
            this.btnIntegracion.UseVisualStyleBackColor = true;
            this.btnIntegracion.Click += new System.EventHandler(this.btnIntegracion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 32);
            this.label1.TabIndex = 87;
            this.label1.Text = "Seleccione el tipo de ejercicio";
            // 
            // ctrlMenú
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIntegracion);
            this.Controls.Add(this.btnDerivacion);
            this.Controls.Add(this.btnRaices);
            this.Controls.Add(this.btnSistemas);
            this.Name = "ctrlMenú";
            this.Size = new System.Drawing.Size(481, 280);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSistemas;
        private System.Windows.Forms.Button btnRaices;
        private System.Windows.Forms.Button btnDerivacion;
        private System.Windows.Forms.Button btnIntegracion;
        private System.Windows.Forms.Label label1;
    }
}

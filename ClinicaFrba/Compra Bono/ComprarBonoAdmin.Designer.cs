namespace ClinicaFrba.Compra_Bono
{
    partial class ComprarBonoAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txBoxNumeroAfiliado = new System.Windows.Forms.TextBox();
            this.resu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(10, 42);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(99, 13);
            this.lblNumeroAfiliado.TabIndex = 7;
            this.lblNumeroAfiliado.Text = "Número de Afiliado:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(13, 84);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(139, 83);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 24);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txBoxNumeroAfiliado
            // 
            this.txBoxNumeroAfiliado.Location = new System.Drawing.Point(116, 42);
            this.txBoxNumeroAfiliado.Name = "txBoxNumeroAfiliado";
            this.txBoxNumeroAfiliado.Size = new System.Drawing.Size(100, 20);
            this.txBoxNumeroAfiliado.TabIndex = 10;
            this.txBoxNumeroAfiliado.TextChanged += new System.EventHandler(this.txBoxNumeroAfiliado_TextChanged);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(22, 13);
            this.result.Name = "resu";
            this.result.Size = new System.Drawing.Size(35, 13);
            this.result.TabIndex = 11;
            this.result.Text = "label1";
            this.result.Visible = false;
            // 
            // VentanaIntermedioAdministrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 135);
            this.Controls.Add(this.result);
            this.Controls.Add(this.txBoxNumeroAfiliado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNumeroAfiliado);
            this.Name = "VentanaIntermedioAdministrativo";
            this.Text = "Ingrese Afiliado";
            this.Load += new System.EventHandler(this.ComprarBonoAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txBoxNumeroAfiliado;
        private System.Windows.Forms.Label result;
    }
}
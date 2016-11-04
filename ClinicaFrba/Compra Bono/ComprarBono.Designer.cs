namespace ClinicaFrba.Compra_Bono
{
    partial class ComprarBono
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
            this.label1 = new System.Windows.Forms.Label();
            this.numCantBonos = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalNum = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCompraAfiliado = new System.Windows.Forms.Label();
            this.lblNombreAfiliado = new System.Windows.Forms.Label();
            this.lblprecioBono = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCantBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad";
            // 
            // numCantBonos
            // 
            this.numCantBonos.Location = new System.Drawing.Point(112, 119);
            this.numCantBonos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numCantBonos.Name = "numCantBonos";
            this.numCantBonos.Size = new System.Drawing.Size(82, 26);
            this.numCantBonos.TabIndex = 1;
            this.numCantBonos.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(18, 235);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 20);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total a Pagar:   $";
            // 
            // lblTotalNum
            // 
            this.lblTotalNum.AutoSize = true;
            this.lblTotalNum.Location = new System.Drawing.Point(147, 235);
            this.lblTotalNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size(18, 20);
            this.lblTotalNum.TabIndex = 3;
            this.lblTotalNum.Text = "0";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(24, 285);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 35);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(180, 285);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 35);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCompraAfiliado
            // 
            this.lblCompraAfiliado.AutoSize = true;
            this.lblCompraAfiliado.Location = new System.Drawing.Point(20, 32);
            this.lblCompraAfiliado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompraAfiliado.Name = "lblCompraAfiliado";
            this.lblCompraAfiliado.Size = new System.Drawing.Size(175, 20);
            this.lblCompraAfiliado.TabIndex = 6;
            this.lblCompraAfiliado.Text = "Compra para el afiliado:";
            // 
            // lblNombreAfiliado
            // 
            this.lblNombreAfiliado.AutoSize = true;
            this.lblNombreAfiliado.Location = new System.Drawing.Point(20, 72);
            this.lblNombreAfiliado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreAfiliado.Name = "lblNombreAfiliado";
            this.lblNombreAfiliado.Size = new System.Drawing.Size(121, 20);
            this.lblNombreAfiliado.TabIndex = 7;
            this.lblNombreAfiliado.Text = "Nombre Afiliado";
            this.lblNombreAfiliado.Click += new System.EventHandler(this.lblNombreAfiliado_Click);
            // 
            // lblprecioBono
            // 
            this.lblprecioBono.AutoSize = true;
            this.lblprecioBono.Location = new System.Drawing.Point(20, 180);
            this.lblprecioBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblprecioBono.Name = "lblprecioBono";
            this.lblprecioBono.Size = new System.Drawing.Size(208, 20);
            this.lblprecioBono.TabIndex = 8;
            this.lblprecioBono.Text = "Precio Unitario del Bono:   $ ";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(231, 180);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(18, 20);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "0";
            // 
            // ComprarBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 352);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblprecioBono);
            this.Controls.Add(this.lblNombreAfiliado);
            this.Controls.Add(this.lblCompraAfiliado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTotalNum);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.numCantBonos);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ComprarBono";
            this.Text = "Compra de Bono";
            ((System.ComponentModel.ISupportInitialize)(this.numCantBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCantBonos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalNum;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCompraAfiliado;
        private System.Windows.Forms.Label lblNombreAfiliado;
        private System.Windows.Forms.Label lblprecioBono;
        private System.Windows.Forms.Label lblMonto;
    }
}
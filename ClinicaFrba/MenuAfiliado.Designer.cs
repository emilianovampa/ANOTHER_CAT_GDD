namespace ClinicaFrba
{
    partial class MenuAfiliado
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarBonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedirTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.procesoToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Afiliado";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // procesoToolStripMenuItem
            // 
            this.procesoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprarBonoToolStripMenuItem,
            this.pedirTurnoToolStripMenuItem,
            this.cancelarTurnoToolStripMenuItem});
            this.procesoToolStripMenuItem.Name = "procesoToolStripMenuItem";
            this.procesoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.procesoToolStripMenuItem.Text = "Proceso";
            // 
            // comprarBonoToolStripMenuItem
            // 
            this.comprarBonoToolStripMenuItem.Name = "comprarBonoToolStripMenuItem";
            this.comprarBonoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.comprarBonoToolStripMenuItem.Text = "Comprar Bono";
            this.comprarBonoToolStripMenuItem.Click += new System.EventHandler(this.comprarBonoToolStripMenuItem_Click);
            // 
            // pedirTurnoToolStripMenuItem
            // 
            this.pedirTurnoToolStripMenuItem.Name = "pedirTurnoToolStripMenuItem";
            this.pedirTurnoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pedirTurnoToolStripMenuItem.Text = "Pedir Turno";
            this.pedirTurnoToolStripMenuItem.Click += new System.EventHandler(this.pedirTurnoToolStripMenuItem_Click);
            // 
            // cancelarTurnoToolStripMenuItem
            // 
            this.cancelarTurnoToolStripMenuItem.Name = "cancelarTurnoToolStripMenuItem";
            this.cancelarTurnoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.cancelarTurnoToolStripMenuItem.Text = "Cancelar Turno";
            this.cancelarTurnoToolStripMenuItem.Click += new System.EventHandler(this.cancelarTurnoToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // MenuAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 429);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuAfiliado";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuAfiliado_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarBonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedirTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
    }
}
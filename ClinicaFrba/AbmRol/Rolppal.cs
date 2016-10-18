using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Rolppal : Form
    {
        public Rolppal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosRol AltaRol = new DatosRol();
            AltaRol.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Rolppal_Load(object sender, EventArgs e)
        {

        }
    }
}

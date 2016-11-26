using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {

        private int idEspecialidad;
        private string doctorElegido;
        private int idDoctor;
        private int idAfiliado;

        // Esta query busca todos el ID, nombre y apellido de cada profesional ademas de su especialidad y el ID de la misma
        private string queryLoadTable = "SELECT u.Apellido AS Apellido, u.USername AS Nombre, u.ID_Usuario, e.Descripcion AS Especialidad, e.ID_Especialidad FROM [GD2C2016].[ANOTHER_CAT].tl_Usuario u, [GD2C2016].[ANOTHER_CAT].tl_Profesional p, [GD2C2016].[ANOTHER_CAT].tl_Profesional_Especialidad ep, [GD2C2016].[ANOTHER_CAT].tl_Especialidad e WHERE (u.ID_Usuario = p.ID_Usuario) AND (p.ID_Usuario = ep.ID_Usuario) AND (ep.Codigo_Especialidad = e.ID_Especialidad)";


        
        public PedirTurno(int id)
        {
            // Set id afiliado
            this.idAfiliado = id;
            InitializeComponent();

            // Cargo el DataGrid
            Conexion.loadDataGrid(queryLoadTable, dataGridView1);

            // Escondo las columnas de ID, me viene bien tenerlos a mano pero no quiero que el usuario los vea
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        // Funcion de busqueda
        private void button1_Click(object sender, EventArgs e)
        {
            // Query usada para settear el DataGrid
            string newQuery = this.queryLoadTable;

            //strings del textBox
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string especialidad = textBox3.Text;

            // Me fijo que casilleros fueron checkeados y modifico la primera query
            if (checkBox1.Checked) newQuery += " AND (u.Username LIKE '%" + nombre + "%')";
            if (checkBox2.Checked) newQuery += " AND (u.Apellido LIKE '%" + apellido + "%')";
            if (checkBox3.Checked) newQuery += " AND (e.Descripcion LIKE '%" + especialidad + "%')";

            // Vuelvo a cargar el DataGrid
            Conexion.loadDataGrid(newQuery, dataGridView1);
        }



        // Funcion de eleccion de profesional y especialidad por click en el DataGrid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Me fijo que el usuario no haya clickeado el nombre de la columna
            if (e.RowIndex >= 0)
            {
                // Tomo toda la informacion de la fila que fue clickeada
                object apellido = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                object nombre = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                object idPro = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                object especialidad = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                object idEsp = dataGridView1.Rows[e.RowIndex].Cells[4].Value;

                // Setteo las variables
                doctorElegido = apellido.ToString();
                this.idDoctor = int.Parse(idPro.ToString());
                this.idEspecialidad = int.Parse(idEsp.ToString());

                // Modifico la ventana para reflejar la eleccion del usuario
                label1.Text = "Profesional Elegido: " + doctorElegido + ", " + nombreBienEscrito(nombre);
                label6.Text = "Especialidad Elegida: " + especialidad.ToString();
            }
        }




        // Funcion para pasar a elegir el turno
        private void button3_Click(object sender, EventArgs e)
        {
            // Si elegi un doctor
            if (doctorElegido != null)
            {
                // Creo una nueva ventana para elegir horario con los datos que necesita
                ElegirHorario eh = new ElegirHorario(doctorElegido, idDoctor, idAfiliado, idEspecialidad);

                // Escondo esta venta
                this.Hide();

                // Y modifico a la nueva ventana para que al cerrarse cierre esta tambien
                eh.Closed += (s, args) => this.Close();
                eh.Show();
            }
            else MessageBox.Show("No ha seleccionado un profesional", "Error", MessageBoxButtons.OK);
        }




        // Funcion para propositos esteticos nomas
        private string nombreBienEscrito(object nombre)
        {
            string nombreString = nombre.ToString();
            char primerLetra = nombreString[0];
            string elResto = nombreString.Remove(0, 1).ToLower();
            string todoJunto = primerLetra + elResto;
            return todoJunto;
        }

    }
}

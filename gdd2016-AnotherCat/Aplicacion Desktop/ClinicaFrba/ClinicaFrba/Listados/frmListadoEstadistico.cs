﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using Clases;
using System.Data.SqlClient;

namespace ClinicaFrba.Listados
{
    public partial class frmListadoEstadistico : Form
    {
        DateTime fecha1;
        DateTime fecha2;


        public frmListadoEstadistico()
        {
            InitializeComponent();
            dtpAnio.Format = DateTimePickerFormat.Custom;
            dtpAnio.CustomFormat = "yyyy";
            dtpAnio.ShowUpDown = true;
        }

        private void frmListadoEstadistico_Load(object sender, EventArgs e)
        {
            
            Main acerrar = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Main")
                {
                    acerrar = (Main)frm;

                }
            }
            if (acerrar != null)
            {
                acerrar.Hide();
            }
        }

        #region LOADS
        private void Load_Listado_1(List<Listado_1> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Especialidad_descripcion",
                HeaderText = "Especialidad",
                Width = 200,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Cancelaciones",
                Width = 150,
                ReadOnly = true
            });
        }
        private void Load_Listado_2(List<Listado_2> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Matricula",
                HeaderText = "Matricula",
                Width = 70,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad",
                Width = 170,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Consultas",
                Width = 128,
                ReadOnly = true
            });
        }
        private void Load_Listado_3(List<Listado_3> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Matricula",
                HeaderText = "Matricula",
                Width = 70,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 128,
                ReadOnly = true
            });             
           dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Horas",
                Width = 128,
                ReadOnly = true
            });
        }
        private void Load_Listado_4(List<Listado_4> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NroAfiliado",
                HeaderText = "NroAfiliado",
                Width = 70,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Grupo_Familiar",
                HeaderText = "Pertenece a un grupo familiar",
                Width = 170,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Bonos",
                Width = 128,
                ReadOnly = true
            });
        }
        private void Load_Listado_5(List<Listado_5> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Especialidad_descripcion",
                HeaderText = "Especialidad",
                Width = 200,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Bonos",
                Width = 128,
                ReadOnly = true
            });
        }
        #endregion

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbSemestre.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un semestre", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cmbSemestre.SelectedIndex.Equals(0))
            {
                fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 1, 1);     //  formato año/mes/dia - no se porque
                fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 7, 1);
                if(comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Todos"){
                    if (comboBox1.SelectedIndex == 1)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 1, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text),1,31);
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 2, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 2, 28);
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 3, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 3, 31);
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 4, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 4, 30);
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 5, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 5, 31);
                    }
                    else if (comboBox1.SelectedIndex == 6)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 6, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 6, 30);
                    }
                }
            }
            else if (cmbSemestre.SelectedIndex.Equals(1))
            {
                fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 7, 1);
                fecha2 = new DateTime(Int32.Parse(dtpAnio.Text) + 1, 1, 1);
                if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Todos")
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 7, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 7, 31);
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 8, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 8, 31);
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 9, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 9, 30);
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 10, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 10, 31);
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 11, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 11, 30);
                    }
                    else if (comboBox1.SelectedIndex == 6)
                    {
                        fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 12, 1);
                        fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 12, 31);
                    }
                }
            }
            
            try
            {
                switch (cmbTipo.SelectedIndex)
                {
                    case 0:
                        if (cmb_filtro.SelectedItem.Equals("Afiliado"))
                        {
                            List<Listado_1> lista_1 = ConexionesDB.ExecuteReader("listado_Mas_Cancelaciones_Especialidad_Afiliado", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_1();
                            Load_Listado_1(lista_1);
                        }
                        if (cmb_filtro.SelectedItem.Equals("Profesional"))
                        {
                            List<Listado_1> lista_1 = ConexionesDB.ExecuteReader("listado_Mas_Cancelaciones_Especialidad_Profesional", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_1();
                            Load_Listado_1(lista_1);
                        }
                        if (cmb_filtro.SelectedItem.Equals("Ambos"))
                        {
                            List<Listado_1> lista_1 = ConexionesDB.ExecuteReader("listado_Mas_Cancelaciones_Especialidad", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_1();
                            Load_Listado_1(lista_1);
                        }

                        
                        break;
                    case 1:
                        var parametros = new Dictionary<string, object> { 
                            { "@fecha1", fecha1 }, 
                            { "@fecha2", fecha2 }, 
                            { "@plan", ((Plan)cmb_filtro.SelectedItem).Descripcion },
                            };
                        List<Listado_2> lista_2 = ConexionesDB.ExecuteReader("listado_Profesionales_Consultados", parametros).ToListado_2();
                        Load_Listado_2(lista_2);
                        break;
                    case 2:
                        parametros = new Dictionary<string, object> { 
                            { "@fecha1", fecha1 }, 
                            { "@fecha2", fecha2 },
                            { "@especialidad ", ((Especialidad)cmb_filtro.SelectedItem).Descripcion } 
                            };
                        List<Listado_3> lista_3 = ConexionesDB.ExecuteReader("listado_Profesionales_Menos_Horas", parametros).ToListado_3();
                        Load_Listado_3(lista_3);
                        break;
                    case 3:
                        List<Listado_4> lista_4 = ConexionesDB.ExecuteReader("listado_Afiliado_Mas_Bonos", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_4();
                        Load_Listado_4(lista_4);
                        break;
                    case 4:
                        List<Listado_5> lista_5 = ConexionesDB.ExecuteReader("listado_Especialidad_Mas_Bonos", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_5();
                        Load_Listado_5(lista_5);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Error al obtener datos de db", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void funcion_para_listado_1()
        {
            List<string> filtro = new List<string>();
            filtro.Add("Afiliado");
            filtro.Add("Profesional");
            filtro.Add("Ambos");
            cmb_filtro.DataSource = filtro;
        }
        public void funcion_para_listado_2()
        {
            List<Plan> planes = ConexionesDB.ExecuteReader("Planes_GetAll").ToPlanes();
            cmb_filtro.DataSource = planes;
            cmb_filtro.DisplayMember = "Descripcion";
        }

        public void funcion_para_listado_3()
        {
            List<Especialidad> especialidad = ConexionesDB.ExecuteReader("Get_Especialidades_All_2").ToEspecialidad();
            cmb_filtro.DataSource = especialidad;
            cmb_filtro.DisplayMember = "Descripcion";

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbTipo.SelectedIndex)
            {
                case 0:
                    label_filtro.Visible = cmb_filtro.Visible = true;
                    label_filtro.Text = "Filtro";
                    funcion_para_listado_1();
                    break;
                case 1:
                    label_filtro.Visible = cmb_filtro.Visible = true;
                    label_filtro.Text = "Plan";
                    funcion_para_listado_2();
                    break;
                case 2:
                    label_filtro.Visible = cmb_filtro.Visible = true;
                    label_filtro.Text = "Especialidad";
                    funcion_para_listado_3();
                    break;
                default:
                    label_filtro.Visible = cmb_filtro.Visible = false;
                    break;
            }
        }

        private void frmListadoEstadistico_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main aabrir = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Main")
                {
                    aabrir = (Main)frm;

                }
            }
            if (aabrir != null)
            {
                aabrir.Show();
            }
        }

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemestre.SelectedItem.ToString() == "1")
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Todos");
                comboBox1.Items.Add(1);
                comboBox1.Items.Add(2);
                comboBox1.Items.Add(3);
                comboBox1.Items.Add(4);
                comboBox1.Items.Add(5);
                comboBox1.Items.Add(6);
            }
            else if (cmbSemestre.SelectedItem.ToString() == "2")
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Todos");
                comboBox1.Items.Add(7);
                comboBox1.Items.Add(8);
                comboBox1.Items.Add(9);
                comboBox1.Items.Add(10);
                comboBox1.Items.Add(11);
                comboBox1.Items.Add(12);
            }
        }

    }
}

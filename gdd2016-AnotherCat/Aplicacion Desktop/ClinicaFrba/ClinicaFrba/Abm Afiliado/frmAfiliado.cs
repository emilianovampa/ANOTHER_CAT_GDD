﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Helpers;
using System.Configuration;
namespace ClinicaFrba.Abm_Afiliado
{
    public partial class frmAfiliado : Form
    {
        //OPCION 1 ES ALTA AFILIADO OPCION 2 ES MODIFICAR AFILIADO (ES EN LA MISMA PANTALLA)
        public static Usuario usuario;
        public static Plan planactual;
        public static Rol rol;
        public static Afiliado afiliadoModificar;
        public int opcionelegida;
        public int i = 0;
        public frmAfiliado(Usuario us, Rol ro, Afiliado afil, int opcion)
        {
            InitializeComponent();
            usuario = us;
            rol = ro;
            afiliadoModificar = afil;
            opcionelegida = opcion;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtApellido.CharacterCasing = CharacterCasing.Normal;
            if (opcion == 1)/*DANDO DE ALTA UN AFILIADO*/
            {
                lblEstado.Visible = false;
                ckbEstado.Visible = false;
                btnHabilitar.Visible = false;
                cargarPlanes();
                cmbPlan.Enabled = true;
                button1.Visible = false;/*
                cmbSexo.SelectedText = "No especificado";
                cmbEstadoCivil.SelectedValue = "No Especifica";*/
            }
            else if (opcion == 2) /*MODIFICANDO USUARIO*/
            {
                
                comboBox1.Enabled = false;
                comboBox1.Text = reconocerTipoDni(afiliadoModificar);
                txtNombre.Text = afiliadoModificar.Nombre;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtApellido.Text = afiliadoModificar.Apellido;
                txtDni.Text = afiliadoModificar.Dni.ToString();
                txtDni.Enabled = false;
                agregarPlanes(afiliadoModificar.PlanUsuario);
                txtMail.Text = afiliadoModificar.Mail;
                cmbEstadoCivil.Text = reconocerEstadoCivil(afiliadoModificar);
                txtTelefono.Text = afiliadoModificar.Telefono.ToString();
                txtDireccion.Text = afiliadoModificar.Direccion;
                dtpFecha.Value = afiliadoModificar.FechaNacimiento;
                dtpFecha.Enabled = false;
                planactual = (Plan)cmbPlan.SelectedItem;
                verActivo();
                
                //ckbEstado.Checked = usuario.Activo;
                //btnContraseña.Visible = true;
                cmbSexo.Text = reconocerSexo(afiliadoModificar);
                cmbPlan.Enabled = true;
                button1.Visible = true;
            }
            else if (opcion == 3 || opcion == 4)
            {
                //SE ESTA AGREGANDO UN FAMILIAR (EL NRO DE AFILIADO ES EL MISMO QUE LE PASO CON EL AFILIADO POR PARAMETRO, SE LE SUMA 1 DIRECTO EN LA BASE)
                if (opcion == 3)/*ESTA AGREGANDO A SU CONYUGE*/
                {
                    cmbEstadoCivil.Text = "Casado/a";
                    cmbEstadoCivil.Enabled = false;
                }
                lblEstado.Visible = false;
                ckbEstado.Visible = false;
                btnHabilitar.Visible = false;
                agregarPlanes(afiliadoModificar.PlanUsuario);
                cmbPlan.Enabled = false;
                button1.Visible = false;
            }
        }
        
        public void verActivo()
        {
                List<Rol> roles = null;
                try
                {

                    if (afiliadoModificar.Username == "administrador32405354")
                    {
                        var parametros = new Dictionary<string, object>() {
                    { "@username", afiliadoModificar.Username.Substring(0,5)}};
                        roles = ConexionesDB.ExecuteReader("UsuarioXRol_GetRolesByUser", parametros).ToRoles();
                    }
                    else
                    {
                        var parametros = new Dictionary<string, object>() {
                    { "@username", afiliadoModificar.Username}};
                        roles = ConexionesDB.ExecuteReader("UsuarioXRol_GetRolesByUser", parametros).ToRoles();
                    
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo obtener el rol del usuario a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (Rol r in roles)
                {
                    if (r.Id == 2)
                    {
                        if (r.Habilitado)
                        {
                            ckbEstado.Checked = true;
                            btnHabilitar.Visible = false;
                            return;
                        }
                    }
                }
                ckbEstado.Checked = false;
                //if (roles.Count > 0)
                //{
                    
                    btnHabilitar.Visible = true;
                //}
                return;
        }
        
        public void agregarPlanes(decimal planUsuario)
        {

            List<Plan> plan = null;
            var parametros = new Dictionary<string, object>() {
                    { "@IdPlan", afiliadoModificar.PlanUsuario}
                };
            try
            {
                plan = ConexionesDB.ExecuteReader("Planes_GetPorId", parametros).ToPlanes();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            List<Plan> otrosPlanes = null;
            try
            {
                otrosPlanes = ConexionesDB.ExecuteReader("Planes_GetAll", null).ToPlanes();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (Plan p in otrosPlanes)
            {
                if (p.Id != plan[0].Id)
                {
                    plan.Add(p);
                }
            }
            cmbPlan.DataSource = plan;
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.SelectedItem = cmbPlan.Items[0];
            
            return;
        }

        public void cargarPlanes()
        {

            List<Plan> otrosPlanes = null;
            try
            {
                otrosPlanes = ConexionesDB.ExecuteReader("Planes_GetAll", null).ToPlanes();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cmbPlan.DataSource = otrosPlanes;
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.SelectedItem = cmbPlan.Items[0];
            return;
        }
        public string reconocerTipoDni(Afiliado afiliadoModifcar)
        {
            if (afiliadoModificar.TipoDocumento == "D")
            {
                return "DNI";
            }
            else if(afiliadoModificar.TipoDocumento == "E")
            {
                return "LE";
            }
            else if(afiliadoModificar.TipoDocumento == "L")
            {
                return "LC";
            }
            else if(afiliadoModificar.TipoDocumento == "C")
            {
                return "CI";
            }
            return "NO ESPECIFICA";
        }
        public string reconocerEstadoCivil(Afiliado afiliadoModificar)
        {
            if (afiliadoModificar.EstadoCivil == "N")
            {
                return "No Especifica";
            }
            else if (afiliadoModificar.EstadoCivil == "C")
            {
                return "Casado/a";
            }
            else if (afiliadoModificar.EstadoCivil == "D")
            {
                return "Divorciado/a";
            }
            else if (afiliadoModificar.EstadoCivil == "S")
            {
                return "Soltero/a";
            }
            else if (afiliadoModificar.EstadoCivil == "V")
            {
                return "Viudo/a";
            }
            return null;
        }

        public string reconocerSexo(Afiliado afiliadoModificar)
        {
            if (afiliadoModificar.Sexo == "N")
            {
                return "No especificado";
            }
            else if (afiliadoModificar.Sexo == "M")
            {
                return "Masculino";
            }
            else if (afiliadoModificar.Sexo == "F")
            {
                return "Femenino";
            }
            return null;
        }

        private void frmAltaAfiliado_Load(object sender, EventArgs e)
        {
            dtpFecha.CustomFormat = "yyyy-M-d HH:mm:ss";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            frmHomeAfiliado acerrar = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmHomeAfiliado")
                {
                    acerrar = (frmHomeAfiliado)frm;
                    
                }
            }
            acerrar.Hide();
        }

        private void frmAltaAfiliado_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (opcionelegida != 3 && opcionelegida != 4)
            {
                frmAfiliado abierto = null;
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "frmAfiliado")
                    {
                        abierto = (frmAfiliado)frm;

                    }
                }
                if (abierto == null)
                {
                    frmHomeAfiliado princ = new frmHomeAfiliado(usuario, rol);
                    Hide();
                    princ.Show();
                }
                else {
                    abierto.Show();
                }
                
            }
        }

        private void btnIngresarFamiliar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosCompletados())
            {
                string tipodni = "";
                if (comboBox1.Text == "DNI")
                    tipodni = "D";
                else if (comboBox1.Text == "CI")
                    tipodni = "C";
                else if (comboBox1.Text == "LC")
                    tipodni = "L";
                else if (comboBox1.Text == "LE")
                    tipodni = "E";
                else
                    tipodni = "N";
                if (opcionelegida == 1)
                {
                    Plan planElegido = (Plan)cmbPlan.SelectedValue;
                    var afiliado = new Dictionary<string, object>()
                    {
                   
                        { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
                        { "@Nombre", txtNombre.Text },
                        {"@TipoDocumento", tipodni},
                        { "@Apellido", txtApellido.Text },
                        { "@Dni", Convert.ToInt32(txtDni.Text)  },
                        { "@Mail",  txtMail.Text  },
                        { "@Telefono", txtTelefono.Text  },
                        { "@Direccion",txtDireccion.Text  },
                        { "@CantHijos",  0 },
                        { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
                        { "@Fecha", dtpFecha.Value},
                        { "@Plan", Convert.ToDecimal(planElegido.Id) },
                        { "@Sexo", cmbSexo.Text.Substring(0,1)},
                    };

                    if (Alta(afiliado))
                    {
                        Close();
                    }

                }
                else if (opcionelegida == 2)
                {
                    Plan planElegido = (Plan)cmbPlan.SelectedValue;
                    var afiliado = new Dictionary<string, object>()
                    {
                        { "@Nombre", txtNombre.Text },
                        { "@Apellido", txtApellido.Text },
                        { "@Dni", Convert.ToInt32(txtDni.Text)  },
                        { "@CantHijos",  0 },
                        { "@Sexo", cmbSexo.Text.Substring(0,1)},
                        { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
                        { "@Mail",  txtMail.Text  },
                        { "@Telefono", txtTelefono.Text  },
                        { "@Direccion",txtDireccion.Text  },
                        { "@Plan", Convert.ToDecimal(planElegido.Id) },
                        { "@Fecha", dtpFecha.Value},
                    };
                    if (Modificar(afiliado))
                    {
                        Close();
                    }
                }
                else if (opcionelegida == 3) //alta conyuge
                {
                    Plan planElegido = (Plan)cmbPlan.SelectedValue;
                    var afiliado = new Dictionary<string, object>()
                    {
                        { "@Afiliado_nro_familiar", afiliadoModificar.NroAfiliado},
                        { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
                        { "@Nombre", txtNombre.Text },
                        { "@Apellido", txtApellido.Text },
                        {"@TipoDocumento", tipodni},
                        { "@Dni", Convert.ToInt32(txtDni.Text)  },
                        { "@Mail",  txtMail.Text  },
                        { "@Telefono", txtTelefono.Text  },
                        { "@Direccion",txtDireccion.Text  },
                        { "@CantHijos",  0 },
                        { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
                        { "@Fecha", dtpFecha.Value},
                        { "@Plan", Convert.ToDecimal(planElegido.Id) },
                        { "@Sexo", cmbSexo.Text.Substring(0,1)},
                    };

                    if (Alta(afiliado))
                    {
                        Close();
                    }                    
                }
                else if (opcionelegida == 4) //alta familiar
                {
                    Plan planElegido = (Plan)cmbPlan.SelectedValue;
                    var afiliado = new Dictionary<string, object>()
                    {
                        { "@Afiliado_nro_familiar", afiliadoModificar.NroAfiliado},
                        { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
                        { "@Nombre", txtNombre.Text },
                        { "@Apellido", txtApellido.Text },
                        {"@TipoDocumento", tipodni},
                        { "@Dni", Convert.ToInt32(txtDni.Text)  },
                        { "@Mail",  txtMail.Text  },
                        { "@Telefono", txtTelefono.Text  },
                        { "@Direccion",txtDireccion.Text  },
                        { "@CantHijos",  0 },
                        { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
                        { "@Fecha", dtpFecha.Value},
                        { "@Plan", Convert.ToDecimal(planElegido.Id) },
                        { "@Sexo", cmbSexo.Text.Substring(0,1)},
                    };

                    if (Alta(afiliado))
                    {
                        Close();
                    }
                }      
            }
        }
        
        private bool Modificar(Dictionary<string, object> afiliado)
        {
            if (((Plan)cmbPlan.SelectedItem).Id != planactual.Id)
            {
                if (txtCambioPlan.Text != "")
                {
                    //HAY QUE CREAR UNA MODIFICACION DEL PLAN
                    var planmodif = new Dictionary<string, object>()
                    {
                        { "@PlanNuevoId", ((Plan)cmbPlan.SelectedItem).Id },
                        { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
                        { "@Motivo", txtCambioPlan.Text},
                    };

                    try
                    {
                        ConexionesDB.ExecuteNonQuery("Agregar_Modif_Plan", planmodif);
                    }
                    catch
                    {
                        MessageBox.Show("Error al modificar el plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar el campo motivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            

            afiliado.Add("@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString());
            if(ckbCambioPlan.Visible){
                afiliado.Add("@cambiarFamilia", ckbCambioPlan.Checked);
            }
            try
            {
                ConexionesDB.ExecuteNonQuery("Afiliado_Modify", afiliado);
            }
            catch 
            {
                MessageBox.Show("Hubo un error inesperado en la modificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MessageBox.Show("Modificado con exito", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool Alta(Dictionary<string, object> afiliado)
        {
            #region OPCION 3(CONYUGE)
            if (opcionelegida == 3)
            {
                Usuario user;
                try
                {
                    user = ConexionesDB.ExecuteReader("Usuario_Exists", new Dictionary<string, object>() { { "@usuarioid", txtNombre.Text + txtApellido.Text + txtDni.Text } }).ToUsuario();

                }
                catch
                {
                    MessageBox.Show("El Afiliado ingresado ya existia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (user == null)
                {
                    Afiliado afil;
                    try
                    {
                        afil = ConexionesDB.ExecuteReader("Afiliado_MismoDni", new Dictionary<string, object>() { { "@dni", txtDni.Text } }).ToAfiliados();

                    }
                    catch
                    {

                        MessageBox.Show("Ya existia un afiliado con ese numero de DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (afil == null)
                    {
                        try
                        {
                            ConexionesDB.ExecuteNonQuery("Afiliado_Agregar_Familiar", afiliado);
                        }
                        catch
                        {
                            MessageBox.Show("No se pudo agregar el afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        MessageBox.Show("Se agrego correctamente el afiliado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult resultado2 = MessageBox.Show("Desea agregar a algun otro familiar a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado2 == DialogResult.Yes)//quiere decir que quiere registrar a su familiar
                        {
                            //ACA TENGO QUE IR A UN NUEVO FORM DE ALTA PARA EL FAMILIAR
                            Afiliado afilAgregado;
                            try
                            {
                                var dict = new Dictionary<string, object>() { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } };
                                afilAgregado = ConexionesDB.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", dict).ToAfiliados();
                            }
                            catch
                            {
                                MessageBox.Show("No se ha podido agregar un familiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            opcionelegida = 4;
                            frmAfiliado conyuge = new frmAfiliado(usuario, rol, afilAgregado, 4);
                            conyuge.Show();
                            return true;
                        }
                        else
                        {
                            opcionelegida = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un afiliado con ese mismo DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Ese Afiliado ya esta registrado en la clinica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            #endregion
            #region OPCION 1(ALTA AFILIADO)
            else if (opcionelegida == 1)
            {
                Usuario user;
                try
                {
                    user = ConexionesDB.ExecuteReader("Usuario_Exists", new Dictionary<string, object>() { { "@usuarioid", txtNombre.Text + txtApellido.Text + txtDni.Text } }).ToUsuario();

                }
                catch
                {
                    MessageBox.Show("El Afiliado ingresado ya existia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (user == null)
                {
                    Afiliado afil;
                    try
                    {
                        afil = ConexionesDB.ExecuteReader("Afiliado_MismoDni", new Dictionary<string, object>() { { "@dni", txtDni.Text } }).ToAfiliados();

                    }
                    catch
                    {

                        MessageBox.Show("Ya existia un afiliado con ese numero de DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (afil == null)
                    {
                        try
                        {
                            ConexionesDB.ExecuteNonQuery("Afiliado_Add", afiliado);
                            ConexionesDB.ExecuteNonQuery("Hijos_En_Cero", new Dictionary<string, object> { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } });
                        }
                        catch
                        {
                            MessageBox.Show("No se pudo agregar el afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        MessageBox.Show("Se agrego correctamente el afiliado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (cmbEstadoCivil.Text.Substring(0, 1) == "C")//esta casado, ofrezco si quiere registrar a su conyuge
                        {
                            DialogResult resultado = MessageBox.Show("Desea agregar a su conyuge a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)//quiere decir que quiere registrar a su conyuge
                            {
                                //VER PORQUE AL AFILIADO LE QUEDA 1 HIJO MAS QUE LOS QUE TIENE
                                //ACA TENGO QUE IR A UN NUEVO FORMULARIO DE ALTA PARA EL CONYUGE
                                //LEO EL NRO AFILIADO DEL QUE ACABO DE AGREGAR PARA PASRLO
                                Afiliado afilAgregado;
                                try
                                {
                                    var dict = new Dictionary<string, object>() { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } };
                                    afilAgregado = ConexionesDB.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", dict).ToAfiliados();
                                }
                                catch
                                {
                                    MessageBox.Show("No se ha podido agregar un familiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                opcionelegida = 3;
                                frmAfiliado conyuge = new frmAfiliado(usuario, rol, afilAgregado, 3);
                                conyuge.Show();
                                return true;
                            }
                            else // no quiere registrar a su conyuge
                            {
                                DialogResult resultado2 = MessageBox.Show("Desea agregar a algun otro familiar a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado2 == DialogResult.Yes)//quiere decir que quiere registrar a su conyuge
                                {
                                    //ACA TENGO QUE IR A UN NUEVO FORM DE ALTA PARA EL FAMILIAR
                                    //OPCION 4 es Agregar otro familiar
                                    //VER PORQUE AL AFILIADO LE QUEDA 1 HIJO MAS QUE LOS QUE TIENE
                                    //ACA TENGO QUE IR A UN NUEVO FORMULARIO DE ALTA PARA EL CONYUGE
                                    //LEO EL NRO AFILIADO DEL QUE ACABO DE AGREGAR PARA PASRLO
                                    Afiliado afilAgregado;
                                    try
                                    {
                                        var dict = new Dictionary<string, object>() { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } };
                                        afilAgregado = ConexionesDB.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", dict).ToAfiliados();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("No se ha podido agregar un familiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                    opcionelegida = 4;
                                    frmAfiliado conyuge = new frmAfiliado(usuario, rol, afilAgregado, 4);
                                    conyuge.Show();
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            DialogResult resultado3 = MessageBox.Show("Desea agregar a algun otro familiar a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado3 == DialogResult.Yes)//quiere decir que quiere registrar a su conyuge
                            {
                                //ACA TENGO QUE IR A UN NUEVO FORM DE ALTA PARA EL FAMILIAR
                                //OPCION 4 es Agregar otro familiar
                                //VER PORQUE AL AFILIADO LE QUEDA 1 HIJO MAS QUE LOS QUE TIENE
                                //ACA TENGO QUE IR A UN NUEVO FORMULARIO DE ALTA PARA EL CONYUGE
                                //LEO EL NRO AFILIADO DEL QUE ACABO DE AGREGAR PARA PASRLO
                                Afiliado afilAgregado;
                                try
                                {
                                    var dict = new Dictionary<string, object>() { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } };
                                    afilAgregado = ConexionesDB.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", dict).ToAfiliados();
                                }
                                catch
                                {
                                    MessageBox.Show("No se ha podido agregar un familiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                opcionelegida = 4;
                                frmAfiliado conyuge = new frmAfiliado(usuario, rol, afilAgregado, 4);
                                conyuge.Show();
                                return true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existia un afiliado con ese DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Ese Afiliado ya esta registrado en la clinica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            #endregion
            #region OPCION 4 (ALTA FAMILIAR)
            if (opcionelegida == 4)
            {
                Usuario user;
                try
                {
                    user = ConexionesDB.ExecuteReader("Usuario_Exists", new Dictionary<string, object>() { { "@usuarioid", txtNombre.Text + txtApellido.Text + txtDni.Text } }).ToUsuario();

                }
                catch
                {
                    MessageBox.Show("El Afiliado ingresado ya existia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (user == null)
                {
                    Afiliado afil;
                    try
                    {
                        afil = ConexionesDB.ExecuteReader("Afiliado_MismoDni", new Dictionary<string, object>() { { "@dni", txtDni.Text } }).ToAfiliados();

                    }
                    catch
                    {

                        MessageBox.Show("Ya existia un afiliado con ese numero de DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (afil == null)
                    {
                        try
                        {
                            ConexionesDB.ExecuteNonQuery("Afiliado_Agregar_Familiar", afiliado);
                        }
                        catch
                        {
                            MessageBox.Show("No se pudo agregar el afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        MessageBox.Show("Se agrego correctamente el afiliado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult resultado2 = MessageBox.Show("Desea agregar a algun otro familiar a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado2 == DialogResult.Yes)//quiere decir que quiere registrar a su conyuge
                        {
                            //ACA TENGO QUE IR A UN NUEVO FORM DE ALTA PARA EL FAMILIAR
                            Afiliado afilAgregado;
                            try
                            {
                                var dict = new Dictionary<string, object>() { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } };
                                afilAgregado = ConexionesDB.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", dict).ToAfiliados();
                            }
                            catch
                            {
                                MessageBox.Show("No se ha podido agregar un familiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            opcionelegida = 4;
                            frmAfiliado conyuge = new frmAfiliado(usuario, rol, afilAgregado, 4);
                            conyuge.Show();
                            return true;
                        }
                        else
                        {
                            opcionelegida = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existia un afiliado con ese mismo DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Ese Afiliado ya esta registrado en la clinica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            
            #endregion

            return false;
        }

        private bool DatosCompletados()
        {
            int result;
            StringBuilder sb = new StringBuilder();
            if (txtNombre.Text == string.Empty)
            {
                sb.AppendLine("Complete nombre.");
            }
            if (txtNombre.Text.Length > 50)
            {
                sb.AppendLine("Su nombre no puede tener mas de 50 caracteres");
            }
            if (txtApellido.Text == string.Empty)
            {
                sb.AppendLine("Complete apellido.");
            }
            if (txtNombre.Text.Length > 50)
            {
                sb.AppendLine("Su apellido no puede tener mas de 50 caracteres");
            }
            if (txtDni.Text == string.Empty)
            {
                sb.AppendLine("Complete dni.");
            }
            if (txtDni.Text.ToString().Length > 8)
            {
                sb.AppendLine("El dni no puede tener mas de 8 numeros.");
            }
            if (txtMail.Text == string.Empty)
            {
                sb.AppendLine("Complete mail.");
            }
            if (txtTelefono.Text == string.Empty)
            {
                sb.AppendLine("Complete telefono.");
            }
            if (txtNombre.Text.Length > 20)
            {
                sb.AppendLine("Su nombre no puede tener mas de 20 numeros");
            }
            if (txtDireccion.Text == string.Empty)
            {
                sb.AppendLine("Complete direccion.");
            }
            if (txtNombre.Text.Length > 50)
            {
                sb.AppendLine("Su nombre no puede tener mas de 50 caracteres");
            }
            if (cmbSexo.Text == string.Empty)
            {
                sb.AppendLine("Complete el sexo");
            }
            if (cmbEstadoCivil.Text == string.Empty)
            {
                sb.AppendLine("Complete estado civil");
            }
            if (cmbPlan.Text == string.Empty)
            {
                sb.AppendLine("Complete el plan");
            }
            if (dtpFecha.Text == string.Empty)
            {
                sb.AppendLine("Complete fecha.");
            }
            if (!int.TryParse(txtDni.Text, out result))
            {
                sb.AppendLine("El campo DNI debe ser numérico.");
            }
            if (!int.TryParse(txtTelefono.Text, out result))
            {
                sb.AppendLine("El campo Telefono debe ser numerico");
            }
            if (comboBox1.Text == string.Empty)
            {
                sb.AppendLine("Debe seleccionar un tipo de dni");
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                MessageBox.Show(sb.ToString(), "Complete los siguientes campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 0)
            {
                planactual = (Plan)cmbPlan.SelectedItem;
                i++;
            }
            if (opcionelegida == 2 && planactual.Id != ((Plan)cmbPlan.SelectedItem).Id)
            {
                txtCambioPlan.Visible = true;
                label11.Visible = true;
                lblCambioPlan.Visible = true;
                ckbCambioPlan.Visible = true;
            }
            if (opcionelegida == 2 && planactual.Id == ((Plan)cmbPlan.SelectedItem).Id)
            {
                txtCambioPlan.Visible = false;
                label11.Visible = false;
                lblCambioPlan.Visible = false;
                ckbCambioPlan.Visible = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if(opcionelegida == 1){
                txtApellido.Text = "";
                txtCambioPlan.Text = "";
                txtDireccion.Text = "";
                txtDni.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                cmbEstadoCivil.SelectedItem = cmbEstadoCivil.Items[0];
                cmbPlan.SelectedItem = cmbPlan.Items[0];
                cmbSexo.SelectedItem = cmbSexo.Items[0];
                dtpFecha.Value = ConfigTime.getFechaSinHora();
            }
            else if (opcionelegida == 3 || opcionelegida == 4)
            {
                txtApellido.Text = "";
                txtCambioPlan.Text = "";
                txtDireccion.Text = "";
                txtDni.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                cmbEstadoCivil.SelectedItem = cmbEstadoCivil.Items[0];
                cmbSexo.SelectedItem = cmbSexo.Items[0];
                dtpFecha.Value = ConfigTime.getFechaSinHora();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            //TENGO QUE VOLVER A HABILITAR EL ROL DEL USUARIO
            List<Rol> roles = null; 
            string usu;
            try
            {
               
                if (afiliadoModificar.Username == "administrador32405354")
                {
                    var parametros = new Dictionary<string, object>() {
                    { "@username", afiliadoModificar.Username.Substring(0,5)}};
                    roles = ConexionesDB.ExecuteReader("UsuarioXRol_GetRolesInhabxUser", parametros).ToRoles();
                    usu = afiliadoModificar.Username.Substring(0, 5);
                }
                else
                {
                    var parametros = new Dictionary<string, object>() {
                    { "@username", afiliadoModificar.Username}};
                    roles = ConexionesDB.ExecuteReader("UsuarioXRol_GetRolesInhabxUser", parametros).ToRoles();
                    usu = afiliadoModificar.Username;
                }
            }
            catch
            {
                MessageBox.Show("No se pudo obtener el rol del usuario a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (roles.Count > 0 && roles[0].Id == 2 && roles[0].Habilitado)
            {
                Rol rolAsignado = null;
                foreach (Rol r in roles)
                {
                    if (r.Id == 2)
                    {
                        rolAsignado = r;
                    }
                }
                try
                {
                    ConexionesDB.ExecuteNonQuery("RolXUsuario_Activate", new Dictionary<string, object>() { { "@rol", rolAsignado.Id }, { "@usuario", usu } });

                }
                catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                MessageBox.Show("Rol activado nuevamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ckbEstado.Checked = true;
                btnHabilitar.Visible = false;
            }
            else
            {
                MessageBox.Show("El rol estaba deshabilitado, habilitelo e intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAfiliado familiar = new frmAfiliado(usuario, rol, afiliadoModificar, 4);
            familiar.Show();
        }

 
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtApellido.Text.Length == 0)
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else if (txtApellido.Text.Length > 0)
                e.KeyChar = e.KeyChar.ToString().ToLower().ToCharArray()[0];
        }

    }
}

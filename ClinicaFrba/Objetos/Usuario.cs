using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Objetos
{
    public class Usuario
    {
        public Int64 id_user { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public int Intentos { get; set; }
        public bool Activo { get; set; }
        //ROl
        public int Id_rol  { get; set; }
        public string DescripcionRol { get; set; }
        public bool Habilitado { get; set; }
        //funcion
        public int Id_funcionalidad { get; set; }
        public string DescripcionFuncionalidad { get; set; }
    }
}

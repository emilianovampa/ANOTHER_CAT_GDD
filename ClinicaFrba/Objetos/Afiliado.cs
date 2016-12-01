using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Objetos
{
    public class Afiliado
    {          
        public decimal NroAfiliado { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public decimal Telefono { get; set; }
        public string Direccion { get; set; }
        public string Apellido { get; set; }
        public decimal Dni { get; set; }
        public string EstadoCivil { get; set; }
        public decimal PlanUsuario { get; set; }
        public string Sexo { get; set; }
        public decimal CantidadHijos { get; set; }
        public decimal CantBonosUsados { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace WebBetDW.Models.Entities
{
    public class Cuenta
    {
        public Cuenta()
        {
            Sesions = new HashSet<Sesion>();
        }

        public Guid Idcuenta { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public Guid Rol { get; set; }

        public virtual Rol RolNavigation { get; set; }
        public virtual ICollection<Sesion> Sesions { get; set; }
    }
}

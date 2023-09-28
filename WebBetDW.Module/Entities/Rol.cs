using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Entities
{
    public class Rol
    {
        public Rol()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public Guid Idrol { get; set; }
        public string Nombre { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}

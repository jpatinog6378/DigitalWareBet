using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Entities
{
    public class Sesion
    {
        public Sesion()
        {
            Apuesta = new HashSet<Apuesta>();
        }

        public Guid Idsesion { get; set; }
        public Guid Partido { get; set; }
        public Guid Cuenta { get; set; }
        public string NombreGrupo { get; set; }
        public string Code { get; set; }

        public virtual Cuenta CuentaNavigation { get; set; }
        public virtual Partido PartidoNavigation { get; set; }
        public virtual ICollection<Apuesta> Apuesta { get; set; }
    }
}

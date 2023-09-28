using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace WebBetDW.Models.Entities
{
    public class Partido
    {
        public Partido()
        {
            Sesions = new HashSet<Sesion>();
        }

        public Guid Idpartido { get; set; }
        public Guid Torneo { get; set; }
        public Guid EquipoLocal { get; set; }
        public Guid EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public string MarcadorLocal { get; set; }
        public bool Activo { get; set; }
        public string MarcadorVisitante { get; set; }


        public virtual Equipo EquipoLocalNavigation { get; set; }
        public virtual Equipo EquipoVisitanteNavigation { get; set; }
        public virtual ICollection<Sesion> Sesions { get; set; }
    }
}

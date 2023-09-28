using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Entities
{
    public class Campeonato
    {
        public Guid Idcampeonato { get; set; }
        public Guid Equipo { get; set; }
        public Guid Torneo { get; set; }

        public virtual Equipo EquipoNavigation { get; set; }
        public virtual Torneo TorneoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Entities
{
    public class Torneo
    {
        public Torneo()
        {
            Campeonatos = new HashSet<Campeonato>();
        }

        public Guid Idtorneo { get; set; }
        public string Nombre { get; set; }
        public bool Internacional { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Campeonato> Campeonatos { get; set; }
    }
}

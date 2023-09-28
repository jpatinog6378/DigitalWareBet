using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Entities
{
    public class Equipo
    {
        public Equipo()
        {
            Campeonatos = new HashSet<Campeonato>();
            PartidoEquipoLocalNavigations = new HashSet<Partido>();
            PartidoEquipoVisitanteNavigations = new HashSet<Partido>();
        }

        public Guid Idequipo { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<Campeonato> Campeonatos { get; set; }
        public virtual ICollection<Partido> PartidoEquipoLocalNavigations { get; set; }
        public virtual ICollection<Partido> PartidoEquipoVisitanteNavigations { get; set; }
    }
}

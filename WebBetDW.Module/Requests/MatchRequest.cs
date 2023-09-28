using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Requests
{
    public class MatchRequest
    {

        public string Idpartido { get; set; }
        public string Torneo { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public string Fecha { get; set; }
        public string MarcadorLocal { get; set; }
        public string MarcadorVisitante { get; set; }
        public bool Activo { get; set; }
    }
}

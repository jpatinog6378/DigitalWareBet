using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Requests
{
    public class SessionRequest
    {
        public string Idsesion { get; set; }
        public string Partido { get; set; }
        public string Cuenta { get; set; }
        public string NombreGrupo { get; set; }
        public string Code { get; set; }
    }
}

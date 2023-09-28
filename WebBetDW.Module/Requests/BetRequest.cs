using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Requests
{
    public class BetRequest
    {
        public string Idapuesta { get; set; }
        public string Sesion { get; set; }
        public string Marcador { get; set; }
    }
}

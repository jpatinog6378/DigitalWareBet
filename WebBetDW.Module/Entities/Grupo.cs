using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.Entities
{
    public class Grupo
    {
        public Guid Idgrupo { get; set; }

        public Guid IdSesion { get; set; }

        public Guid IdCuenta { get; set; }
    }
}

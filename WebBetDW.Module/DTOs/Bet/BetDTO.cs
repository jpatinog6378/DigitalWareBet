using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.DTOs.Bet
{
    public class BetDTO
    {
        /// <summary>
        /// Id de la apuesta realizada por el usuario
        /// </summary>
        public Guid Idapuesta { get; set; }
        /// <summary>
        /// Id de la sesion en la que hace parte el usuario
        /// </summary>
        public Guid IdSesion { get; set; }
        /// <summary>
        /// Aca se adjunta el marcador que el usuario a deseado
        /// </summary>
        public string Marcador { get; set; }
    }
}

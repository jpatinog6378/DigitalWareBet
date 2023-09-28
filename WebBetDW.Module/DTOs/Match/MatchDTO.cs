using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.DTOs.Match
{
    public class MatchDTO
    {
        /// <summary>
        /// Id del partido creado o del cual se va actualizar
        /// </summary>
        public Guid Idpartido { get; set; }
        /// <summary>
        /// Id del torneo que se va a jugar se a nivel nacional o internacional
        /// </summary>
        public Guid IdTorneo { get; set; }
        /// <summary>
        /// Id del equipo local que va a jugar
        /// </summary>
        public Guid IdEquipoLocal { get; set; }
        /// <summary>
        /// Id del equipo visitante que va a jugar 
        /// </summary>
        public Guid IdEquipoVisitante { get; set; }
        /// <summary>
        /// Fecha del partido a jugar 
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Marcador del partido, sea parcial o sea final
        /// </summary>
        public string MarcadorLocal { get; set; }
        /// <summary>
        /// Validador que nos indica si el partido sigue activo o se finalizo
        /// </summary>
        public bool Activo { get; set; }

        public string MarcadorVisitante { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.DTOs.SessionDTO
{
    public class SessionDTO
    {
        /// <summary>
        /// Id de la sesion en la que las personas pueden hacer parte
        /// </summary>
        public Guid Idsesion { get; set; }
        /// <summary>
        /// Id del partido que se va a celebrar en este grupo
        /// </summary>
        public Guid IdPartido { get; set; }
        /// <summary>
        /// Id de la cuenta que hacen parte del grupo
        /// </summary>
        public Guid IdCuenta { get; set; }
        /// <summary>
        /// Nombre que se le va a dar a este grupo
        /// </summary>
        public string NombreGrupo { get; set; }
        /// <summary>
        /// Codigo que se requiere para ingresar a este grupo
        /// </summary>
        public string Code { get; set; }
    }
}

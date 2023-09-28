using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBetDW.Models.DTOs.User
{
    public class AccountDTO
    {
        /// <summary>
        /// Id de la cuenta la cual nos permite identificar la cuenta de cada uno de ellos
        /// </summary>
        public Guid IdCuenta { get; set; }
        /// <summary>
        /// Correo con el que se registro el usuario a la plataforma
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Contraseña de la cuenta de cada usuario
        /// </summary>
        public string Contraseña { get; set; }
        /// <summary>
        /// Nombre del usuario registrado 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Rol que tiene cada usuario registrado en la plataforma  
        /// </summary>
        public Guid Rol { get; set; }
    }
}

using System;

namespace WebBetDW.Models.Requests
{
    public class AccountRequest
    {
        public string Idcuenta { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }
}

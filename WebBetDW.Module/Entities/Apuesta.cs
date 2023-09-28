using System;

namespace WebBetDW.Models.Entities
{
    public class Apuesta
    {
        public Guid Idapuesta { get; set; }
        public Guid Sesion { get; set; }
        public string Marcador { get; set; }

        public virtual Sesion SesionNavigation { get; set; }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetDW.Models.DTOs.SessionDTO;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.Session.Interfaces
{
    public interface ISessionCore
    {
        /// <summary>
        /// Servicio que nos trae la información inicial al cargar el aplicativo
        /// </summary>
        /// <returns></returns>
        Task<bool> AddOrUpdateNewSessionGroup(SessionRequest sessionRequest);
        Task<List<SessionDTO>> GetAll();
        Task<SessionDTO> GetById(string idSession);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetDW.Models.DTOs.User;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.User.Interfaces
{
    public interface IAccountCore
    {
        /// <summary>
        /// Servicio que nos trae la información inicial al cargar el aplicativo
        /// </summary>
        /// <returns></returns>

        Task<List<AccountDTO>> GetAll();

        /// <summary>
        /// Servicio que consulta al servcio si el login va ser exitoso
        /// </summary>
        /// <returns></returns>
        Task<AccountDTO> GetByPasswordMail(LoginRequest loginRequest);

        /// <summary>
        /// Servicio que consulta al servcio si el login va ser exitoso
        /// </summary>
        /// <returns></returns>
        Task<bool> AddOrUpdate(AccountRequest accountRequest);


    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetDW.Models.DTOs.Match;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.Match.Interfaces
{
    public interface IMatchCore
    {
        /// <summary>
        /// Servicio que crea y actualiza un partido
        /// </summary>
        /// <returns></returns>
        Task<bool> AddOrUpdate(MatchRequest matchRequest);
        Task<MatchDTO> GetByID(string idMatch);
        Task<List<MatchDTO>> GetAll();
    }
}

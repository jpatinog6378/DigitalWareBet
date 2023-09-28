using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetDW.Models.DTOs.Bet;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.Bet.Interfaces
{
    public interface IBetCore
    {
        /// <summary>
        /// Servicio que crea y actualiza una apuesta en linea
        /// </summary>
        /// <returns></returns>
        Task<bool> AddOrUpdateBet(BetRequest betRequest);
        Task<BetDTO> GetByID(string idApuesta);
        Task<List<BetDTO>> GetAll();
    }
}

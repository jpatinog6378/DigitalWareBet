using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetDW.Models.Entities;

namespace WebBetDW.Core.Core.Team.Interfaces
{
    public interface ITeamCore
    {
        /// <summary>
        /// Servicio que trae la información de los equipos 
        /// </summary>
        /// <returns></returns>

        Task<List<Equipo>> GetAllTeams();
    }
}

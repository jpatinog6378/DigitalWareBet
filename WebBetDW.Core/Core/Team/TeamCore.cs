using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetDW.Context.Context;
using WebBetDW.Core.Core.Team.Interfaces;
using WebBetDW.Models.Entities;

namespace WebBetDW.Core.Core.Team
{
    public class TeamCore : ITeamCore
    {
        //Inicimos con el patron de diseño que en este caso es por inyección de dependencias 
        #region Fields

        private readonly WebBetDWContext _webBetDWContext;

        #endregion

        #region Builder

        public TeamCore(WebBetDWContext webBetDWContext)
        {
            _webBetDWContext = webBetDWContext;
        }

        #endregion

        #region Methods

        public async Task<List<Equipo>> GetAllTeams()
        {
            //List<UserDTO> cuentaDTO = new List<UserDTO>();
            var data = _webBetDWContext.Equipos.ToList();
            return await Task.FromResult(data);
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBetDW.Core.Core.Team.Interfaces;

namespace WebBetDW.Api.Controllers.Teams
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        #region Fields

        private readonly ITeamCore _teamCore;

        #endregion

        #region Builders

        public TeamController(ITeamCore teamCore)
        {
            _teamCore = teamCore;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            return await Task.FromResult(Ok(_teamCore.GetAllTeams()));
        }

        #endregion
    }
}

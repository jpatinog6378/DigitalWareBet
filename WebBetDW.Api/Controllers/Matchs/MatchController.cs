using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBetDW.Core.Core.Match.Interfaces;
using WebBetDW.Models.Requests;

namespace WebBetDW.Api.Controllers.Matchs
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        #region Fields

        private readonly IMatchCore _matchCore;

        #endregion

        #region Builder

        public MatchController(IMatchCore matchCore)
        {
            _matchCore = matchCore; 
        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(MatchRequest matchRequest)
        {
            var response = await _matchCore.AddOrUpdate(matchRequest);
            return response != false ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _matchCore.GetAll();
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetById(string idMatch)
        {
            var response = await _matchCore.GetByID(idMatch);
            return response != null ? Ok(response) : BadRequest(response);
        }
        #endregion
    }
}

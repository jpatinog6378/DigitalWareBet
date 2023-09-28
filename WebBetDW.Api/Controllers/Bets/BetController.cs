using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBetDW.Core.Core.Bet.Interfaces;
using WebBetDW.Core.Core.Match;
using WebBetDW.Core.Core.Match.Interfaces;
using WebBetDW.Models.Requests;

namespace WebBetDW.Api.Controllers.Bets
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        #region Fields

        private readonly IBetCore _betCore;

        #endregion

        #region Builder

        public BetController(IBetCore betCore)
        {
            _betCore = betCore; 
        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateBet(BetRequest betRequest)
        {
            var response = await _betCore.AddOrUpdateBet(betRequest);
            return response != false ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _betCore.GetAll();
            return response != null? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetById(string idApuesta)
        {
            var response = await _betCore.GetByID(idApuesta);
            return response != null ? Ok(response) : BadRequest(response);
        }


        #endregion
    }
}

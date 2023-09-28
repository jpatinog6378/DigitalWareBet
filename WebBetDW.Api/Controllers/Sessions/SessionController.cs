using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBetDW.Core.Core.Session.Interfaces;
using WebBetDW.Core.Core.User.Interfaces;
using WebBetDW.Models.Requests;

namespace WebBetDW.Api.Controllers.Sessions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        #region Fields

        private readonly ISessionCore _sessionCore;

        #endregion

        #region Builder

        public SessionController(ISessionCore sessionCore)
        {
            _sessionCore = sessionCore; 
            
        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateNewSessionGroup(SessionRequest sessionRequest)
        {
            var response = await _sessionCore.AddOrUpdateNewSessionGroup(sessionRequest);
            return response != false ? Ok(response) : BadRequest(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sessionCore.GetAll();
            return response != null ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetById(string idSession)
        {
            var response = await _sessionCore.GetById(idSession);
            return response != null ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}

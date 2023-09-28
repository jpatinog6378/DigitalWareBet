using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBetDW.Core.Core.User.Interfaces;
using WebBetDW.Models.Requests;

namespace WebBetDW.Api.Controllers.Users
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields

        private readonly IAccountCore _userCore;

        #endregion

        #region Builder

        public AccountController(IAccountCore userCore)
        {
            _userCore = userCore;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userCore.GetAll();
            return response != null ? Ok(response) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetByPasswordMail(LoginRequest loginRequest)
        {
            var response = await _userCore.GetByPasswordMail(loginRequest);
            return response != null ? Ok(response) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(AccountRequest accountRequest)
        {
            var response = await _userCore.AddOrUpdate(accountRequest);
            return response != false ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}

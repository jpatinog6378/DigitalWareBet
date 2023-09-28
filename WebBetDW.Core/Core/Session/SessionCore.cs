using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBetDW.Context.Context;
using WebBetDW.Core.Core.Session.Interfaces;
using WebBetDW.Core.Helpers.Interfaces;
using WebBetDW.Models.DTOs.Match;
using WebBetDW.Models.DTOs.SessionDTO;
using WebBetDW.Models.Entities;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.Session
{
    public class SessionCore : ISessionCore
    {
        #region Fields

        private readonly WebBetDWContext _webBetDWContext;
        private readonly IMapper _mapper;
        private readonly IValidateGuidHelper _validateGuidHelper;

        #endregion

        #region Builder

        public SessionCore(WebBetDWContext webBetDWContext , IMapper mapper, IValidateGuidHelper validateGuidHelper)
        {
            _webBetDWContext = webBetDWContext;
            _mapper = mapper;
            _validateGuidHelper = validateGuidHelper;
        }

        #endregion

        #region Methods

        public async Task<bool> AddOrUpdateNewSessionGroup(SessionRequest sessionModel)
        {
            Sesion dataMapper = new Sesion();
            if (_validateGuidHelper.ValidateGuid(sessionModel.Idsesion).Result == null)
            {
                if (_validateGuidHelper.ValidateGuid(sessionModel.Partido).Result != null)
                {
                    if (_validateGuidHelper.ValidateGuid(sessionModel.Cuenta).Result != null)
                    {
                        dataMapper = _mapper.Map<Sesion>(sessionModel);
                        _webBetDWContext.Sesion.Add(dataMapper);
                    }
                }
            }
            if (_validateGuidHelper.ValidateGuid(sessionModel.Idsesion).Result != null  )
            {
                if (_validateGuidHelper.ValidateGuid(sessionModel.Partido).Result != null   )
                {
                    if (_validateGuidHelper.ValidateGuid(sessionModel.Cuenta).Result != null    )
                    {
                                dataMapper = _mapper.Map<Sesion>(sessionModel);
                                _webBetDWContext.Sesion.Update(dataMapper);
                    }
                }
            }
            var res = _webBetDWContext.SaveChanges();
            return await Task.FromResult(res != 0 ? true : false);
        }

        public async Task<List<SessionDTO>> GetAll()
        {
            var data = _webBetDWContext.Sesion.ToList();
            if (data.Count() <= 0)
            {
                return null;
            }
            var dataMapper = _mapper.Map<List<Sesion>, List<SessionDTO>>(data);
            return await Task.FromResult(dataMapper.Count() > 0 ? dataMapper : null);
        }

        public async Task<SessionDTO> GetById(string idSession)
        {
            var data = _webBetDWContext.Sesion.FirstOrDefault(bet => bet.Idsesion == Guid.Parse(idSession));
            if (data == null)
            {
                return null;
            }
            var dataMapper = _mapper.Map<Sesion, SessionDTO>(data);
            return await Task.FromResult(dataMapper != null ? dataMapper : null);
        }

        #endregion
    }
}

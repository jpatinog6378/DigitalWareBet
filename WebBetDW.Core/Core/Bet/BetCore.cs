using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBetDW.Context.Context;
using WebBetDW.Core.Core.Bet.Interfaces;
using WebBetDW.Models.DTOs.Bet;
using WebBetDW.Models.DTOs.User;
using WebBetDW.Models.Entities;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.Bet
{
    public class BetCore : IBetCore
    {
        #region Fields

        private readonly WebBetDWContext _webBetDWContext;
        private readonly IMapper _mapper;

        #endregion

        #region Builder

        public BetCore(WebBetDWContext webBetDWContext, IMapper mapper)
        {
            _webBetDWContext = webBetDWContext;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<List<BetDTO>> GetAll()
        {
            var data = _webBetDWContext.Apuesta.ToList();
            if (data.Count() <= 0)
            {
                return null;
            }
            var dataMapper = _mapper.Map<List<Apuesta>, List<BetDTO>>(data);
            return await Task.FromResult(dataMapper.Count() > 0 ? dataMapper : null);
        }

        public async Task<BetDTO> GetByID(string idApuesta)
        {
            var data = _webBetDWContext.Apuesta.FirstOrDefault(bet => bet.Idapuesta == Guid.Parse(idApuesta));
            if (data == null)
            {
                return null;
            }
            var dataMapper = _mapper.Map<Apuesta, BetDTO>(data);
            return await Task.FromResult(dataMapper != null ? dataMapper : null);
        }

        public async Task<bool> AddOrUpdateBet(BetRequest betModel)
        {
            Apuesta dataMapper = new Apuesta();
            if (string.IsNullOrEmpty(betModel.Idapuesta))
            {
                if (!string.IsNullOrEmpty(betModel.Sesion))
                {
                    Guid output;
                    if (Guid.TryParse(betModel.Sesion, out output))
                    {
                        dataMapper = _mapper.Map<Apuesta>(betModel);
                        _webBetDWContext.Apuesta.Add(dataMapper);
                    }
                }
            }
            if (!string.IsNullOrEmpty(betModel.Idapuesta))
            {
                if (!string.IsNullOrEmpty(betModel.Sesion))
                {
                    Guid output;
                    if (Guid.TryParse(betModel.Sesion, out output))
                    {
                        dataMapper = _mapper.Map<Apuesta>(betModel);
                        _webBetDWContext.Apuesta.Update(dataMapper);
                    }
                }
            }
            var res = _webBetDWContext.SaveChanges();
            return await Task.FromResult(res != 0 ? true : false);
        }
        #endregion
    }
}

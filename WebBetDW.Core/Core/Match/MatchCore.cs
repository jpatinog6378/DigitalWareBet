using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBetDW.Context.Context;
using WebBetDW.Core.Core.Match.Interfaces;
using WebBetDW.Models.DTOs.Bet;
using WebBetDW.Models.DTOs.Match;
using WebBetDW.Models.Entities;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.Match
{
    public class MatchCore : IMatchCore
    {
        #region Fields

        private readonly WebBetDWContext _webBetDWContext;
        private readonly IMapper _mapper;

        #endregion

        #region Builder

        public MatchCore(WebBetDWContext webBetDWContext, IMapper mapper)
        {
            _webBetDWContext = webBetDWContext;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<List<MatchDTO>> GetAll()
        {
            var data = _webBetDWContext.Partidos.Where(x => x.Activo).ToList();
            if (data.Count() <= 0)
            {
                return null;
            }
            var dataMapper = _mapper.Map<List<Partido>, List<MatchDTO>>(data);
            return await Task.FromResult(dataMapper.Count() > 0 ? dataMapper : null);
        }

        public async Task<MatchDTO> GetByID(string idMatch)
        {
            var data = _webBetDWContext.Partidos.FirstOrDefault(bet => bet.Idpartido == Guid.Parse(idMatch) && bet.Activo);
            if (data == null)
            {
                return null;
            }
            var dataMapper = _mapper.Map<Partido, MatchDTO>(data);
            return await Task.FromResult(dataMapper != null ? dataMapper : null);
        }

        public async Task<bool> AddOrUpdate(MatchRequest matchModel)
        {
            Partido dataMapper = new Partido();
            if (string.IsNullOrEmpty(matchModel.Idpartido))
            {
                if (!string.IsNullOrEmpty(matchModel.EquipoLocal))
                {
                    if (!string.IsNullOrEmpty(matchModel.EquipoVisitante))
                    {
                        if (!string.IsNullOrEmpty(matchModel.Torneo))
                        {
                            Guid output;
                            if (Guid.TryParse(matchModel.EquipoLocal, out output))
                            {
                                if (Guid.TryParse(matchModel.EquipoVisitante, out output))
                                {
                                    if (Guid.TryParse(matchModel.Torneo, out output))
                                    {
                                        dataMapper = _mapper.Map<Partido>(matchModel);
                                        _webBetDWContext.Partidos.Add(dataMapper);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(matchModel.Idpartido))
            {
                if (!string.IsNullOrEmpty(matchModel.EquipoLocal))
                {
                    if (!string.IsNullOrEmpty(matchModel.EquipoVisitante))
                    {
                        if (!string.IsNullOrEmpty(matchModel.Torneo))
                        {
                            Guid output;
                            if (Guid.TryParse(matchModel.EquipoLocal, out output))
                            {
                                if (Guid.TryParse(matchModel.EquipoVisitante, out output))
                                {
                                    if (Guid.TryParse(matchModel.Torneo, out output))
                                    {
                                        dataMapper = _mapper.Map<Partido>(matchModel);
                                        _webBetDWContext.Partidos.Update(dataMapper);
                                    }
                                }
                            }

                        }


                    }


                }

            }
            var res = _webBetDWContext.SaveChanges();
            return await Task.FromResult(res != 0 ? true : false);
        }
        #endregion
    }
}

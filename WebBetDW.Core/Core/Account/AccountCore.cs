using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebBetDW.Context.Context;
using WebBetDW.Core.Core.User.Interfaces;
using WebBetDW.Models.DTOs;
using WebBetDW.Models.DTOs.User;
using WebBetDW.Models.Entities;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Core.User
{
    public class AccountCore : IAccountCore
    {
        //Inicimos con el patron de diseño que en este caso es por inyección de dependencias 
        #region Fields

        private readonly WebBetDWContext _webBetDWContext;
        private readonly IMapper _mapper;

        #endregion

        #region Builder

        public AccountCore(WebBetDWContext webBetDWContext, IMapper mapper)
        {
            _webBetDWContext = webBetDWContext;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<List<AccountDTO>> GetAll()
        {
            var data = _webBetDWContext.Cuenta.ToList();
            if (data.Count() <= 0)
            {
                return null;
            }
            var dataMapper = _mapper.Map<List<Cuenta>, List<AccountDTO>>(data);
            return await Task.FromResult(dataMapper.Count() > 0 ? dataMapper : null);
        }

        public async Task<AccountDTO> GetByPasswordMail(LoginRequest loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Mail))
            {
                return null;
            }
            if (string.IsNullOrEmpty(loginModel.Password))
            {
                return null;
            }
            var data = _webBetDWContext.Cuenta.FirstOrDefault(x => x.Contraseña == loginModel.Password &&
            x.Correo == loginModel.Mail);
            if (data == null) 
            {
                return null;
            }
            var dataMapper = _mapper.Map<Cuenta, AccountDTO>(data);
            return await Task.FromResult(dataMapper != null ? dataMapper : null);
        }

        public async Task<bool> AddOrUpdate(AccountRequest accountModel) 
        {
            Cuenta dataMapper = new Cuenta();      
            if (string.IsNullOrEmpty(accountModel.Idcuenta))
            {
                if (!string.IsNullOrEmpty(accountModel.Rol))
                {
                    Guid output;
                    if (Guid.TryParse(accountModel.Rol , out output))
                    {
                         dataMapper = _mapper.Map<Cuenta>(accountModel);
                        _webBetDWContext.Cuenta.Add(dataMapper);
                      
                    }
                }
            }
            if (!string.IsNullOrEmpty(accountModel.Idcuenta))
            {
                if (!string.IsNullOrEmpty(accountModel.Rol))
                {
                    Guid output;
                    if (Guid.TryParse(accountModel.Rol, out output))
                    {
                         dataMapper = _mapper.Map<Cuenta>(accountModel);
                        _webBetDWContext.Cuenta.Update(dataMapper);

                    }
                }
            }
            var res = _webBetDWContext.SaveChanges();
            return await Task.FromResult(res != 0 ? true : false);
            
        }
        #endregion

    }


}

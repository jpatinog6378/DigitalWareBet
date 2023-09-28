using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetDW.Models.Requests;

namespace WebBetDW.Core.Helpers.Interfaces
{
    public interface IValidateGuidHelper
    {
        /// <summary>
        /// Servicio que nos trae la información inicial al cargar el aplicativo
        /// </summary>
        /// <returns></returns>
        Task<Guid?> ValidateGuid(string guid);
    }
}

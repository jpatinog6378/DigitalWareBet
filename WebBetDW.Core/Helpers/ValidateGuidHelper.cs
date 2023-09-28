using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetDW.Context.Context;
using WebBetDW.Core.Helpers.Interfaces;
using WebBetDW.Models.Entities;

namespace WebBetDW.Core.Helpers
{
    public class ValidateGuidHelper : IValidateGuidHelper
    {
        public async Task<Guid?> ValidateGuid(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                Guid output;
                if (Guid.TryParse(guid, out output))
                {
                    return Guid.Parse(guid);   
                }
            }
            return null;    

        }
    }
}

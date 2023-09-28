using Microsoft.Extensions.DependencyInjection;
using WebBetDW.Core.Core.Bet;
using WebBetDW.Core.Core.Bet.Interfaces;
using WebBetDW.Core.Core.Match;
using WebBetDW.Core.Core.Match.Interfaces;
using WebBetDW.Core.Core.Session;
using WebBetDW.Core.Core.Session.Interfaces;
using WebBetDW.Core.Core.Team;
using WebBetDW.Core.Core.Team.Interfaces;
using WebBetDW.Core.Core.User;
using WebBetDW.Core.Core.User.Interfaces;
using WebBetDW.Core.Helpers;
using WebBetDW.Core.Helpers.Interfaces;

namespace WebBetDW.Ioc.Dependencies
{
    public class RegisterDependency
    {
        public static void RegisterDependencies(IServiceCollection service)
        {
            //Se inicia el registro de las inyecciones de dependencias donde se inicia por la interfaz
            //y despues la clase.
            service.AddScoped<IAccountCore, AccountCore>();
            service.AddScoped<ITeamCore, TeamCore>();
            service.AddScoped<IMatchCore, MatchCore>();
            service.AddScoped<ISessionCore, SessionCore>();
            service.AddScoped<IBetCore, BetCore>();
            service.AddScoped<IValidateGuidHelper, ValidateGuidHelper>();
        }
    }
}

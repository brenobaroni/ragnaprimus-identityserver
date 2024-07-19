using Domain.Entities.Painel;
using Domain.Models.Base.Response;
using Domain.Models.Login.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILoginService
    {
        Task<ZzPainelUserEntity> GetUserAsync(string email);
        Task<(bool, int?)> ValidadePassword(string username, string password);
    }
}

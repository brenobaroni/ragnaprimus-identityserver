using Domain.Contracts_Repository;
using Domain.Entities.Painel;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IZzPainelUserRepository _zzPainelUserRepository;

        public LoginService(IZzPainelUserRepository zzPainelUserRepository)
        {
            _zzPainelUserRepository = zzPainelUserRepository;
        }

        public async Task<ZzPainelUserEntity> GetUserAsync(string email)
        {
            var user = await _zzPainelUserRepository.GetAll().AsNoTracking().Where(w => w.email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<(bool, int?)> ValidadePassword(string username, string password)
        {
            var user = await _zzPainelUserRepository.GetAll().AsNoTracking().FirstOrDefaultAsync(w => w.email == username && w.password == password);
            return (user != null, user?.id);
        } 

        
    }
}

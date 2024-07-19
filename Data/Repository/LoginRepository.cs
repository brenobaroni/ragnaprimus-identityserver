using Data.Context;
using Domain.Contracts_Repository;
using Domain.Entities.Ragnarok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LoginRepository : BaseRepository<LoginEntity, RagnarokContext>, ILoginRepository
    {
        public LoginRepository(RagnarokContext context) : base(context) { }
    }
}

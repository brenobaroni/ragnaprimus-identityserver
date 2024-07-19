using Data.Context;
using Domain.Contracts_Repository;
using Domain.Entities.Painel;
using Domain.Entities.Ragnarok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ZzPainelUserRepository : BaseRepository<ZzPainelUserEntity, RagnarokContext>, IZzPainelUserRepository
    {
        public ZzPainelUserRepository(RagnarokContext context) : base(context) { }
    }
}

using Domain.Entities.Painel;
using Domain.Entities.Ragnarok;
using Google;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class RagnarokContext : DbContext
    {
        public RagnarokContext(DbContextOptions<RagnarokContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }


        #region DbSet
        public DbSet<LoginEntity> login { get; set; }
        public DbSet<ZzPainelUserEntity> zz_painel_user { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

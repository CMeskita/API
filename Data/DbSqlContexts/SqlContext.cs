using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.DbSqlContexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Rotina> Rotina { get; set; }
    }
}

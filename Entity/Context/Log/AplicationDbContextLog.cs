using Entity.Model.Auditoria;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context.Log
{
    public class AplicationDbContextLog : DbContext
    {

        public DbSet<Auditoria> Log { get; set; }
        public AplicationDbContextLog(DbContextOptions<AplicationDbContextLog> options ) : base (options)
        {
                    
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }


    }
}

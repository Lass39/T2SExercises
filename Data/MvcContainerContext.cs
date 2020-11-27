using Microsoft.EntityFrameworkCore;
using MvcContainer.Models;

namespace MvcContainer.Data
{
    using MvcContainer.Models;
    public class MvcContainerContext : DbContext
    {
        public MvcContainerContext(DbContextOptions<MvcContainerContext> options)
            : base(options)
        {
        }

        public DbSet<MvcContainer.Models.Container> Container { get; set; }
        public DbSet<MvcContainer.Models.Client> Client { get; set; }

        public DbSet<MvcContainer.Models.Navio> Navio { get; set; }

        public DbSet<MvcContainer.Models.Movimentacao> Movimentacao { get; set; }

        


        public DbSet<MvcContainer.Models.StatusContainer> StatusContainer { get; set; }


        public DbSet<MvcContainer.Models.TipoContainer> TipoContainer { get; set; }


        public DbSet<MvcContainer.Models.TipoMovimentacao> TipoMovimentacao { get; set; }


        public DbSet<MvcContainer.Models.CategoriaContainer> CategoriaContainer { get; set; }



    }
}




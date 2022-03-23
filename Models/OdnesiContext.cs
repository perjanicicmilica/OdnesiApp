
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class OdnesiContext : DbContext
    {
        public DbSet<Prodavnica> Prodavnice {get;set;} 
        public DbSet<Kategorija> Kategorije {get;set;}
        public DbSet<Proizvodi> Proizvodi { get; set; }
        /*public DbSet<Spoj> ProdavnicaKategorija { get; set; }*/
        public OdnesiContext(DbContextOptions options) : base(options)
        {

        }
    }
}
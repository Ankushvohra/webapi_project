using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using webapi_project.Models;

namespace webapi_project.Data
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext>options):base(options)
        {
            
        }
        public DbSet<NationalPark> NationalParks { get; set; }

        public DbSet<trail> trails { get; set; }
    }
}

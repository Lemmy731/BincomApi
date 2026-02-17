using BincomProjectApi.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BincomProjectApi.Repository.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
    }
}

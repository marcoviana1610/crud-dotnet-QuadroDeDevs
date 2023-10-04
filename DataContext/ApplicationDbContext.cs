using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DevModel> Desenvolvedores { get; set; }
    }
}

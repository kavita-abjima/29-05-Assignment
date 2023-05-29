using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiDbMigrations.Models;

namespace WebApiDbMigrations.Data
{
    public class WebApiDbMigrationsContext : DbContext
    {
        public WebApiDbMigrationsContext (DbContextOptions<WebApiDbMigrationsContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee{ get; set; } = default!;
    }
}

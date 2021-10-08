using Microsoft.EntityFrameworkCore;
using Blazor.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Server.Data
{
    public class eDbContext : DbContext
    {
        public eDbContext(DbContextOptions<eDbContext> options)
            : base(options)
        {

        }

        public DbSet<cSweet> Sweets { get; set; }
        public DbSet<cIngrediant> Ingrediants { get; set; }
        public DbSet<cUser> Users { get; set; }
    }
}

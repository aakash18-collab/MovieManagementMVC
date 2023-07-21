using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieManagementMVC.Models;

namespace MovieManagementMVC.Data
{
    public class MovieManagementMVCContext : DbContext
    {
        public MovieManagementMVCContext (DbContextOptions<MovieManagementMVCContext> options)
            : base(options)
        {
        }

      
        public DbSet<MovieManagementMVC.Models.Halls> Halls { get; set; } = default!;

        public DbSet<MovieManagementMVC.Models.Movies>? Movies { get; set; }

        public DbSet<MovieManagementMVC.Models.Shifts>? Shifts { get; set; }

        public DbSet<MovieManagementMVC.Models.NowShowing>? NowShowings { get; set; }

    }
}

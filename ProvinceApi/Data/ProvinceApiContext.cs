using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProvinceApi.Models
{
    public class ProvinceApiContext : DbContext
    {
        public ProvinceApiContext (DbContextOptions<ProvinceApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProvinceApi.Models.Province> Province { get; set; }
    }
}

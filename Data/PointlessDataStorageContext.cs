using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PointlessDataStorage.Models
{
    public class PointlessDataStorageContext : DbContext
    {
        public PointlessDataStorageContext (DbContextOptions<PointlessDataStorageContext> options)
            : base(options)
        {
        }

        public DbSet<PointlessDataStorage.Models.UselessDataBlock> UselessDataBlock { get; set; }
    }
}

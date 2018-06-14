using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointlessDataStorage.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new PointlessDataStorageContext(
                serviceProvider.GetRequiredService<DbContextOptions<PointlessDataStorageContext>>())) {
                if (context.UselessDataBlock.Any()) {
                    return; //Database already has data
                }

                context.UselessDataBlock.AddRange(
                    new UselessDataBlock {
                        name = "One Hundred",
                        randomDate = DateTime.Parse("1989-1-25"),
                        garbageFloat = 0.123f
                    },

                    new UselessDataBlock {
                        name = "whatishispowerlevel",
                        randomDate = DateTime.Parse("2006-6-02"),
                        garbageFloat = 9001f
                    }

                    );
                context.SaveChanges();
            }
        }

    }
}

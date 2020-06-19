using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudTest.Spec.Common
{
    public class AppContextFactory
    {
        public static AppDbContext Create()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static void Destroy(AppDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

    }
}

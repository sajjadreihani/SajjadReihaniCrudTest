using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTest.Common
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

            context.Customers.AddRange(new[] {
                new Customer{Id=1,FirstName="Saji",LastName="Rei",DateOfBirth = DateTime.Parse("18/06/2000"),BankAccountNumber="sadasd",Email="saji@cc.cc",PhoneNumber="+989399158667"},
            });


            context.SaveChanges();

            return context;
        }

        public static void Destroy(AppDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

    }
}

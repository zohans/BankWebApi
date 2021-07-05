using BankWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BankContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="Carson",LastName="Alexander", UserName="CarsonA", CreatedDate=DateTime.Now},
            new User{FirstName="Meredith",LastName="Alonso", UserName="MeredithA",CreatedDate=DateTime.Now},
            new User{FirstName="Arturo",LastName="Anand", UserName= "ArturoA",CreatedDate =DateTime.Now},
            new User{FirstName="Gytis",LastName="Barzdukas", UserName="GytisB",CreatedDate =DateTime.Now},
            new User{FirstName="Yan",LastName="Li", UserName="YanL",CreatedDate =DateTime.Now},
            new User{FirstName="Peggy",LastName="Justice", UserName="PeggyJ",CreatedDate =DateTime.Now},
            new User{FirstName="Laura",LastName="Norman", UserName="LauraN",CreatedDate =DateTime.Now},
            new User{FirstName="Nino",LastName="Olivetto", UserName="NinoO",CreatedDate =DateTime.Now}
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();


            var bankAccounts = new BankAccount[]
            {
            new BankAccount{UserId=1,Balance=1050,Name="abc1",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=1,Balance=4022,Name="abc2",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=1,Balance=4041,Name="abc3",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=2,Balance=1045,Name="abc4",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=2,Balance=3141,Name="abc5",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=2,Balance=2021,Name="abc6",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=3,Balance=1050,Name="abc7",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=4,Balance=1050,Name="abc8",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=4,Balance=4022,Name="abc9",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=5,Balance=4041,Name="abc10",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=6,Balance=1045,Name="abc11",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            new BankAccount{UserId=7,Balance=3141,Name="abc12",CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now},
            };

            foreach (BankAccount e in bankAccounts)
            {
                context.BankAccounts.Add(e);
            }
            context.SaveChanges();
        }
    }
}

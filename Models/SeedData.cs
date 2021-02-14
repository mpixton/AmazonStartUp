using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonStartUp.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            AmazonDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<AmazonDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        ISBN = "978-0451419439",
                        Price = 9.95M,
                        Title = "Les Miserables"
                    },
                    new Book
                    {
                        ISBN = "978-0743270755",
                        Price = 14.58M,
                        Title = "Team of Rivals"
                    },
                    new Book
                    {
                        ISBN = "978-0553384611",
                        Price = 21.54M,
                        Title= "The Snowball"
                    },
                    new Book
                    {
                        ISBN = "978-0812981254",
                        Price = 11.61M,
                        Title = "American Ulysses"
                    },
                    new Book
                    {
                        ISBN = "978-0812974492",
                        Price = 13.33M,
                        Title = "Unbroken"
                    },
                    new Book
                    {
                        ISBN = "978-0804171281",
                        Price = 15.95M,
                        Title = "The Great Train Robbery"
                    },
                    new Book
                    {
                        ISBN = "978-1455586691",
                        Price = 14.99M,
                        Title = "Deep Work"
                    },
                    new Book
                    {
                        ISBN = "978-1455523023",
                        Price = 21.66M,
                        Title = "It's Your Ship"
                    },
                    new Book
                    {
                        ISBN = "978-1591847984",
                        Price = 29.16M,
                        Title = "The Virgin Way"
                    },
                    new Book
                    {
                        ISBN = "978-0553393613",
                        Price = 15.03M,
                        Title = "Sycamore Row"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

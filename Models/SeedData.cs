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
                        Title = "Les Miserables",
                        AuthFirstName = "Victor",
                        AuthLastName = "Hugo",
                        Publisher = "Signet",
                        Classification = "Fiction",
                        Category = "Classic"
                    },
                    new Book
                    {
                        ISBN = "978-0743270755",
                        Price = 14.58M,
                        Title = "Team of Rivals",
                        AuthFirstName = "Doris",
                        AuthMidName = "Kearns",
                        AuthLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        Classification = "Non-Fiction",
                        Category = "Biography"
                    },
                    new Book
                    {
                        ISBN = "978-0553384611",
                        Price = 21.54M,
                        Title= "The Snowball",
                        AuthFirstName = "Alice",
                        AuthLastName = "Schroeder",
                        Publisher = "Bantam",
                        Classification = "Non-Fiction",
                        Category = "Biography"
                    },
                    new Book
                    {
                        ISBN = "978-0812981254",
                        Price = 11.61M,
                        Title = "American Ulysses",
                        AuthFirstName = "Ronald",
                        AuthMidName = "C.",
                        AuthLastName = "White",
                        Publisher = "Random House",
                        Classification = "Non-Fiction",
                        Category = "Biography"
                    },
                    new Book
                    {
                        ISBN = "978-0812974492",
                        Price = 13.33M,
                        Title = "Unbroken",
                        AuthFirstName = "Laura",
                        AuthLastName = "Hillenbrand",
                        Publisher= "Random House",
                        Classification = "Non-Fiction",
                        Category = "Historical"
                    },
                    new Book
                    {
                        ISBN = "978-0804171281",
                        Price = 15.95M,
                        Title = "The Great Train Robbery",
                        AuthFirstName = "Michael",
                        AuthLastName = "Crichton",
                        Publisher = "Vintage",
                        Classification = "Fiction",
                        Category = "Historical"
                    },
                    new Book
                    {
                        ISBN = "978-1455586691",
                        Price = 14.99M,
                        Title = "Deep Work",
                        AuthFirstName = "Cal",
                        AuthLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        Classification = "Non-Fiction",
                        Category = "Self-Help"
                    },
                    new Book
                    {
                        ISBN = "978-1455523023",
                        Price = 21.66M,
                        Title = "It's Your Ship",
                        AuthFirstName = "Michael",
                        AuthLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Classification = "Non-Fiction",
                        Category = "Self-Help"
                    },
                    new Book
                    {
                        ISBN = "978-1591847984",
                        Price = 29.16M,
                        Title = "The Virgin Way",
                        AuthFirstName = "Richard",
                        AuthLastName = "Branson",
                        Publisher = "Portfolio",
                        Classification = "Non-Fiction",
                        Category = "Business"
                    },
                    new Book
                    {
                        ISBN = "978-0553393613",
                        Price = 15.03M,
                        Title = "Sycamore Row",
                        AuthFirstName = "John",
                        AuthLastName = "Grisham",
                        Publisher = "Bantam",
                        Classification = "Fiction",
                        Category = "Thriller"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

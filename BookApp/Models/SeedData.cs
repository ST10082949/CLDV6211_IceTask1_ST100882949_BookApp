using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookApp.Data;
using System;
using System.Linq;

namespace BookApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BookAppContext>>()))
        {
            // Look for any movies.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }
            context.Book.AddRange(
                new Book
                {
                    Title = "Othello",
                    Author = "Shakespear",
                    PublicationYear = DateTime.Parse("1999-8-13"),
                    Genre = "Romantic Novel"
                    
                },
                new Book
                {
                    Title = "Macbeth",
                    Author = "Shakespear",
                    PublicationYear = DateTime.Parse("1989-3-2"),
                    Genre = "Dramatic"

                },

                new Book
                {
                    Title = "Life of Pi",
                    Author = "S.James",
                    PublicationYear = DateTime.Parse("2009-7-22"),
                    Genre = "Adventure"

                },

                new Book
                {
                    Title = "Harry Potter",
                    Author = "M.Smith",
                    PublicationYear = DateTime.Parse("1989-2-12"),
                    Genre = "Fantasy"

                }
            );
            context.SaveChanges();
        }
    }
}
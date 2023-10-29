using Microsoft.EntityFrameworkCore;
using MyScriptureJournal1.Data;
using MyScriptureJournal1.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyScriptureJournal1Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyScriptureJournal1Context>>()))
        {
            if (context == null || context.Journal == null)
            {
                throw new ArgumentNullException("Null MyScriptureJournal1Context");
            }

            // Look for any journals.
            if (context.Journal.Any())
            {
                return;   // DB has been seeded
            }

            context.Journal.AddRange(
                new Journal
                {
                    Book = "1 Nephi 3:7",
                    DateAdded = DateTime.Parse("2023-2-12"),
                    Entry = "No commandments are given to us without the Lord providing a way for us to accomplish them.",
                },

                new Journal
                {
                    Book = "Jacob 1:16",
                    DateAdded = DateTime.Parse("2023-7-26"),
                    Entry = "We need to be careful of pride, it will drag us down.",
                },

                new Journal
                {
                    Book = "Alma 22:6-8",
                    DateAdded = DateTime.Parse("2023-10-28"),
                    Entry = "There is a God.",
                },

                new Journal
                {
                    Book = "Helaman 2:27",
                    DateAdded = DateTime.Parse("2023-9-22"),
                    Entry = "The Lord will show mercy on those who will pray unto him with a sincere heart.",
                }
            );
            context.SaveChanges();
        }
    }
}
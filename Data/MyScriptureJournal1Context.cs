using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal1.Models;

namespace MyScriptureJournal1.Data
{
    public class MyScriptureJournal1Context : DbContext
    {
        public MyScriptureJournal1Context (DbContextOptions<MyScriptureJournal1Context> options)
            : base(options)
        {
        }

        public DbSet<MyScriptureJournal1.Models.Journal> Journal { get; set; } = default!;
    }
}

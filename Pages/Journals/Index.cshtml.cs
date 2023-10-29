using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal1.Data;
using MyScriptureJournal1.Models;

namespace MyScriptureJournal1.Pages.Journals
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal1.Data.MyScriptureJournal1Context _context;

        public IndexModel(MyScriptureJournal1.Data.MyScriptureJournal1Context context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? JournalBook{ get; set; }

        public async Task OnGetAsync()
        {
            var journals = from j in _context.Journal
                         select j;
            if (!string.IsNullOrEmpty(SearchString))
            {
                journals = journals.Where(s => s.Entry.Contains(SearchString));
            }

            Journal = await journals.ToListAsync();
        }
    }
}

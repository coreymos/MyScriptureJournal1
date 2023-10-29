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
    public class EditModel : PageModel
    {
        private readonly MyScriptureJournal1.Data.MyScriptureJournal1Context _context;

        public EditModel(MyScriptureJournal1.Data.MyScriptureJournal1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Journal Journal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Journal == null)
            {
                return NotFound();
            }

            var journal =  await _context.Journal.FirstOrDefaultAsync(m => m.Id == id);
            if (journal == null)
            {
                return NotFound();
            }
            Journal = journal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(Journal.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JournalExists(int id)
        {
          return (_context.Journal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyScriptureJournal1.Data;
using MyScriptureJournal1.Models;

namespace MyScriptureJournal1.Pages.Journals
{
    public class CreateModel : PageModel
    {
        private readonly MyScriptureJournal1.Data.MyScriptureJournal1Context _context;

        public CreateModel(MyScriptureJournal1.Data.MyScriptureJournal1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Journal Journal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Journal == null || Journal == null)
            {
                return Page();
            }

            _context.Journal.Add(Journal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal1.Data;
using MyScriptureJournal1.Models;

namespace MyScriptureJournal1.Pages.Journals
{
    public class DetailsModel : PageModel
    {
        private readonly MyScriptureJournal1.Data.MyScriptureJournal1Context _context;

        public DetailsModel(MyScriptureJournal1.Data.MyScriptureJournal1Context context)
        {
            _context = context;
        }

      public Journal Journal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Journal == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.FirstOrDefaultAsync(m => m.Id == id);
            if (journal == null)
            {
                return NotFound();
            }
            else 
            {
                Journal = journal;
            }
            return Page();
        }
    }
}

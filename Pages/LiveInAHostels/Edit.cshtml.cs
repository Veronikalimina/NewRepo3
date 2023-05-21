﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.LiveInAHostels
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LiveInAHostel LiveInAHostel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.LiveInAHostel == null)
            {
                return NotFound();
            }

            var liveinahostel =  await _context.LiveInAHostel.FirstOrDefaultAsync(m => m.IdEntryLiveInAHostel == id);
            if (liveinahostel == null)
            {
                return NotFound();
            }
            LiveInAHostel = liveinahostel;
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

            _context.Attach(LiveInAHostel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiveInAHostelExists(LiveInAHostel.IdEntryLiveInAHostel))
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

        private bool LiveInAHostelExists(long id)
        {
          return (_context.LiveInAHostel?.Any(e => e.IdEntryLiveInAHostel == id)).GetValueOrDefault();
        }
    }
}

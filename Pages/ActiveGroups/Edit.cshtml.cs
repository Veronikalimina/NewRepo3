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

namespace WebApplication1.Pages.ActiveGroups
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActiveGroup ActiveGroup { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ActiveGroup == null)
            {
                return NotFound();
            }

            var activegroup =  await _context.ActiveGroup.FirstOrDefaultAsync(m => m.IdActiveGroup == id);
            if (activegroup == null)
            {
                return NotFound();
            }
            ActiveGroup = activegroup;
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

            _context.Attach(ActiveGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveGroupExists(ActiveGroup.IdActiveGroup))
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

        private bool ActiveGroupExists(long id)
        {
          return (_context.ActiveGroup?.Any(e => e.IdActiveGroup == id)).GetValueOrDefault();
        }
    }
}

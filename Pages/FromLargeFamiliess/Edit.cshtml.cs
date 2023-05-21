using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.FromLargeFamiliess
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FromLargeFamilies FromLargeFamilies { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.FromLargeFamilies == null)
            {
                return NotFound();
            }

            var fromlargefamilies =  await _context.FromLargeFamilies.FirstOrDefaultAsync(m => m.IdEntryFromLargeFamilies == id);
            if (fromlargefamilies == null)
            {
                return NotFound();
            }
            FromLargeFamilies = fromlargefamilies;
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

            _context.Attach(FromLargeFamilies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FromLargeFamiliesExists(FromLargeFamilies.IdEntryFromLargeFamilies))
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

        private bool FromLargeFamiliesExists(long id)
        {
          return (_context.FromLargeFamilies?.Any(e => e.IdEntryFromLargeFamilies == id)).GetValueOrDefault();
        }
    }
}

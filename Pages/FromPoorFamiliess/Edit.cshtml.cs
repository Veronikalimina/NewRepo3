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

namespace WebApplication1.Pages.FromPoorFamiliess
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FromPoorFamilies FromPoorFamilies { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.FromPoorFamilies == null)
            {
                return NotFound();
            }

            var frompoorfamilies =  await _context.FromPoorFamilies.FirstOrDefaultAsync(m => m.IdEntryFromPoorFamilies == id);
            if (frompoorfamilies == null)
            {
                return NotFound();
            }
            FromPoorFamilies = frompoorfamilies;
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

            _context.Attach(FromPoorFamilies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FromPoorFamiliesExists(FromPoorFamilies.IdEntryFromPoorFamilies))
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

        private bool FromPoorFamiliesExists(long id)
        {
          return (_context.FromPoorFamilies?.Any(e => e.IdEntryFromPoorFamilies == id)).GetValueOrDefault();
        }
    }
}

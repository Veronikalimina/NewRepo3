using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.Orphanss
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Orphans Orphans { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Orphans == null)
            {
                return NotFound();
            }

            var orphans = await _context.Orphans.FirstOrDefaultAsync(m => m.IdEntryOrphans == id);

            if (orphans == null)
            {
                return NotFound();
            }
            else 
            {
                Orphans = orphans;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Orphans == null)
            {
                return NotFound();
            }
            var orphans = await _context.Orphans.FindAsync(id);

            if (orphans != null)
            {
                Orphans = orphans;
                _context.Orphans.Remove(Orphans);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.OneParents
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OneParent OneParent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.OneParent == null)
            {
                return NotFound();
            }

            var oneparent = await _context.OneParent.FirstOrDefaultAsync(m => m.IdEntryOneParent == id);

            if (oneparent == null)
            {
                return NotFound();
            }
            else 
            {
                OneParent = oneparent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.OneParent == null)
            {
                return NotFound();
            }
            var oneparent = await _context.OneParent.FindAsync(id);

            if (oneparent != null)
            {
                OneParent = oneparent;
                _context.OneParent.Remove(OneParent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

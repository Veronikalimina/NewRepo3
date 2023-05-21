using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.EngagementWithParentss
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EngagementWithParents EngagementWithParents { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.EngagementWithParents == null)
            {
                return NotFound();
            }

            var engagementwithparents = await _context.EngagementWithParents.FirstOrDefaultAsync(m => m.IdEngagementWithParents == id);

            if (engagementwithparents == null)
            {
                return NotFound();
            }
            else 
            {
                EngagementWithParents = engagementwithparents;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.EngagementWithParents == null)
            {
                return NotFound();
            }
            var engagementwithparents = await _context.EngagementWithParents.FindAsync(id);

            if (engagementwithparents != null)
            {
                EngagementWithParents = engagementwithparents;
                _context.EngagementWithParents.Remove(EngagementWithParents);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

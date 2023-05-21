using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.ActiveGroups
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
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

            var activegroup = await _context.ActiveGroup.FirstOrDefaultAsync(m => m.IdActiveGroup == id);

            if (activegroup == null)
            {
                return NotFound();
            }
            else 
            {
                ActiveGroup = activegroup;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.ActiveGroup == null)
            {
                return NotFound();
            }
            var activegroup = await _context.ActiveGroup.FindAsync(id);

            if (activegroup != null)
            {
                ActiveGroup = activegroup;
                _context.ActiveGroup.Remove(ActiveGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

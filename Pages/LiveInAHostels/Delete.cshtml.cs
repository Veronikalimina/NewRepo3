using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.LiveInAHostels
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
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

            var liveinahostel = await _context.LiveInAHostel.FirstOrDefaultAsync(m => m.IdEntryLiveInAHostel == id);

            if (liveinahostel == null)
            {
                return NotFound();
            }
            else 
            {
                LiveInAHostel = liveinahostel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.LiveInAHostel == null)
            {
                return NotFound();
            }
            var liveinahostel = await _context.LiveInAHostel.FindAsync(id);

            if (liveinahostel != null)
            {
                LiveInAHostel = liveinahostel;
                _context.LiveInAHostel.Remove(LiveInAHostel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

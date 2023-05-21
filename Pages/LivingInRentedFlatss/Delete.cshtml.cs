using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.LivingInRentedFlatss
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LivingInRentedFlats LivingInRentedFlats { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.LivingInRentedFlats == null)
            {
                return NotFound();
            }

            var livinginrentedflats = await _context.LivingInRentedFlats.FirstOrDefaultAsync(m => m.IdEntryLivingInRentedFlats == id);

            if (livinginrentedflats == null)
            {
                return NotFound();
            }
            else 
            {
                LivingInRentedFlats = livinginrentedflats;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.LivingInRentedFlats == null)
            {
                return NotFound();
            }
            var livinginrentedflats = await _context.LivingInRentedFlats.FindAsync(id);

            if (livinginrentedflats != null)
            {
                LivingInRentedFlats = livinginrentedflats;
                _context.LivingInRentedFlats.Remove(LivingInRentedFlats);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}

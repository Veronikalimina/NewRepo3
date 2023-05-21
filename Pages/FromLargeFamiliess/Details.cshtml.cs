using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.FromLargeFamiliess
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

      public FromLargeFamilies FromLargeFamilies { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.FromLargeFamilies == null)
            {
                return NotFound();
            }

            var fromlargefamilies = await _context.FromLargeFamilies.FirstOrDefaultAsync(m => m.IdEntryFromLargeFamilies == id);
            if (fromlargefamilies == null)
            {
                return NotFound();
            }
            else 
            {
                FromLargeFamilies = fromlargefamilies;
            }
            return Page();
        }
    }
}

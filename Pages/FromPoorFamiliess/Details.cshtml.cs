using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.FromPoorFamiliess
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

      public FromPoorFamilies FromPoorFamilies { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.FromPoorFamilies == null)
            {
                return NotFound();
            }

            var frompoorfamilies = await _context.FromPoorFamilies.FirstOrDefaultAsync(m => m.IdEntryFromPoorFamilies == id);
            if (frompoorfamilies == null)
            {
                return NotFound();
            }
            else 
            {
                FromPoorFamilies = frompoorfamilies;
            }
            return Page();
        }
    }
}

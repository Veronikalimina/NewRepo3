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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}

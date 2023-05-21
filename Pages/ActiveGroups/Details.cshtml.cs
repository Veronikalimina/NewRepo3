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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}

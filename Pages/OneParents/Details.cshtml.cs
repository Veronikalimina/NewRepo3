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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}

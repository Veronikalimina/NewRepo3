using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.ChildrenWithDisabilitiess
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

      public ChildrenWithDisabilities ChildrenWithDisabilities { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.ChildrenWithDisabilities == null)
            {
                return NotFound();
            }

            var childrenwithdisabilities = await _context.ChildrenWithDisabilities.FirstOrDefaultAsync(m => m.IdEntryChildrenWithDisabilities == id);
            if (childrenwithdisabilities == null)
            {
                return NotFound();
            }
            else 
            {
                ChildrenWithDisabilities = childrenwithdisabilities;
            }
            return Page();
        }
    }
}

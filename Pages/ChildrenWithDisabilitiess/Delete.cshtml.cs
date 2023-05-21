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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.ChildrenWithDisabilities == null)
            {
                return NotFound();
            }
            var childrenwithdisabilities = await _context.ChildrenWithDisabilities.FindAsync(id);

            if (childrenwithdisabilities != null)
            {
                ChildrenWithDisabilities = childrenwithdisabilities;
                _context.ChildrenWithDisabilities.Remove(ChildrenWithDisabilities);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

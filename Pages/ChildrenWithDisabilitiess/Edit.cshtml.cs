using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.ChildrenWithDisabilitiess
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
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

            var childrenwithdisabilities =  await _context.ChildrenWithDisabilities.FirstOrDefaultAsync(m => m.IdEntryChildrenWithDisabilities == id);
            if (childrenwithdisabilities == null)
            {
                return NotFound();
            }
            ChildrenWithDisabilities = childrenwithdisabilities;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChildrenWithDisabilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildrenWithDisabilitiesExists(ChildrenWithDisabilities.IdEntryChildrenWithDisabilities))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChildrenWithDisabilitiesExists(long id)
        {
          return (_context.ChildrenWithDisabilities?.Any(e => e.IdEntryChildrenWithDisabilities == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.Curators
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Curator Curator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Curators == null)
            {
                return NotFound();
            }

            var curator = await _context.Curators.FirstOrDefaultAsync(m => m.IdCurator == id);

            if (curator == null)
            {
                return NotFound();
            }
            else 
            {
                Curator = curator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Curators == null)
            {
                return NotFound();
            }
            var curator = await _context.Curators.FindAsync(id);

            if (curator != null)
            {
                Curator = curator;
                _context.Curators.Remove(Curator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

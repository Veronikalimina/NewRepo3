using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.Authentications
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Authentication Authentication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Authentications == null)
            {
                return NotFound();
            }

            var authentication = await _context.Authentications.FirstOrDefaultAsync(m => m.IdAuthentication == id);

            if (authentication == null)
            {
                return NotFound();
            }
            else 
            {
                Authentication = authentication;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Authentications == null)
            {
                return NotFound();
            }
            var authentication = await _context.Authentications.FindAsync(id);

            if (authentication != null)
            {
                Authentication = authentication;
                _context.Authentications.Remove(Authentication);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

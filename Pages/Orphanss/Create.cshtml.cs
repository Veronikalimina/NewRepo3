using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.Orphanss
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public CreateModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Orphans Orphans { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Orphans == null || Orphans == null)
            {
                return Page();
            }

            _context.Orphans.Add(Orphans);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

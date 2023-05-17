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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}

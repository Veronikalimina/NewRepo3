using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.CuratorObservationSheets
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CuratorObservationSheet CuratorObservationSheet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CuratorObservationSheet == null)
            {
                return NotFound();
            }

            var curatorobservationsheet = await _context.CuratorObservationSheet.FirstOrDefaultAsync(m => m.IdCuratorObservationSheet == id);

            if (curatorobservationsheet == null)
            {
                return NotFound();
            }
            else 
            {
                CuratorObservationSheet = curatorobservationsheet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.CuratorObservationSheet == null)
            {
                return NotFound();
            }
            var curatorobservationsheet = await _context.CuratorObservationSheet.FindAsync(id);

            if (curatorobservationsheet != null)
            {
                CuratorObservationSheet = curatorobservationsheet;
                _context.CuratorObservationSheet.Remove(CuratorObservationSheet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

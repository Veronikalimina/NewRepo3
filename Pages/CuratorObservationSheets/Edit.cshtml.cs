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

namespace WebApplication1.Pages.CuratorObservationSheets
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
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

            var curatorobservationsheet =  await _context.CuratorObservationSheet.FirstOrDefaultAsync(m => m.IdCuratorObservationSheet == id);
            if (curatorobservationsheet == null)
            {
                return NotFound();
            }
            CuratorObservationSheet = curatorobservationsheet;
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

            _context.Attach(CuratorObservationSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuratorObservationSheetExists(CuratorObservationSheet.IdCuratorObservationSheet))
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

        private bool CuratorObservationSheetExists(long id)
        {
          return (_context.CuratorObservationSheet?.Any(e => e.IdCuratorObservationSheet == id)).GetValueOrDefault();
        }
    }
}

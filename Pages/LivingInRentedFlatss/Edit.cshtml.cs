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

namespace WebApplication1.Pages.LivingInRentedFlatss
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LivingInRentedFlats LivingInRentedFlats { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.LivingInRentedFlats == null)
            {
                return NotFound();
            }

            var livinginrentedflats =  await _context.LivingInRentedFlats.FirstOrDefaultAsync(m => m.IdEntryLivingInRentedFlats == id);
            if (livinginrentedflats == null)
            {
                return NotFound();
            }
            LivingInRentedFlats = livinginrentedflats;
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

            _context.Attach(LivingInRentedFlats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivingInRentedFlatsExists(LivingInRentedFlats.IdEntryLivingInRentedFlats))
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

        private bool LivingInRentedFlatsExists(long id)
        {
          return (_context.LivingInRentedFlats?.Any(e => e.IdEntryLivingInRentedFlats == id)).GetValueOrDefault();
        }
    }
}

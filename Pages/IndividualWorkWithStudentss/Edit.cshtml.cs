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

namespace WebApplication1.Pages.IndividualWorkWithStudentss
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IndividualWorkWithStudents IndividualWorkWithStudents { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.IndividualWorkWithStudents == null)
            {
                return NotFound();
            }

            var individualworkwithstudents =  await _context.IndividualWorkWithStudents.FirstOrDefaultAsync(m => m.IdIndividualWorkWithStudents == id);
            if (individualworkwithstudents == null)
            {
                return NotFound();
            }
            IndividualWorkWithStudents = individualworkwithstudents;
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

            _context.Attach(IndividualWorkWithStudents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualWorkWithStudentsExists(IndividualWorkWithStudents.IdIndividualWorkWithStudents))
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

        private bool IndividualWorkWithStudentsExists(long id)
        {
          return (_context.IndividualWorkWithStudents?.Any(e => e.IdIndividualWorkWithStudents == id)).GetValueOrDefault();
        }
    }
}

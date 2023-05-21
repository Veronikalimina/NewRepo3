using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.IndividualWorkWithStudentss
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
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

            var individualworkwithstudents = await _context.IndividualWorkWithStudents.FirstOrDefaultAsync(m => m.IdIndividualWorkWithStudents == id);

            if (individualworkwithstudents == null)
            {
                return NotFound();
            }
            else 
            {
                IndividualWorkWithStudents = individualworkwithstudents;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.IndividualWorkWithStudents == null)
            {
                return NotFound();
            }
            var individualworkwithstudents = await _context.IndividualWorkWithStudents.FindAsync(id);

            if (individualworkwithstudents != null)
            {
                IndividualWorkWithStudents = individualworkwithstudents;
                _context.IndividualWorkWithStudents.Remove(IndividualWorkWithStudents);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

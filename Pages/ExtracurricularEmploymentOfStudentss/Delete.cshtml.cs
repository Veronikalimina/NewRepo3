using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.ExtracurricularEmploymentOfStudentss
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DeleteModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ExtracurricularEmploymentOfStudents ExtracurricularEmploymentOfStudents { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.ExtracurricularEmploymentOfStudents == null)
            {
                return NotFound();
            }

            var extracurricularemploymentofstudents = await _context.ExtracurricularEmploymentOfStudents.FirstOrDefaultAsync(m => m.IdExtracurricularEmploymentOfStudents == id);

            if (extracurricularemploymentofstudents == null)
            {
                return NotFound();
            }
            else 
            {
                ExtracurricularEmploymentOfStudents = extracurricularemploymentofstudents;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.ExtracurricularEmploymentOfStudents == null)
            {
                return NotFound();
            }
            var extracurricularemploymentofstudents = await _context.ExtracurricularEmploymentOfStudents.FindAsync(id);

            if (extracurricularemploymentofstudents != null)
            {
                ExtracurricularEmploymentOfStudents = extracurricularemploymentofstudents;
                _context.ExtracurricularEmploymentOfStudents.Remove(ExtracurricularEmploymentOfStudents);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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

namespace WebApplication1.Pages.AccountingForClassHoursByStudentss
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public EditModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountingForClassHoursByStudents AccountingForClassHoursByStudents { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.AccountingForClassHoursByStudents == null)
            {
                return NotFound();
            }

            var accountingforclasshoursbystudents =  await _context.AccountingForClassHoursByStudents.FirstOrDefaultAsync(m => m.IdAccountingForClassHoursByStudents == id);
            if (accountingforclasshoursbystudents == null)
            {
                return NotFound();
            }
            AccountingForClassHoursByStudents = accountingforclasshoursbystudents;
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

            _context.Attach(AccountingForClassHoursByStudents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountingForClassHoursByStudentsExists(AccountingForClassHoursByStudents.IdAccountingForClassHoursByStudents))
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

        private bool AccountingForClassHoursByStudentsExists(long id)
        {
          return (_context.AccountingForClassHoursByStudents?.Any(e => e.IdAccountingForClassHoursByStudents == id)).GetValueOrDefault();
        }
    }
}

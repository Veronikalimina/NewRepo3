using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.AccountingForClassHoursByStudentss
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

      public AccountingForClassHoursByStudents AccountingForClassHoursByStudents { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.AccountingForClassHoursByStudents == null)
            {
                return NotFound();
            }

            var accountingforclasshoursbystudents = await _context.AccountingForClassHoursByStudents.FirstOrDefaultAsync(m => m.IdAccountingForClassHoursByStudents == id);
            if (accountingforclasshoursbystudents == null)
            {
                return NotFound();
            }
            else 
            {
                AccountingForClassHoursByStudents = accountingforclasshoursbystudents;
            }
            return Page();
        }
    }
}

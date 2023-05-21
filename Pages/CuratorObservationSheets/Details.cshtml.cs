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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public DetailsModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}

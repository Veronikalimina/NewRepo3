using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.DTO;

namespace WebApplication1.Pages.Authentications
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.ApplicationContext _context;

        public IndexModel(WebApplication1.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Authentication> Authentication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Authentications != null)
            {
                Authentication = await _context.Authentications.ToListAsync();
            }
        }
    }
}

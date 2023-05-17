using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;

namespace WebApplication1.Pages
{
    public class Admin1Model : PageModel
    {
        public void OnGet()
        {
            var groupsList = _context.Groups.ToList();
            Curators = _context.Curators.ToList();
            
        }
        private readonly ApplicationContext _context;

        public Admin1Model(ApplicationContext context)
        {
            _context = context;
        }
        public List<Curator> Curators { get; set; }
        public void OnPost()
        {

        }
    }
}

using PapaPizzaria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PapaPizzaria.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public IndexModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Include(c => c.Store)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
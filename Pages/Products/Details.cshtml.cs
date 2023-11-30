using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PapaPizzaria.Data;
using PapaPizzaria.Models;

namespace PapaPizzaria.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public DetailsModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

      public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

             Product = await _context.Products
        .AsNoTracking()
        .Include(c => c.Store)
        .FirstOrDefaultAsync(m => m.ProductID == id);
        
            if (Product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = Product;
            }
            return Page();
        }
    }
}

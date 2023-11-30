using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PapaPizzaria.Data;
using PapaPizzaria.Models;

namespace PapaPizzaria.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public DetailsModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

      public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
        .Include(s => s.Orders)
        .ThenInclude(e => e.Product)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);
            if (Customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = Customer;
            }
            return Page();
        }
    }
}

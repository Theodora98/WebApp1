using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PapaPizzaria.Data;
using PapaPizzaria.Models;

namespace PapaPizzaria.Pages.Stores
{
    public class DetailsModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public DetailsModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

      public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FirstOrDefaultAsync(m => m.StoreID == id);
            if (store == null)
            {
                return NotFound();
            }
            else 
            {
                Store = store;
            }
            return Page();
        }
    }
}

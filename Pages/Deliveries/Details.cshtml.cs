using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PapaPizzaria.Data;
using PapaPizzaria.Models;

namespace PapaPizzaria.Pages.Deliveries
{
    public class DetailsModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public DetailsModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

      public Delivery Delivery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Deliveries == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries.FirstOrDefaultAsync(m => m.ID == id);
            if (delivery == null)
            {
                return NotFound();
            }
            else 
            {
                Delivery = delivery;
            }
            return Page();
        }
    }
}

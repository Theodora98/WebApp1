using PapaPizzaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace PapaPizzaria.Pages.Deliveries
{
    public class DeleteModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public DeleteModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Delivery Delivery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Delivery = await _context.Deliveries.FirstOrDefaultAsync(m => m.ID == id);

            if (Delivery == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Delivery delivery = await _context.Deliveries
                .Include(i => i.Products)
                .SingleAsync(i => i.ID == id);

            if (delivery == null)
            {
                return RedirectToPage("./Index");
            }

            var stores = await _context.Stores
                .Where(d => d.DeliveryID == id)
                .ToListAsync();
            stores.ForEach(d => d.DeliveryID = null);

            _context.Deliveries.Remove(delivery);

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
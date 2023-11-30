using PapaPizzaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PapaPizzaria.Pages.Products
{
    public class EditModel : StoreNamePageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public EditModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(c => c.Store).FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateStoresDropDownList(_context, Product.StoreID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Products.FindAsync(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                 productToUpdate,
                 "product",   // Prefix for form value.
                   c => c.Credits, c => c.StoreID, c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select StoreID if TryUpdateModelAsync fails.
            PopulateStoresDropDownList(_context, productToUpdate.StoreID);
            return Page();
        }       
    }
}
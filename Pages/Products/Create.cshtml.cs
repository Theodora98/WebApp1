using PapaPizzaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PapaPizzaria.Pages.Products
{
    public class CreateModel : StoreNamePageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public CreateModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateStoresDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduct = new Product();

            if (await TryUpdateModelAsync<Product>(
                 emptyProduct,
                 "product",   // Prefix for form value.
                 s => s.ProductID, s => s.StoreID, s => s.Title, s => s.Credits))
            {
                _context.Products.Add(emptyProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select StoreID if TryUpdateModelAsync fails.
            PopulateStoresDropDownList(_context, emptyProduct.StoreID);
            return Page();
        }
      }
}
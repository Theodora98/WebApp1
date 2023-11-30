using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PapaPizzaria.Data;
using PapaPizzaria.Models;

namespace PapaPizzaria.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly PapaPizzaria.Data.PizzaContext _context;

        public CreateModel(PapaPizzaria.Data.PizzaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
{
    var emptyStudent = new Customer();

    if (await TryUpdateModelAsync<Customer>(
        emptyStudent,
        "student",   // Prefix for form value.
        s => s.FirstMidName, s => s.LastName, s => s.OrderDate))
    {
        _context.Customers.Add(emptyStudent);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    return Page();
}
        }
    }

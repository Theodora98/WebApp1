using PapaPizzaria.Data;
using PapaPizzaria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PapaPizzaria.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PapaPizzaria.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly PizzaContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(PizzaContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Customer> Customers { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Customer> CustomersIQ = from s in _context.Customers
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                CustomersIQ = CustomersIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    CustomersIQ = CustomersIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    CustomersIQ = CustomersIQ.OrderBy(s => s.OrderDate);
                    break;
                case "date_desc":
                    CustomersIQ = CustomersIQ.OrderByDescending(s => s.OrderDate);
                    break;
                default:
                    CustomersIQ = CustomersIQ.OrderBy(s => s.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Customers = await PaginatedList<Customer>.CreateAsync(
                CustomersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
using PapaPizzaria.Data;
using PapaPizzaria.Models;
using PapaPizzaria.Models.PizzaViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace PapaPizzaria.Pages.Deliveries
{
    public class DeliveryProductsPageModel : PageModel
    {
        public List<AssignedProductData> AssignedProductDataList;

        public void PopulateAssignedProductData(PizzaContext context,
                                               Delivery delivery)
        {
            var allProducts = context.Products;
            var deliveryProducts = new HashSet<int>(
                delivery.Products.Select(c => c.ProductID));
            AssignedProductDataList = new List<AssignedProductData>();
            foreach (var product in allProducts)
            {
                AssignedProductDataList.Add(new AssignedProductData
                {
                    ProductID = product.ProductID,
                    Title = product.Title,
                    Assigned = deliveryProducts.Contains(product.ProductID)
                });
            }
        }
    }
}
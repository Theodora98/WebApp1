using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PapaPizzaria.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]

         public int ProductID { get; set; }
         [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }
        public int StoreID { get; set; }

        public Store Store { get; set; }

        public ICollection<Order> Orders { get; set; }
         public ICollection<Delivery> Deliveries { get; set; }
    }
}
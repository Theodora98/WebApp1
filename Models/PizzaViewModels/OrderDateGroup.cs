using System;
using System.ComponentModel.DataAnnotations;

namespace PapaPizzaria.Models.PizzaViewModels
{
    public class OrderDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public int CustomerCount { get; set; }
    }
}
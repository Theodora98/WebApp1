using PapaPizzaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PapaPizzaria.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var alexander = new Customer
            {
                FirstMidName = "Carson",
                LastName = "Alexander",
                OrderDate = DateTime.Parse("2016-09-01")
            };

            var alonso = new Customer
            {
                FirstMidName = "Meredith",
                LastName = "Alonso",
                OrderDate = DateTime.Parse("2018-09-01")
            };

            var anand = new Customer
            {
                FirstMidName = "Arturo",
                LastName = "Anand",
                OrderDate = DateTime.Parse("2019-09-01")
            };

            var barzdukas = new Customer
            {
                FirstMidName = "Gytis",
                LastName = "Barzdukas",
                OrderDate = DateTime.Parse("2018-09-01")
            };

            var li = new Customer
            {
                FirstMidName = "Yan",
                LastName = "Li",
                OrderDate = DateTime.Parse("2018-09-01")
            };

            var justice = new Customer
            {
                FirstMidName = "Peggy",
                LastName = "Justice",
                OrderDate = DateTime.Parse("2017-09-01")
            };

            var norman = new Customer
            {
                FirstMidName = "Laura",
                LastName = "Norman",
                OrderDate = DateTime.Parse("2019-09-01")
            };

            var olivetto = new Customer
            {
                FirstMidName = "Nino",
                LastName = "Olivetto",
                OrderDate = DateTime.Parse("2011-09-01")
            };

            var customers = new Customer[]
            {
                alexander,
                alonso,
                anand,
                barzdukas,
                li,
                justice,
                norman,
                olivetto
            };

            context.AddRange(customers);

            var abercrombie = new Delivery
            {
                FirstMidName = "Kim",
                LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11")
            };

            var fakhouri = new Delivery
            {
                FirstMidName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06")
            };

            var harui = new Delivery
            {
                FirstMidName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01")
            };

            var kapoor = new Delivery
            {
                FirstMidName = "Candace",
                LastName = "Kapoor",
                HireDate = DateTime.Parse("2001-01-15")
            };

            var zheng = new Delivery
            {
                FirstMidName = "Roger",
                LastName = "Zheng",
                HireDate = DateTime.Parse("2004-02-12")
            };

            var deliveries = new Delivery[]
            {
                abercrombie,
                fakhouri,
                harui,
                kapoor,
                zheng
            };

            context.AddRange(deliveries);

            var storeAssignments = new StoreAssignment[]
            {
                new StoreAssignment {
                    Delivery = fakhouri,
                    Location = "Smith 17" },
                new StoreAssignment {
                    Delivery = harui,
                    Location = "Gowan 27" },
                new StoreAssignment {
                    Delivery = kapoor,
                    Location = "Thompson 304" }
            };

            context.AddRange(storeAssignments);

            var chalkida = new Store
            {
                Name = "Chalkida",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = abercrombie
            };

            var athens = new Store
            {
                Name = "Athens",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = fakhouri
            };

            var thessaloniki = new Store
            {
                Name = "Thessaloniki",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = harui
            };

            var patra = new Store
            {
                Name = "Patra",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                Administrator = kapoor
            };

            var stores = new Store[]
            {
                chalkida,
                athens,
                thessaloniki,
                patra
            };

            context.AddRange(stores);

            var margarita = new Product
            {
                ProductID = 1050,
                Title = "Margarita",
                Credits = 3,
                Store = chalkida,
                Deliveries = new List<Delivery> { kapoor, harui }
            };

            var special = new Product
            {
                ProductID = 4022,
                Title = "Special",
                Credits = 3,
                Store = patra,
                Deliveries = new List<Delivery> { zheng }
            };

            var pasta = new Product
            {
                ProductID = 4041,
                Title = "Pasta",
                Credits = 3,
                Store = chalkida,
                Deliveries = new List<Delivery> { zheng }
            };

            var chickenwings = new Product
            {
                ProductID = 1045,
                Title = "ChickenWings",
                Credits = 4,
                Store = athens,
                Deliveries = new List<Delivery> { fakhouri }
            };

            var garlicbread = new Product
            {
                ProductID = 3141,
                Title = "GarlicBread",
                Credits = 4,
                Store = patra,
                Deliveries = new List<Delivery> { harui }
            };

            var softdrinks = new Product
            {
                ProductID = 2021,
                Title = "SoftDrinks",
                Credits = 3,
                Store = chalkida,
                Deliveries = new List<Delivery> { abercrombie }
            };

            var desserts = new Product
            {
                ProductID = 2042,
                Title = "Desserts",
                Credits = 4,
                Store = athens,
                Deliveries = new List<Delivery> { abercrombie }
            };

            var products = new Product[]
            {
                margarita,
                special,
                pasta,
                chickenwings,
                garlicbread,
                softdrinks,
                desserts
            };

            context.AddRange(products);

            var orders = new Order[]
            {
                new Order {
                    Customer = alexander,
                    Product = margarita
                },
                new Order {
                    Customer = alexander,
                    Product = special
                },
                new Order {
                    Customer = alexander,
                    Product = chickenwings
                },
                new Order {
                    Customer = alonso,
                    Product = desserts
                },
                new Order {
                    Customer = alonso,
                    Product = softdrinks
                },
                new Order {
                    Customer = alonso,
                    Product = garlicbread
                },
                new Order {
                    Customer = anand,
                    Product = margarita
                },
                new Order {
                    Customer = anand,
                    Product = special
                },
                new Order {
                    Customer = barzdukas,
                    Product = chickenwings
                },
                new Order {
                    Customer = li,
                    Product = softdrinks
                },
                new Order {
                    Customer = justice,
                    Product = desserts
                }
            };

            context.AddRange(orders);
            context.SaveChanges();
        }
    }
}
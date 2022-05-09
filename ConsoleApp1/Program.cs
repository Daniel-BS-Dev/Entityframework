using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bread = new Product()
            {
                Name = "Pão Fracês",
                Category = "Padaria",
                Price = 0.69
            };

            var buying = new ToBuy();
            buying.Quantity = 6;
            buying.Product = bread;
            buying.Price = bread.Price * buying.Quantity;

            using(var context = new StoreContext())
            {
                context.Buys.Add(buying);
                context.SaveChanges();
            }


    }
    }
}

/* adicionando um produto
 
  var newProduct = new Product()
  {
      Name = "Desinfetante",
      Category = "limpeza",
      Price = 2.99
  };

  using (var context = new StoreContext())
  {
      context.Products.Add(newProduct);
      context.SaveChanges();
  }
 */

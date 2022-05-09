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
            var p1 = new Product() { Name = "Suco de laranja", Category = "Bebidas", Price = 8.79};
            var p2 = new Product() { Name = "uco de Caju", Category = "Bebidas", Price = 6.79 };
            var p3 = new Product() { Name = "Suco de Manga", Category = "Bebidas", Price = 7.79 };


            var productPromotion = new Promotion();
            productPromotion.Description = "Pascoa Feliz";
            productPromotion.DateBegin = DateTime.Now;
            productPromotion.DateEnd = DateTime.Now.AddMonths(3);

            productPromotion.IncludeProduct(p1);// metodo que eu vou criar
            productPromotion.IncludeProduct(p2); // metodo que eu vou criar
            productPromotion.IncludeProduct(p3); // metodo que eu vou criar

// persistindo no banco
            using (var context = new StoreContext())
            {
                context.Promotions.Add(productPromotion);
                context.SaveChanges();
            }
        }
    }
}

/*ADICIONANDO UM PRODUTO
 
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

/* ADICIONANDO UMA COMPRA
 
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
 */
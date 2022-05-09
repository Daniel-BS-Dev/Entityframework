using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.models
{
   public class Promotion
    {
        public int Id { get; internal set; }
        public string Description { get; internal set; }
        public DateTime DateBegin { get; internal set; }
        public DateTime DateEnd { get; internal set; }
        public IList<ProductPromotion> Products { get; internal set; } // relação muitos para um

        // construtor
        public Promotion()
        {
            Products = new List<ProductPromotion>();
        }

        // medoto criado para adicionar um produto
        public void IncludeProduct(Product product)
        {
            Products.Add(new ProductPromotion()
            {
                Product = product
            });
        }
    }
}

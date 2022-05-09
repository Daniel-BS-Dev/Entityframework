using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.models
{
   public class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double Price { get; internal set; }
        public IList<ProductPromotion> Promotions { get; set; }
    }
}

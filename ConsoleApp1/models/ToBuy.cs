using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.models
{
    public class ToBuy
    {
        // um para muitos
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; } // linha responsável por deixa o meu id produto obrigatório   
        public Product Product { get; set; }
        public double Price { get; set; }
    }
}

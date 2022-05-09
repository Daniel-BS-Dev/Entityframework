# Entityframework

## Baixar as libs
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.tools
- Microsoft.EntityFrameworkCore.SqlServer

## Relacionando um para muitos
- Classe Produto
````
public class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double Price { get; internal set; }
    }
``````

- Classe Compra
````
 public class ToBuy
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        // linha responsável por deixa o meu id produto obrigatório   
        public int ProductId { get; set; } 
        public Product Product { get; set; }
        public double Price { get; set; }
    }
``````

- Classe LojaContexto
````
public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
        
         public DbSet<ToBuy> Buys { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
``````

## Criando uma tabela no SQL
- Não posso esquecer de criar a migração inicial, logo após
- Add-Migration NomeDaTabela
- Update-Database

- Classe Program
````
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
``````

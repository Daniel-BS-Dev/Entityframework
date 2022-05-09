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

## Relacionamento muitos para muitos

- Classe Promoção
````
 public class Promotion
    {
        public int Id { get; internal set; }
        public string Description { get; internal set; }
        public DateTime DateBegin { get; internal set; }
        public DateTime DateEnd { get; internal set; }
        public IList<ProductPromotion> Products { get; internal set; } 

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
``````
- Classe Produto
````
 public class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double Price { get; internal set; }
        public IList<ProductPromotion> Promotions { get; set; }
    }
``````
- Classe PromoçãoProduto
````
    public class ProductPromotion
    {
        public int ProductId { get; set; } 
        public Product Product { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
``````
- Classe LojaContexto
````
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ToBuy> Buys { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        // Criando a chave composta da minha classe PromocaoProduto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPromotion>().HasKey(pp => new { pp.PromotionId, pp.ProductId });
            base.OnModelCreating(modelBuilder);
        }

        // sobreescrevendo o metodo. metodo de configuração
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // dizendo a minha maquina que quero usar o banco de dados. se caminho server... vem da minha classe dao
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }

    }
``````
- Add-Migration NomeDaTabela
- Update-Database

- Classe Program
````
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

            // metodo criando para adicionar uma promoção ao produto
            productPromotion.IncludeProduct(p1);
            productPromotion.IncludeProduct(p2); 
            productPromotion.IncludeProduct(p3); 

           // persistindo no banco
            using (var context = new StoreContext())
            {
                context.Promotions.Add(productPromotion);
                context.SaveChanges();
            }
        }
    }
``````



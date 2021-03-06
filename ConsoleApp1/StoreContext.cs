using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
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
}

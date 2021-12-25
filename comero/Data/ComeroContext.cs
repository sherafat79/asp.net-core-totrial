using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using comero.Models;
using Microsoft.EntityFrameworkCore;

namespace comero.Data
{
    public class ComeroContext:DbContext
    {
        public ComeroContext(DbContextOptions<ComeroContext> options ):base(options)
        {
                        
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new {t.ProductId, t.CategoryId});
            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(w => w.Id);
                i.Property(w => w.Price).HasColumnType("Money");
            });
            #region Seed Data 

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "دسته بندی اول",
                    Description = "توضیحات"
                },   new Category()
                {
                    Id = 2,
                    Name = "دسته بندی دوم",
                    Description = "توضیحات"
                },   new Category()
                {
                    Id = 3,
                    Name = "دسته بندی سوم",
                    Description = "توضیحات"
                },   new Category()
                {
                    Id = 4,
                    Name = "دسته بندی چهارم",
                    Description = "توضیحات"
                }
            );
            modelBuilder.Entity<Item>(i =>
            {
                i.HasData(
                    new Item()
                    {
                        Id = 1,
                        QuantityInStock = 10,
                        Price = 854.2M

                    }, new Item()
                    {
                        Id = 2,
                        QuantityInStock = 5,
                        Price = 84.2M

                    }, new Item()
                    {
                        Id = 3,
                        QuantityInStock = 10,
                        Price = 4200

                    }
                );
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasData(
                    new Product()
                    {
                        Id = 1 ,
                        ItemId =1 ,
                        Name = "محصول 1",
                        Description = "توضیحات",
                    }, new Product()
                    {
                        Id =2 ,
                        ItemId = 2,
                        Name = "محصول 2",
                        Description = "توضیحات",
                    }, new Product()
                    {
                        Id =3 ,
                        ItemId = 3,
                        Name = "محصول 2",
                        Description = "توضیحات",
                    }
                );
            }); 
            modelBuilder.Entity<CategoryToProduct>(cp =>
            {
                cp.HasData(
                 new CategoryToProduct {CategoryId = 1, ProductId = 1},
                 new CategoryToProduct {CategoryId = 2, ProductId = 1},
                 new CategoryToProduct {CategoryId = 3, ProductId = 1},
                 new CategoryToProduct {CategoryId = 4, ProductId = 1},
                 new CategoryToProduct {CategoryId = 1, ProductId = 2},
                 new CategoryToProduct {CategoryId = 2, ProductId = 2},
                 new CategoryToProduct {CategoryId = 3, ProductId = 2},
                 new CategoryToProduct {CategoryId = 4, ProductId = 2},
                 new CategoryToProduct {CategoryId = 1, ProductId = 3},
                 new CategoryToProduct {CategoryId = 2, ProductId = 3},
                 new CategoryToProduct {CategoryId = 3, ProductId = 3},
                 new CategoryToProduct {CategoryId = 4, ProductId = 3}
                
                );
            });



            #endregion
             
            base.OnModelCreating(modelBuilder);
        }
    }
}

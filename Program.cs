using System;
using enityframework.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace EnityFramework
{
    class Program{
        //CREATE DATABASE
        static void CreateDataBase(){
            using ProductDbContext ProductDbContext = new ProductDbContext();
            //Get name database 
            string dbname = ProductDbContext.Database.GetDbConnection().Database;
            Console.WriteLine($"Name database :{dbname}");
            //Check create database 
            //true if the database is created, false if it already existed.
            var result = ProductDbContext.Database.EnsureCreated();
            if(result) Console.WriteLine($"Create Database {dbname} successfully !");
            else Console.WriteLine($"Database generation {dbname} failed !");
       }
       //DROP DATABASE
       static void DropDatabase(){
            using ProductDbContext ProductDbContext = new ProductDbContext();
            string dbname = ProductDbContext.Database.GetDbConnection().Database;
            var result = ProductDbContext.Database.EnsureDeleted();
            if(result) Console.WriteLine($"Drop Database {dbname} successfully !");
            else Console.WriteLine($"Drop Database {dbname} failed !");
       }
       static void InsertProduct(){
        using ProductDbContext dbContent = new ProductDbContext();
            // step1 ModelBuilder Product()
            // Product product = new Product(){
            //     ProductName = "Nokia Lumia 224S",
            //     Provider = "Nokia",
            // };
            Product[] products = new Product[]{
                new Product(){
                    ProductName = "Kaximi S300",
                    Provider = "Xiami",
                },
                new Product(){
                    ProductName = "Nokia 1280",
                    Provider = "Nokia",
                },
            };
            // step2 Add, AddAsync
            //dbContent.Add(product); // them 1 san pham
            dbContent.AddRange(products); // them 1 mang san pham

            int number_rows = dbContent.SaveChanges(); //method saveChange ngoai viec lua data vao sql no con tra va ve so dong bi thay doi
            Console.WriteLine($"So dong duoc them vao {number_rows}");
        }
        static void GetProductByName(string name){
            using ProductDbContext dbContext = new ProductDbContext();
            // Product product = dbContext.products.Find(id);
            // product.PrintInfo();


            // var qr = from product in dbContext.products 
            //                   where product.ProductName.Contains($"{name}")
            //                   select product;
            // qr.ToList().ForEach(product => product.PrintInfo());

            Product qr = (from product in dbContext.products 
                            where product.ProductName.Contains($"{name}")
                            select product).FirstOrDefault(); //tra ve gia tri dau tien 
            if(qr != null){
                qr.PrintInfo();
            }
        }
        static void ReadProducts(){
            using ProductDbContext dbContext = new ProductDbContext();
            
            // var products = dbContext.products.ToList();
            // products.ForEach(product => product.PrintInfo());
            var qr = from product in dbContext.products
                     where product.ProductID > 0
                     orderby product.ProductID descending
                     select product;
            qr.ToList().ForEach(product => product.PrintInfo());
        }
        static void RenameProduct(int ID, string name){
            using ProductDbContext dbContext = new ProductDbContext();
            Product pr = (from product in dbContext.products where product.ProductID == ID select product).FirstOrDefault();
            if(pr != null){
                //EnityEntry la doi tuong theo doi su thay doi trong DB cuar EFCore
                //Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> entityEntry = dbContext.Entry(pr);
               // entityEntry.State = EntityState.Detached; <-- luc nay mode Product da~ ko con dc EFCore theo doi nua~, nen se ko CRUD dc nua~
                pr.ProductName = name;
                int numbers_row = dbContext.SaveChanges();
                Console.WriteLine($"Cap nhap thanh cong - row {numbers_row}");
            }
        }
   
        static void Main(string[] args){
            //CreateDataBase();
            //DropDatabase();
            //InsertProduct();
            // ReadProducts();
            GetProductByName("no");
            RenameProduct(12, "Nokia 128");
        }
    }
  
}
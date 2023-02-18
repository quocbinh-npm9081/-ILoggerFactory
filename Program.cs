using System;
using enityframework.Models;
using Microsoft.EntityFrameworkCore;

namespace EnityFramework
{
    class Program{
        //CREATE DATABASE
        static void CreateDataBase(){
            using ProdcutDbContext prodcutDbContext = new ProdcutDbContext();
            //Get name database 
            string dbname = prodcutDbContext.Database.GetDbConnection().Database;
            Console.WriteLine($"Name database :{dbname}");
            //Check create database 
            //true if the database is created, false if it already existed.
            var result = prodcutDbContext.Database.EnsureCreated();
            if(result) Console.WriteLine($"Create Database {dbname} successfully !");
            else Console.WriteLine($"Database generation {dbname} failed !");
       }
       //DROP DATABASE
       static void DropDatabase(){
            using ProdcutDbContext prodcutDbContext = new ProdcutDbContext();
            string dbname = prodcutDbContext.Database.GetDbConnection().Database;
            var result = prodcutDbContext.Database.EnsureDeleted();
            if(result) Console.WriteLine($"Drop Database {dbname} successfully !");
            else Console.WriteLine($"Drop Database {dbname} failed !");
       }
       static void InsertProduct(){
        using ProdcutDbContext dbContent = new ProdcutDbContext();
            // step1 ModelBuilder Product()
            // step2 Add, AddAsync
       }
        static void Main(string[] args){
            //CreateDataBase();
            //DropDatabase();

        }
    }
  
}
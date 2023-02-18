using System;
using Microsoft.EntityFrameworkCore;

namespace EnityFramework
{
    class Program{
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
        static void Main(string[] args){
            CreateDataBase();
        }
    }
  
}
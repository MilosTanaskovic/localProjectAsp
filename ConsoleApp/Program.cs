using DomainLayer;
using EfDataAccess;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AspProjContext();

            context.Standards.Add(new Standard
            {
                StandardName = "Profesor",
                Description = "Profesor PHP kursa",
                CreatedAt = DateTime.Now
            });

            context.SaveChanges();
        }
    }
}

using Supermarket.Models;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Data
{
    public class ApplicationDbCon:DbContext
    {
        public ApplicationDbCon(DbContextOptions<ApplicationDbCon>options):base (options)
        {
          
        }   
        public DbSet<Food> Foods { get; set; } 

        public DbSet <Snack> Snacks { get; set; }

        public  DbSet <Hygiene> Hygiene { get; set;}

        public DbSet<PersonalCare> PersonalCare { get; set; }

       public DbSet<Pet> Pet { get; set; }

       
    }
}

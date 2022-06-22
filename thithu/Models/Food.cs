using System;
using System.Data.Entity;
using System.Linq;

namespace thithu.Models
{
    public class Food : DbContext
    {

        public Food()
            : base("name=Food")
        {
            Database.SetInitializer<Food>(new CreateDatabaseIfNotExists<Food>());
        }

        private static Food _instance;

        public static Food Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Food();
                }
                return _instance;
            }
            private set { }
        }

        public virtual DbSet<Dish_Ingredient> Dish_Ingredients { get; set; }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

     
    }
}
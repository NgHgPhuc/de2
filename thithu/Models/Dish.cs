using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thithu.Models
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DishID { get; set; }

        [MaxLength]
        public string DishName { get; set; }

        public virtual ICollection<Dish_Ingredient> Dish_Ingredient { get; set; }



        public override string ToString()
        {
            return DishName;
        }
    }
}

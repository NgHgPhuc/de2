using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thithu.Models
{
    public class Dish_Ingredient
    {

        [Key]
        [StringLength(5, ErrorMessage = "Ma khong duoc vuot qua 5 ky tu")]
        public string ID { get; set; }

        public int Amount { get; set; }

        [MaxLength]
        public string Unit { get; set; }

        public int DishID { get; set; }
        [ForeignKey("DishID")]
        public virtual Dish Dishes { get; set; }


        public int IngredientID { get; set; }
        [ForeignKey("IngredientID")]
        public virtual Ingredient Ingredientes { get; set; }

    }
}

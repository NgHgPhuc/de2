using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thithu.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }

        [MaxLength]
        public string IngredientName { get; set; }

        public bool NhapKhau { get; set; }
        public virtual ICollection<Dish_Ingredient> Dish_Ingredient { get; set; }
    }
}

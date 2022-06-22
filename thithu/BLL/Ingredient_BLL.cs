using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thithu.Models;

namespace thithu.BLL
{
    public class Ingredient_BLL
    {
        private static Ingredient_BLL _instance;
        public static Ingredient_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Ingredient_BLL();
                }
                return _instance;
            }
            private set { }
        }

        public Object[] GetAllIngredientName()
        {
            return (from p in Food.Instance.Ingredients select p.IngredientName).ToArray();
        }
        public Object[] GetAllIngredient()
        {
            return (from p in Food.Instance.Ingredients select p).ToArray();
        }
        public int GetIngredientID(string name)
        {
            foreach (Ingredient i in GetAllIngredient())
                if (i.IngredientName == name)
                    return i.IngredientID;
            return 0;
        }
    }
}

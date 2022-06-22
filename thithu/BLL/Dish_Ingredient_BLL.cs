using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thithu.Models;
using thithu.DTO;

namespace thithu.BLL
{
    public class Dish_Ingredient_BLL
    {
        public static Dish_Ingredient_BLL _instance;
        public static Dish_Ingredient_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dish_Ingredient_BLL();
                }
                return _instance;
            }
            private set { }
        }

        public List<Dish_Ingredient> GetALLDS()
        {
            return (from p in Food.Instance.Dish_Ingredients select p).ToList();
        }

        public List<SP_View> GetAllSP_View(int DishID)
        {
            List<SP_View> a = new List<SP_View>();
            foreach(Dish_Ingredient DI in GetALLDS())
            {
                if(DI.DishID == DishID)
                {
                    a.Add(new SP_View
                    {
                        stt = a.Count+1,
                        IngredientName = DI.Ingredientes.IngredientName,
                        Amount = DI.Amount,
                        Unit = DI.Unit,
                        Tinhtrang = DI.Ingredientes.NhapKhau,
                    });
                }
            }
            return a;
        }

        public Dish_Ingredient GetD_IFromID(string id)
        {
            return Food.Instance.Dish_Ingredients.Find(id);
        }

        public Dish_Ingredient GetID(int DishID,int stt)
        {
            List<Dish_Ingredient> Ldi = new List<Dish_Ingredient>();
            foreach (Dish_Ingredient di in GetALLDS())
                if (di.DishID == DishID)
                {
                    stt--;
                    if (stt==0)
                        return di;
                }
            return null;
        }
        public Object[] GetAllUnit()
        {
            return (from p in Food.Instance.Dish_Ingredients select p.Unit).ToArray();
        }

        public void Add_DI(Dish_Ingredient a)
        {
            Dish_Ingredient di = new Dish_Ingredient();
            di = a;
            di.ID = (GetALLDS().Count + 1).ToString();
            Food.Instance.Dish_Ingredients.Add(di);
            Food.Instance.SaveChanges();
        }
        public void Edit_DI(Dish_Ingredient di)
        {
            Food.Instance.Dish_Ingredients.Find(di.ID).ID = di.ID;
            Food.Instance.Dish_Ingredients.Find(di.ID).IngredientID = di.IngredientID;
            Food.Instance.Dish_Ingredients.Find(di.ID).Unit = di.Unit;
            Food.Instance.Dish_Ingredients.Find(di.ID).DishID = di.DishID;
            Food.Instance.Dish_Ingredients.Find(di.ID).Amount = di.Amount;
            Food.Instance.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thithu.Models;

namespace thithu.BLL
{
    public class Dish_BLL
    {
        private static Dish_BLL _instance;
        public static Dish_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dish_BLL();
                }
                return _instance;
            }
            private set { }
        }

        public Object[] GetAllDish()
        {
            return (from p in Food.Instance.Dishes select p).ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT_catShop
{
    internal class Cat
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Energy { get; set; } = 100;
        public int Price { get; set; }
        public int MealQuantity { get; set; } = 100;

        public Cat(string nickname, int age, string gender, int price, int mealQuantity)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Energy = 100;
            Price = price;
            MealQuantity = 100;
        }
        public void Eat()
        {
            Energy += 10;
            Price += 5;
            MealQuantity -= 5;
            if (Energy > 100)
            {
                Energy = 100;
            }

            if (MealQuantity < 0)
            {
                MealQuantity = 0;
            }
        }
        public void Sleep()
        {
            Energy += 10;

            if (Energy > 100)
            {
                Energy = 100;
            }
        }
        public void Play()
        {
            Energy -= 10;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
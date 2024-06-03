using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT_catShop
{
    internal class CatHouse
    {
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; }

        public CatHouse(int size)
        {
            Cats = new Cat[size];
            CatCount = 0;
        }

        public void AddCat(Cat cat)
        {
            if (CatCount < Cats.Length)
            {
                Cats[CatCount] = cat;
                CatCount++;
            }
            else
            {
                Console.WriteLine("Cat House is full");
            }
        }

        public void RemoveByNickname(string nickname)
        {
            for (int i = 0; i < CatCount; i++)
            {
                if (Cats[i].Nickname == nickname)
                {
                    for (int j = i; j < CatCount - 1; j++)
                    {
                        Cats[j] = Cats[j + 1];
                    }

                    CatCount--;
                    Console.WriteLine($"{nickname} removed");
                    return;
                }
            }
            Console.WriteLine("This nickname not found");
        }
    }
}

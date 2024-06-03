using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT_catShop
{
    internal class PetShop
    {
        public CatHouse[] CatHouses { get; set; }
        public int CatHouseCount { get; set; }

        public PetShop(int size)
        {
            CatHouses = new CatHouse[size];
            CatHouseCount = 0;
        }

        public void AddCatHouse(CatHouse catHouse)
        {
            if (CatHouseCount < CatHouses.Length)
            {
                CatHouses[CatHouseCount] = catHouse;
                CatHouseCount++;
            }
            else
            {
                Console.WriteLine("Pet Shop is full");
            }
        }
    }
}


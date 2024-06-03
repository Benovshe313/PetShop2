namespace CAT_catShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetShop petShop = new PetShop(3);

            CatHouse ch1 = new CatHouse(2);
            CatHouse ch2 = new CatHouse(2);
            CatHouse ch3 = new CatHouse(2);

            petShop.AddCatHouse(ch1);
            petShop.AddCatHouse(ch2);
            petShop.AddCatHouse(ch3);

            ch1.AddCat(new Cat("Fluffy", 3, "female", 50, 10));
            ch1.AddCat(new Cat("Oskar", 2, "female", 50, 10));

            ch2.AddCat(new Cat("Whisker", 3, "male", 50, 10));
            ch2.AddCat(new Cat("Felix", 2, "male", 50, 10));

            ch3.AddCat(new Cat("Luna", 1, "female", 50, 10));
            ch3.AddCat(new Cat("Bella", 1, "female", 50, 10));

            Console.WriteLine("Welcome to Pet Shop!");

            bool exit = false;
            while (!exit)
            {
                for (int i = 0; i < petShop.CatHouseCount; i++)
                {
                    Console.WriteLine($"Cat house {i + 1}");
                }

                int optionHouse;
                Console.Write("Choose one of cat house: ");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out optionHouse) && optionHouse >= 1 && optionHouse <= petShop.CatHouseCount)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid input, make choice: ");
                    }
                }

                CatHouse chooseHouse = petShop.CatHouses[optionHouse - 1];
                for (int i = 0; i < chooseHouse.CatCount; i++)
                {
                    Cat cat = chooseHouse.Cats[i];
                    Console.WriteLine($"Cat {i + 1}: Nickname: {cat.Nickname}, Age: {cat.Age}, Gender: {cat.Gender}, Energy: {cat.Energy}, Price: {cat.Price}, Meal Quantity: {cat.MealQuantity}");
                }

                bool exitHouse = false;
                while (!exitHouse)
                {
                    Console.Write("Choose one of cats: ");

                    int optionCat;
                    while (!int.TryParse(Console.ReadLine(), out optionCat) || optionCat < 1 || optionCat > chooseHouse.CatCount)
                    {
                        Console.Write("Invalid input, make choice: ");
                    }

                    Cat chosenCat = chooseHouse.Cats[optionCat - 1];

                    bool exitoption = false;
                    while (!exitoption)
                    {
                        Console.WriteLine("1. Play");
                        Console.WriteLine("2. Eat");
                        Console.WriteLine("3. Sleep");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("5. Go back menu");
                        Console.Write("Make choice: ");

                        int option;
                        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
                        {
                            Console.Write("Invalid input, make choice: ");
                        }

                        switch (option)
                        {
                            case 1:
                                chosenCat.Play();
                                if (chosenCat.Energy <= 0)
                                {
                                    Console.WriteLine($"{chosenCat.Nickname} is sleeping .. ");
                                    chosenCat.Sleep();
                                    Console.WriteLine("Press any key ..");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                chosenCat.Eat();
                                break;
                            case 3:
                                chosenCat.Sleep();
                                break;
                            case 4:
                                exitoption = true;
                                exitHouse = true;
                                exit = true;
                                break;
                            case 5:
                                exitoption = true;
                                exitHouse = true;
                                Console.Clear();
                                break;
                        }

                        if (!exitoption)
                        {
                            Console.Clear();
                            Console.WriteLine($"Last info -> Nickname: {chosenCat.Nickname}, Energy: {chosenCat.Energy}, Price: {chosenCat.Price}, Meal Quantity: {chosenCat.MealQuantity}");

                        }
                    }
                }
            }
            int totalMealEat = 0;
            int totalPrice = 0;
            int MealQuantity = 100;

            foreach (var catHouse in petShop.CatHouses)
            {
                foreach (var cat in catHouse.Cats)
                {
                    totalMealEat += (MealQuantity - cat.MealQuantity);
                    totalPrice += cat.Price;
                }
            }

            Console.WriteLine($"Total amount of meal eaten by all cats: {totalMealEat}");
            Console.WriteLine($"Total price of all cats: {totalPrice}");
        }
    }
}

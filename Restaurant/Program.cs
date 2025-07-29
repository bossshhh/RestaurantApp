using System.Linq;
using RestaurantApp;
using System;

namespace RestaurantApp
{
    public class Host
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Restaurant CLI App!");

            var menu = new Menu();
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Food");
                Console.WriteLine("2. Add Drink");
                Console.WriteLine("3. View Menu");
                Console.WriteLine("4. Edit Menu");
                Console.WriteLine("5. Remove Food");
                Console.WriteLine("6. Remove Drink");
                Console.WriteLine("7. Update Food");
                Console.WriteLine("8. Update Drink");
                Console.WriteLine("9. Exit");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var food = RestaurantInputHandler.PromptFoodInput();
                        food.DisplayInfo();
                        menu.AddFood(food);
                        break;

                    case "2":
                        var drink = RestaurantInputHandler.PromptDrinkInput();
                        drink.DisplayInfo();
                        menu.AddDrink(drink);
                        break;

                    case "3":
                        menu.DisplayAllItems();
                        break;

                    case "4":
                        menu.EditMenuItem();
                        break;

                    case "5":
                        Console.Write("Enter Food ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeFoodId))
                        {
                            if (menu.RemoveFood(removeFoodId))
                                Console.WriteLine("Food removed.");
                            else
                                Console.WriteLine("Food not found.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "6":
                        Console.Write("Enter Drink ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeDrinkId))
                        {
                            if (menu.RemoveDrink(removeDrinkId))
                                Console.WriteLine("Drink removed.");
                            else
                                Console.WriteLine("Drink not found.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "7":
                        Console.Write("Enter Food ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateFoodId))
                        {
                            var foodToUpdate = menu.GetFoods()?.FirstOrDefault(f => f.Id == updateFoodId && !f.IsDeleted);
                            if (foodToUpdate == null)
                            {
                                Console.WriteLine("Food not found.");
                                break;
                            }
                            Console.WriteLine("Enter new food details:");
                            var updatedFood = RestaurantInputHandler.PromptFoodInput(updateFoodId); // overload for updates
                            if (menu.UpdateFood(updatedFood))
                                Console.WriteLine("Food updated.");
                            else
                                Console.WriteLine("Food update failed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "8":
                        Console.Write("Enter Drink ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateDrinkId))
                        {
                            var drinkToUpdate = menu.GetDrinks()?.FirstOrDefault(d => d.Id == updateDrinkId && !d.IsDeleted);
                            if (drinkToUpdate == null)
                            {
                                Console.WriteLine("Drink not found.");
                                break;
                            }
                            Console.WriteLine("Enter new drink details:");
                            var updatedDrink = RestaurantInputHandler.PromptDrinkInput(updateDrinkId); // overload for updates
                            if (menu.UpdateDrink(updatedDrink))
                                Console.WriteLine("Drink updated.");
                            else
                                Console.WriteLine("Drink update failed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "9":
                        Console.WriteLine("Goodbye!");
                        return;
                }
            }

        }
    }
}
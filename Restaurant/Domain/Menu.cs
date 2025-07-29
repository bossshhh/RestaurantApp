using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    public class Menu
    {
        private List<Food> _foods = new();
        private List<Drink> _drinks = new();

        public void AddFood(Food food)
        {
            if (food == null) throw new ArgumentNullException(nameof(food));
            _foods.Add(food);
        }

        public void AddDrink(Drink drink)
        {
            if (drink == null) throw new ArgumentNullException(nameof(drink));
            _drinks.Add(drink);
        }

        public bool RemoveFood(int id)
        {
            var food = _foods.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            if (food != null)
            {
                _foods.Remove(food);
                return true;
            }
            return false;
        }

        public bool RemoveDrink(int id)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
            if (drink != null)
            {
                _drinks.Remove(drink);
                return true;
            }
            return false;
        }

        public bool UpdateFood(Food updatedFood)
        {
            if (updatedFood == null) throw new ArgumentNullException(nameof(updatedFood));
            var food = _foods.FirstOrDefault(f => f.Id == updatedFood.Id && !f.IsDeleted);
            if (food != null)
            {
                food.Name = updatedFood.Name;
                food.Price = updatedFood.Price;
                food.Category = updatedFood.Category;
                food.IsAvailable = updatedFood.IsAvailable;
                return true;
            }
            return false;
        }

        public bool UpdateDrink(Drink updatedDrink)
        {
            if (updatedDrink == null) throw new ArgumentNullException(nameof(updatedDrink));
            var drink = _drinks.FirstOrDefault(d => d.Id == updatedDrink.Id && !d.IsDeleted);
            if (drink != null)
            {
                drink.Name = updatedDrink.Name;
                drink.Price = updatedDrink.Price;
                drink.Category = updatedDrink.Category;
                drink.IsAvailable = updatedDrink.IsAvailable;
                return true;
            }
            return false;
        }

        public void DisplayAllItems()
        {
            Console.WriteLine("\n Foods:");
            var visibleFoods = _foods
                .Where(f => !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToList();
            if (visibleFoods.Count == 0)
                Console.WriteLine("No foods available.");
            else
                visibleFoods.ForEach(f => f.DisplayInfo());

            Console.WriteLine("\n Drinks:");
            var visibleDrinks = _drinks
                .Where(d => !d.IsDeleted)
                .OrderBy(d => d.Name)
                .ToList();

            if (visibleDrinks.Count == 0)
                Console.WriteLine("No drinks available.");
            else
                visibleDrinks.ForEach(d => d.DisplayInfo());
        }

        public void EditMenuItem()
        {
            Console.WriteLine("\n--- Edit Menu ---");
            Console.WriteLine("Choose what to edit:");
            Console.WriteLine("1. Edit Food");
            Console.WriteLine("2. Edit Drink");
            Console.Write("Choice: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Write("Enter Food ID to edit: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var food = _foods.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
                    if (food == null)
                    {
                        Console.WriteLine($"No food found with ID {id}.");
                        return;
                    }

                    EditFoodItem(food);
                }
            }
            else if (input == "2")
            {
                Console.Write("Enter Drink ID to edit: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var drink = _drinks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
                    if (drink == null)
                    {
                        Console.WriteLine($"No drink found with ID {id}.");
                        return;
                    }

                    EditDrinkItem(drink);
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        private void EditFoodItem(Food food)
        {
            Console.WriteLine($"Editing: {food.Name}");

            Console.Write("New Name (leave blank to keep): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) food.Name = name;

            Console.Write("New Price (leave blank to keep): ");
            string priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out decimal newPrice)) food.Price = (double)newPrice;

            Console.Write("New Category (leave blank to keep): ");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) food.Category = category;

            Console.Write("Is Available? (true/false or leave blank): ");
            string availableInput = Console.ReadLine();
            if (bool.TryParse(availableInput, out bool available)) food.IsAvailable = available;

            Console.WriteLine("Food item updated.");
        }

        private void EditDrinkItem(Drink drink)
        {
            Console.WriteLine($"Editing: {drink.Name}");

            Console.Write("New Name (leave blank to keep): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) drink.Name = name;

            Console.Write("New Price (leave blank to keep): ");
            string priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out decimal newPrice)) drink.Price = (double)newPrice;

            Console.Write("New Category (leave blank to keep): ");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) drink.Category = category;

            Console.Write("Is Available? (true/false or leave blank): ");
            string availableInput = Console.ReadLine();
            if (bool.TryParse(availableInput, out bool available)) drink.IsAvailable = available;

            Console.WriteLine("Drink item updated.");
        }

        public List<Food> GetFoods()
        {
            return _foods;
        }

        public List<Drink> GetDrinks()
        {
            return _drinks;
        }
    }
}

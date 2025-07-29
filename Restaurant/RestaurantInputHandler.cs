using System;

namespace RestaurantApp
{
    public static class RestaurantInputHandler
    {
        public static Food PromptFoodInput()
        {
            Console.WriteLine("Enter Food ID:");
            int id = int.Parse(Console.ReadLine());
            return PromptFoodInput(id);
        }

        public static Food PromptFoodInput(int id)
        {
            var input = PromptSharedItemInput("Food");
            return new Food(id, input.Name, input.Price, input.Category, input.IsDeleted, input.IsAvailable);
        }

        public static Drink PromptDrinkInput()
        {
            Console.WriteLine("Enter Drink ID:");
            int id = int.Parse(Console.ReadLine());
            return PromptDrinkInput(id);
        }

        public static Drink PromptDrinkInput(int id)
        {
            var input = PromptSharedItemInput("Drink");
            return new Drink(id, input.Name, input.Price, input.Category, input.IsDeleted, input.IsAvailable);
        }

        private static SharedItemData PromptSharedItemInput(string itemType)
        {
            Console.WriteLine($"Enter {itemType} name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter category:");
            string category = Console.ReadLine();

            Console.WriteLine($"Is the {itemType.ToLower()} available? (true/false):");
            bool isAvailable = bool.Parse(Console.ReadLine());

            Console.WriteLine($"Is the {itemType.ToLower()} deleted? (true/false):");
            bool isDeleted = bool.Parse(Console.ReadLine());

            return new SharedItemData
            {
                Name = name,
                Price = price,
                Category = category,
                IsAvailable = isAvailable,
                IsDeleted = isDeleted
            };
        }

        private class SharedItemData
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
            public bool IsAvailable { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}

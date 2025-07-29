using System;
using RestaurantApp.Shared;

namespace RestaurantApp
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public Food(int id, string name, decimal price, string category, bool isDeleted, bool available)
            : base(id, isDeleted, available)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentOutOfRangeException(nameof(name), "Name is required.");

            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be positive.");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentOutOfRangeException(nameof(category), "Category is required.");

            Name = name;
            Price = (double)price;
            Category = category;
        }

        public virtual string DisplayInfo()
        {
            Console.WriteLine($"\n{Id}. {Name} ({Category})");
            Console.WriteLine($"   Price: ${Price}");
            Console.WriteLine($"   Available: {(IsAvailable ? "Yes" : "No")}");
            return "menu";
        }

        public void Update(FoodDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Price = (double)dto.Price;
            Category = dto.Category;
            IsAvailable = dto.Available;
        }
    }
}

using System;
using RestaurantApp.Shared;

namespace RestaurantApp
{
    public class Drink : Food
    {
        public Drink(int id, string? name, decimal price, string category, bool isDeleted, bool available)
            : base(id, name!, price, category, isDeleted, available)
        {
        }

        public override string DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("   Type: Drink");
            return "menu";
        }

        public void Update(DrinkDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Price = (double)dto.Price;
            Category = dto.Category;
            IsAvailable = dto.Available;
        }
    }
}

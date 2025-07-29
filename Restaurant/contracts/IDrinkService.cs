using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp
{
    public interface IDrinkService
    {
        void AddDrink(DrinkDto drinkDto);
        DrinkDto GetById(int id);
        ICollection<DrinkDto> GetAllDrinks();
        void UpdateDrink(DrinkDto drinkDto);
        void RemoveDrink(int id);
    }
}
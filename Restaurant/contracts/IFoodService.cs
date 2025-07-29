using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp
{
/// <summary>
/// this class is for the interface to show what FoodService show
/// </summary>
   public interface IFoodService
{
    void AddFood(FoodDto foodDto);
    FoodDto GetById(int id);
    ICollection<FoodDto> GetAllFoods();
    void UpdateFood(FoodDto foodDto);
    void RemoveFood(int id);
}
}
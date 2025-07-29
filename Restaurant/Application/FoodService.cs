using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RestaurantApp
{
    public class FoodService : IFoodService
    {
        /// <summary>
        /// A collection to store food items.
        /// This is a simple in-memory storage for demonstration purposes.
        /// </summary>
        private readonly List<Food> _foods = new();

        /// <summary>
        /// This method is for adding a new food item based on user input.
        /// </summary>
        /// <param name="foodDto"></param>
        public void AddFood(FoodDto foodDto)
        {
            var food = new Food(
                foodDto.Id,
                foodDto.Name,
                foodDto.Price,
                foodDto.Category,
                false,
                foodDto.Available
            );
            _foods.Add(food);
        }

        public FoodDto GetFoodById(int id)
        {
            var food = _foods.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            if (food == null)
            { throw new KeyNotFoundException($"No food found with ID {id}."); }

            return new FoodDto
            {
                Id = food.Id,
                Name = food.Name,
            };
        }

        /// <summary>
        /// used for returning collections
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FoodDto> GetAllFoods()
        {
            return _foods
            .Where(f => !f.IsDeleted)
            .Select(f => new FoodDto
            {
                Id = f.Id,
                Name = f.Name,
                Price = (decimal)f.Price,
                Category = f.Category,
                Available = f.IsAvailable,
            });
        }


        public void UpdateFood(FoodDto foodDto)
        {
            var food = _foods.FirstOrDefault(f => f.Id == foodDto.Id && !f.IsDeleted);
            if (food == null)
            { throw new KeyNotFoundException($"Food with ID {foodDto.Id} not found."); }
            food.Update(foodDto);
        }

        /// <summary>
        /// this is Hard Delete not soft this is because im using List<Food>
        /// if i didnt use List<T> i could have dont soft delete which is (_available = false;)
        /// </summary>
        /// <param name="id"></param>
        public bool RemoveFood(int id)
        {
            var food = _foods.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            if (food != null)
            {
                food.IsDeleted = true; // ← Soft delete!
                return true;
            }
            return false;
        }


        ICollection<FoodDto> IFoodService.GetAllFoods()
        {
            throw new NotImplementedException();
        }

        public FoodDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IFoodService.RemoveFood(int id)
        {
            throw new NotImplementedException();
        }
    }
}

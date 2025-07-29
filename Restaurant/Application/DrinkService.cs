using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantApp;

namespace RestaurantApp

{
    public class DrinkService : IDrinkService
    {
        private readonly List<Drink> _drinks = new();

        /// <summary>
        /// This method is for adding a new drink item based on user input.
        /// </summary>
        /// <param name="drinkDto"></param>
        public void AddDrink(DrinkDto drinkDto)
        {
            var drink = new Drink(
                drinkDto.Id,
                drinkDto.Name,
                drinkDto.Price,
                drinkDto.Category,
                false,
                drinkDto.Available
            );
            _drinks.Add(drink);
        }

        public DrinkDto GetDrinkById(int id)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
            if (drink == null)
            { throw new KeyNotFoundException($"No drink found with ID {id}."); }

            return new DrinkDto
            {
                Id = drink.Id,
                Name = drink.Name,
            };
        }

        /// <summary>
        /// Used for returning collections of drinks.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrinkDto> GetAllDrinks()
        {
            return _drinks
            .Where(d => !d.IsDeleted)
            .Select(d => new DrinkDto
            {
                Id = d.Id,
                Name = d.Name,
                Price = (decimal)d.Price,
                Category = d.Category,
                Available = d.IsAvailable,
            });
        }

        public void UpdateDrink(DrinkDto drinkDto)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkDto.Id && !d.IsDeleted);
            if (drink == null)
            { throw new KeyNotFoundException($"Drink with ID {drinkDto.Id} not found."); }

            drink.Update(drinkDto);
        }

        /// <summary>
        /// This is a hard delete because List<Drink> is being used.
        /// If you used a different structure, you could soft delete (e.g. _available = false).
        /// </summary>
        /// <param name="id"></param>
        public bool RemoveDrink(int id)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
            if (drink != null)
            {
                drink.IsDeleted = true;
                return true;
            }
            return false;
        }


        ICollection<DrinkDto> IDrinkService.GetAllDrinks()
        {
            throw new NotImplementedException();
        }

        public DrinkDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        void IDrinkService.RemoveDrink(int id)
        {
            throw new NotImplementedException();
        }
    }
}
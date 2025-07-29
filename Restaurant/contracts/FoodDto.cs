using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

///Dto's are needed before the service layer can use them
namespace RestaurantApp
{
    /// <summary>
    /// food dto is just like food.cs but wihout the remove function.
    /// </summary>
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }

    }
}
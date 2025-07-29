using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Shared
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }

        protected BaseEntity(int id, bool isDeleted, bool isAvailable)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");

            Id = id;
            IsDeleted = isDeleted;
            IsAvailable = isAvailable;
        }
    }
}

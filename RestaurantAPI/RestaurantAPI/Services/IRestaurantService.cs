using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDTO dto);
        IEnumerable<RestaurantDTO> GetAll();
        RestaurantDTO GetById(int id);
        bool Delete(int id);
    }
}
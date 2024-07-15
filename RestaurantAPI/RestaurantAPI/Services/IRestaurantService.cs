using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDTO dto);
        IEnumerable<RestaurantDTO> GetAll();
        RestaurantDTO GetById(int id);
        void Delete(int id);
        void Modify(int id, UpdateRestaurantDTO dto);
    }
}
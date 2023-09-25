using GoodVibe.Models.PropertyModels;
using Microsoft.AspNetCore.Mvc;

namespace GoodVibe.Repositories
{
    public interface IProperties
    {
        Task<List<PropertyView>?> GetAllProperty();
        Task<List<PropertyView>?> GetById(int id);
        //Task<List<PropertyView>?> GetByCity(string city);
        Task<List<PropertyView>> FilterCity(List<string> cities);
        Task<List<PropertyView>?> GetByState(string state);
        Task<List<PropertyView>?> GetByPinCode(int pinCode);
        Task<List<PropertyAdd>?> AddProperty([FromBody] PropertyAdd propertyAdd);
        Task<List<PropertyUpdate>?> UpdateProperty([FromBody] PropertyUpdate propertyUpdate);
    }
}

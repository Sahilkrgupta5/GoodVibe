using GoodVibe.Data;
using GoodVibe.Models;
using GoodVibe.Models.PropertyModels;
using GoodVibe.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodVibe.Repositories
{
    public class Properties : IProperties
    {
        private readonly AppDbContext _db;
        public Properties(AppDbContext db)
        {
            _db = db;
        }
        private PropertyView MapPropertyToPropertyView(Property property)
        {
            PropertyView propertyView = new PropertyView
            {
                HouseNo = property.HouseNo,
                Area = property.Area,
                City = property.City,
                State = property.State,
                PinCode = property.PinCode,
                Sqft = property.Sqft,
                Price = property.Price,
                Details = property.Details,
                ImageUrl = property.ImageUrl,
            };
            return propertyView;
        }
        public async Task<List<PropertyView>?> GetAllProperty()
        {
            List<Property> properties = await _db.Properties.ToListAsync();

            if (properties != null)
            {
                List<PropertyView> propertyViews = properties.Select(property => MapPropertyToPropertyView(property)).ToList();
                return propertyViews;
            }

            return null;
        }

        public async Task<List<PropertyView>?> GetById(int id)
        {
            List<Property> properties = await _db.Properties.Where(properties => properties.Id == id).ToListAsync();
            
            if(properties != null)
            {
                List<PropertyView> propertyViews = properties.Select(property => MapPropertyToPropertyView(property)).ToList();
                return propertyViews;
            }
            return null;
        }
        public async Task<List<PropertyView>?> GetByCity(string city)
        {
            List<Property> properties = await _db.Properties.Where(property => property.City.ToLower() == city.ToLower()).ToListAsync();

            if (properties != null)
            {
                List<PropertyView> propertyViews = properties.Select(property => MapPropertyToPropertyView(property)).ToList();
                return propertyViews;
            }
            return null;
        }
        public async Task<List<PropertyView>?> GetByState(string state)
        {
            List<Property> properties = await _db.Properties.Where(property => property.State.ToLower() == state.ToLower()).ToListAsync();

            if (properties != null)
            {
                List<PropertyView> propertyViews = properties.Select(property => MapPropertyToPropertyView(property)).ToList();
                return propertyViews;
            }
            return null;
        }

        public async Task<List<PropertyView>?> GetByPinCode(int pinCode)
        {
            List<Property> properties = await _db.Properties.Where(properties => properties.PinCode == pinCode).ToListAsync();

            if (properties != null)
            {
                List<PropertyView> propertyViews = properties.Select(property => MapPropertyToPropertyView(property)).ToList();
                return propertyViews;
            }
            return null;
        }
        public async Task<List<PropertyAdd>?> AddProperty([FromBody] PropertyAdd propertyAdd)
        {
            Property model = new()
            {
                HouseNo = propertyAdd.HouseNo,
                Area = propertyAdd.Area,
                City = propertyAdd.City,
                State = propertyAdd.State,
                PinCode = propertyAdd.PinCode,
                Sqft = propertyAdd.Sqft,
                Price = propertyAdd.Price,
                Details = propertyAdd.Details,
                ImageUrl = propertyAdd.ImageUrl
            };
            List<Property> properties = await _db.Properties.ToListAsync();
            _db.Properties.Add(model);
            await _db.SaveChangesAsync();
            return null;
        }

        public async Task<List<PropertyUpdate>?> UpdateProperty([FromBody] PropertyUpdate propertyUpdate)
        {
            Property existingProperty = await _db.Properties.FindAsync(propertyUpdate.Id);

            if (existingProperty == null)
            {
                return null;
            }

            existingProperty.HouseNo = propertyUpdate.HouseNo;
            existingProperty.Area = propertyUpdate.Area;
            existingProperty.City = propertyUpdate.City;
            existingProperty.State = propertyUpdate.State;
            existingProperty.PinCode = propertyUpdate.PinCode;
            existingProperty.Sqft = propertyUpdate.Sqft;
            existingProperty.Price = propertyUpdate.Price;
            existingProperty.Details = propertyUpdate.Details;
            existingProperty.ImageUrl = propertyUpdate.ImageUrl;


            _db.Properties.Update(existingProperty);
            await _db.SaveChangesAsync();

            return null;
        }

        //public Task<List<PropertyView>?> GetAllProperty()
        //{
        //    return _db.Properties.OrderByDescending(u => u.Id).ToListAsync();
        //}
    }
}

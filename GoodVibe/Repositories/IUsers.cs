using GoodVibe.Models.PropertyModels;
using GoodVibe.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace GoodVibe.Repositories
{
    public interface IUsers
    {
        Task<List<UserView>?> GetAllUsers();
        Task<List<UserView>?> GetById(int id);
        Task<List<UserAdd>?> AddUser([FromBody] UserAdd userAdd);
        Task<List<UserUpdate>?> UpdateUser([FromBody] UserUpdate userUpdate);
    }
}

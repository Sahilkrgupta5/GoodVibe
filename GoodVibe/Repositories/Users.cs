using GoodVibe.Data;
using GoodVibe.Models;
using GoodVibe.Models.PropertyModels;
using GoodVibe.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodVibe.Repositories
{
    public class Users : IUsers
    {
        private readonly AppDbContext _db;
        public Users(AppDbContext db)
        {
            _db = db;
        }
        private UserView MapUserToUserView(User user)
        {
            UserView userView = new UserView
            {
                Name = user.Name,
                EmailId = user.EmailId,
                Role = user.Role,
            };
            return userView;
        }
        public async Task<List<UserView>?> GetAllUsers()
        {
            List<User> users = await _db.Users.ToListAsync();

            if(users != null)
            {
                List<UserView> userView = users.Select(user => MapUserToUserView(user)).ToList();
                return userView;
            }
            return null;
        }
        public async Task<List<UserView>?> GetById(int id)
        {
            List<User> users = await _db.Users.Where(users => users.Id == id).ToListAsync();

            if (users != null)
            {
                List<UserView> userView = users.Select(user => MapUserToUserView(user)).ToList();
                return userView;
            }
            return null;
        }
        public async Task<List<UserAdd>?> AddUser([FromBody] UserAdd userAdd)
        {
            User model = new()
            {
                Name = userAdd.Name,
                EmailId = userAdd.EmailId,
                Password = userAdd.Password,
                Role = userAdd.Role,
            };
            List<User> users = await _db.Users.ToListAsync();
            _db.Users.Add(model);
            await _db.SaveChangesAsync();
            return null;
        }

        public async Task<List<UserUpdate>?> UpdateUser([FromBody] UserUpdate userUpdate)
        {
            User existingUser = await _db.Users.FindAsync(userUpdate.Id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = userUpdate.Name;
            existingUser.EmailId = userUpdate.EmailId;
            existingUser.Password = userUpdate.Password;
            existingUser.Role = userUpdate.Role;

            _db.Users.Update(existingUser);
            await _db.SaveChangesAsync();

            return null;
        }

    }
}

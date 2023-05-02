using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;

namespace SWH.Controllers;

public class UserController : IUser
{
    private readonly DbContext _context = new();

    public async void AddUser(User user)
    {
        try
        {
            await _context.UserRecord.InsertOneAsync(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        try
        {
            var users = _context.UserRecord.Find(FilterDefinition<User>.Empty).ToListAsync();
            return await users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }

    //get user by username
    public User GetUser(string userName)
    {
        try
        {
            var user = _context.UserRecord.Find(x => x.UserName == userName).FirstOrDefault();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void UpdateUser(User user)
    {
        try
        {
            await _context.UserRecord.ReplaceOneAsync(x => x.Id == user.Id, user);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteUser(string userId)
    {
        try
        {
            _context.UserRecord.DeleteOne(x => x.Id == userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
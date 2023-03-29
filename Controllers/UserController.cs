using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;

namespace SWH.Controllers;

public class UserController : IUser
{
    DbContext context = new DbContext();

    public UserController()
    {
    }

    public async void AddUser(User user)
    {
        try
        {
            await context.UserRecord.InsertOneAsync(user);
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
            var users = context.UserRecord.Find(FilterDefinition<User>.Empty).ToListAsync();
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
            var User = context.UserRecord.Find(x => x.UserName == userName).FirstOrDefault();
            return User;
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
            await context.UserRecord.ReplaceOneAsync(x => x.id == user.id, user);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteUser(string userID)
    {
        try
        {
            context.UserRecord.DeleteOne(x => x.id == userID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
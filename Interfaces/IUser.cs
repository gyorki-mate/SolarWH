using SWH.Models;

namespace SWH.Interfaces;

public interface IUser
{
    public Task<List<User>> GetAllUsers();
    public User GetUser(string userName);
    public void AddUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(string userID);
}

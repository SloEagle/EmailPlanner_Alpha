namespace EmailPlanner_Alpha.Client.Services.UserService
{
    public interface IUserService
    {
        List<User> Users { get; set; }
        User User { get; set; }
        Task GetUsers();
        Task GetUserById(int id);
        Task UpdateUser(User user);
        Task AddUser(User user);
        Task DeleteUser(int id);
    }
}

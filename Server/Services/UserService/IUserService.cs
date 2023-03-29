using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetUsers();
        Task<ServiceResponse<User>> GetUserById(int id);
        Task<ServiceResponse<List<User>>> UpdateUser(User user);
        Task<ServiceResponse<List<User>>> AddUser(User user);
        Task<ServiceResponse<List<User>>> DeleteUser(int id);

        string GetMyName();
    }
}

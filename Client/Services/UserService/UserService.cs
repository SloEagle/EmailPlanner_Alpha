using System.Net.Http.Json;

namespace EmailPlanner_Alpha.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public List<User> Users { get; set; } = new List<User>();
        public User User { get; set; } = new User();

        public async Task AddUser(User user)
        {
            await _http.PutAsJsonAsync("api/user", user);
        }

        public async Task DeleteUser(int id)
        {
            await _http.DeleteAsync($"api/user/{id}");
        }

        public async Task GetUserById(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<User>>($"api/user/{id}");
            User = response.Data;
        }

        public async Task GetUsers()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<User>>>("api/user");
            Users = response.Data;
        }

        public async Task UpdateUser(User user)
        {
            await _http.PostAsJsonAsync("api/user", user);
        }
    }
}

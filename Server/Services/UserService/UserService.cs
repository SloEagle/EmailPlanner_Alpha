using EmailPlanner_Alpha.Shared;

namespace EmailPlanner_Alpha.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<User>>> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new ServiceResponse<List<User>> { Success = true };
        }

        public async Task<ServiceResponse<List<User>>> DeleteUser(int id)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (dbUser == null)
            {
                return new ServiceResponse<List<User>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            else
            {

                dbUser.Deleted = true;
                await _context.SaveChangesAsync();
                return new ServiceResponse<List<User>> { Success = true };
            }
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User?.Identity?.Name;
            }

            return result;
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            var dbUser = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
            if(dbUser == null)
            {
                return new ServiceResponse<User>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            else
            {
                return new ServiceResponse<User> 
                { 
                    Data = dbUser,
                    Success = true
                };
            }
        }

        public async Task<ServiceResponse<List<User>>> GetUsers()
        {
            var result = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Role)
                .Where(u => u.Deleted == false)
                .ToListAsync();
            return new ServiceResponse<List<User>>
            {
                Data = result,
                Success = true
            };
        }

        public async Task<ServiceResponse<List<User>>> UpdateUser(User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if(dbUser == null)
            {
                return new ServiceResponse<List<User>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            else
            {
                dbUser.Email = user.Email;
                dbUser.Name = user.Name;
                dbUser.PasswordHash = user.PasswordHash;
                dbUser.Role = user.Role;
                dbUser.Company = user.Company;
                dbUser.Deleted = user.Deleted;
                dbUser.Visible = user.Visible;
                await _context.SaveChangesAsync();
                return new ServiceResponse<List<User>> { Success = true };
            }
        }
    }
}

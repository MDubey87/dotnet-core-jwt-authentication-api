using JwtAuthentication.Services.Models;
using JWTAuthentication.TokenManager;

namespace JwtAuthentication.Services
{
    public interface IUserService
    {
        AuthenticateResponse? Authenticate(AuthenticateRequest model);
        IEnumerable<UserAccount> GetAll();
    }
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserAccount> _users = new List<UserAccount>
        {
            new UserAccount { FirstName = "Test", LastName = "User", UserName = "user01", Password = "user01" },
            new UserAccount { FirstName = "Test1", LastName = "User", UserName = "user02", Password = "user02" }
        };
        private readonly JWTTokenManager _jwtTokenManager;
        public UserService(JWTTokenManager jwtTokenManager)
        {
            _jwtTokenManager = jwtTokenManager;
        }
        public AuthenticateResponse? Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = _jwtTokenManager.GenerateJwtToken(user.UserName);

            return new AuthenticateResponse { Token = token, Username = user.UserName };
        }
        public IEnumerable<UserAccount> GetAll()
        {
            return _users;
        }

    }
}

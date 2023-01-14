using Microsoft.IdentityModel.Tokens;
using PaymentBackend.Models;
using PaymentBackend.Repositories.Interfaces;
using PaymentBackend.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaymentBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }
        public User CheckUserLoginCredentials(string email, string password)
        {
            foreach (User user in _userRepository.GetAll())
            {
                if (user.Email.Equals(email) && user.Password.Equals(password))
                {
                    return _userRepository.GetById(user.Id);
                }
            }

            return null;
        }
        public string GenerateJwt(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aaabbbcccaaabbbc")), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
        public void UpdateBudget(string email, int budget)
        {
            User user = _userRepository.GetByEmail(email);
            user.Budget += budget;
            _userRepository.Update(user);
        }
        public void UpdateBudget(int id, int budget, bool isAddition)
        {
            User user = _userRepository.GetById(id);
            if (!isAddition)
                user.Budget -= budget;
            else
                user.Budget += budget;
            _userRepository.Update(user);
        }
    }
}

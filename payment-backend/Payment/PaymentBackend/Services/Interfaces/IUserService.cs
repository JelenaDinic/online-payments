using PaymentBackend.Models;

namespace PaymentBackend.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User CheckUserLoginCredentials(string email, string password);
        string GenerateJwt(User user);
        void UpdateBudget(string email, int budget);
        void UpdateBudget(int id, int budget, bool isAddition);
    }
}

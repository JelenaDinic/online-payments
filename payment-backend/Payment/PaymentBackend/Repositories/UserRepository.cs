using Microsoft.EntityFrameworkCore;
using PaymentBackend.Models;
using PaymentBackend.Repositories.Interfaces;
using PaymentBackend.Settings;

namespace PaymentBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PaymentDbContext _context;

        public UserRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(user => user.Email == email);
        }
    }
}

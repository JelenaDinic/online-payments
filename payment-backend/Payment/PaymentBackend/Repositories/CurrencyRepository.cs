using Microsoft.EntityFrameworkCore;
using PaymentBackend.Models;
using PaymentBackend.Repositories.Interfaces;
using PaymentBackend.Settings;

namespace PaymentBackend.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly PaymentDbContext _context;

        public CurrencyRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _context.Currencies.ToList();
        }

        public Currency GetById(string id)
        {
            return _context.Currencies.Find(id);
        }
        public void Create(Currency currency)
        {
            _context.Currencies.Add(currency);
            _context.SaveChanges();
        }

        public void Update(Currency currency)
        {
            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Currency currency)
        {
            _context.Currencies.Remove(currency);
            _context.SaveChanges();
        }
    }
}

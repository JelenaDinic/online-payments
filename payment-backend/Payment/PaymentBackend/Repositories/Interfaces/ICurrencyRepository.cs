using PaymentBackend.Models;

namespace PaymentBackend.Repositories.Interfaces
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAll();
        Currency GetById(string id);
        void Create(Currency currency);
        void Update(Currency currency);
        void Delete(Currency currency);
    }
}

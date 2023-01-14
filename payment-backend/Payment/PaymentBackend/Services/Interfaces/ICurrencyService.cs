using PaymentBackend.Models;

namespace PaymentBackend.Services.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetAll();
        Currency GetById(string id);
        void Create(Currency currency);
        void Update(Currency currency);
        void Delete(Currency currency);
    }
}

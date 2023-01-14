using PaymentBackend.Models;
using PaymentBackend.Repositories.Interfaces;
using PaymentBackend.Services.Interfaces;

namespace PaymentBackend.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository userRepository)
        {
            _currencyRepository = userRepository;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _currencyRepository.GetAll();
        }

        public Currency GetById(string id)
        {
            return _currencyRepository.GetById(id);
        }
        public void Create(Currency currency)
        {
            _currencyRepository.Create(currency);
        }

        public void Update(Currency currency)
        {
            _currencyRepository.Update(currency);
        }

        public void Delete(Currency currency)
        {
            _currencyRepository.Delete(currency);
        }
    }
}

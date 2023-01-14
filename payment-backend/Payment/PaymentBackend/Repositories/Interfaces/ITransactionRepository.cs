using PaymentBackend.Models;

namespace PaymentBackend.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAll();
        Transaction GetById(int id);
        void Create(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction transaction);
    }
}

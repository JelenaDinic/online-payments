using PaymentBackend.Models;

namespace PaymentBackend.Services.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetAllByUser(int id);
        Transaction GetById(int id);
        void Create(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction transaction);
    }
}

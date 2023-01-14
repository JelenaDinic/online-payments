using PaymentBackend.Models;
using PaymentBackend.Repositories.Interfaces;
using PaymentBackend.Services.Interfaces;

namespace PaymentBackend.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Transaction> GetAllByUser(int id)
        {
            List<Transaction>  allTransactions = _transactionRepository.GetAll();
            List<Transaction> transactions  = new List<Transaction>();
            foreach (Transaction transaction in allTransactions)
            {
                if (transaction.User == id)
                    transactions.Add(transaction);
                    
            }
            return transactions;
        }

        public Transaction GetById(int id)
        {
            return _transactionRepository.GetById(id);
        }
        public void Create(Transaction transaction)
        {
            _transactionRepository.Create(transaction);
        }

        public void Update(Transaction transaction)
        {
            _transactionRepository.Update(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _transactionRepository.Delete(transaction);
        }
    }
}

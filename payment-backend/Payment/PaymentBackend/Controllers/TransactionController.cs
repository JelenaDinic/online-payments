using Microsoft.AspNetCore.Mvc;
using PaymentBackend.DTO;
using PaymentBackend.Models;
using PaymentBackend.Services.Interfaces;

namespace PaymentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public TransactionController(ITransactionService transactionService, IUserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
        }
        [HttpGet("{id}")]
        public ActionResult GetAllByUser(int id)
        {
            return Ok(_transactionService.GetAllByUser(id));
        }
        [HttpPost]
        public ActionResult AddTransaction(TransactionDTO transactionDTO)
        {
            Transaction transaction = new Transaction();
            transaction.Amount = transactionDTO.Amount;
            transaction.RecipientEmail = transactionDTO.RecipientEmail;
            transaction.DateTime = DateTime.UtcNow;
            transaction.User = transactionDTO.UserId;
            if(transactionDTO.RecipientEmail.Equals("own")) {
                _userService.UpdateBudget(transactionDTO.UserId, transactionDTO.Amount, true);
            } else
            {
                _userService.UpdateBudget(transactionDTO.RecipientEmail, transactionDTO.Amount);
                _userService.UpdateBudget(transactionDTO.UserId, transactionDTO.Amount, false);
            }
            
            _transactionService.Create(transaction);

            return Ok(transaction);
        }


    }
}

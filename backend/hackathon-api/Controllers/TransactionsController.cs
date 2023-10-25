using hackathon_api.Models.DTOs;
using hackathon_api.Repositories.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace hackathon_api.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionsRepository _transactionsRepository;
        public TransactionsController(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        [Route("/hackathon/api/Data/deposit")]
        [HttpPost]
        public async Task<IActionResult> AddDepositAsync(TransactionDTO transactionDTO)
        {
            transactionDTO.TransactionType = Models.TypeOfTransaction.Deposit;
            await _transactionsRepository.AddTransactionAsync(transactionDTO);
            return Ok();
        }

        [Route("/hackathon/api/Data/withdraw")]
        [HttpPost]
        public async Task<IActionResult> AddWithdrawalAsync(TransactionDTO transactionDTO)
        {
            transactionDTO.TransactionType = Models.TypeOfTransaction.Withdrawal;
            await _transactionsRepository.AddTransactionAsync(transactionDTO);
            return Ok();
        }
    }
}

using hackathon_api.Models.DTOs;

namespace hackathon_api.Repositories.Transactions;

public interface ITransactionsRepository
{
    public Task<bool> AddTransactionAsync(TransactionDTO transactionDTO);
}

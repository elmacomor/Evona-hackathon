using hackathon_api.Models;
using hackathon_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using hackathon_api.Data;

namespace hackathon_api.Repositories.Transactions;
public class TransactionsRepository : ITransactionsRepository
{
    private readonly DBMainContext _dbContext;
    public TransactionsRepository(DBMainContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> AddTransactionAsync(TransactionDTO transactionDTO)
    {
        var transaction = new Transaction();
        transaction.TransactionDate = DateTime.Now;
        transaction.UserId = transactionDTO.Player.Id;
        transaction.Amount = transactionDTO.Amount;
        transaction.Type = transactionDTO.TransactionType;
        await _dbContext.Transactions.AddAsync(transaction);

        var user = await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == transactionDTO.Player.Id);
        
        if (transactionDTO.TransactionType == TypeOfTransaction.Deposit) 
        {
            user.DepositAmount += transactionDTO.Amount;
            user.DepositCumulativeAmount += transactionDTO.Amount;
        }
        else
        {
            user.WithdrwalAmount += transactionDTO.Amount;
            user.WithdrawalCumulativeAmount += transactionDTO.Amount;
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }
}

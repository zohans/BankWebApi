using BankWebApplication.Data;
using BankWebApplication.Dto;
using BankWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        readonly BankContext _bankContext;

        public BankAccountController(BankContext BankContext)
        {
            _bankContext = BankContext;
        }

        [HttpGet]
        [Route("users/{userId}")]
        public async Task<IEnumerable<BankAccount>> GetUserBankAccounts(int userId)
        {
            var data = await _bankContext.BankAccounts.Where(b => b.UserId == userId).ToListAsync();
            return data;
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<IEnumerable<BankAccount>> DepositBankAccount([FromBody] BankAccountRequest bankAccountRequest)
        {
            var data = await (from b in _bankContext.Set<BankAccount>()
                        join u in _bankContext.Set<User>()
                            on b.UserId equals u.Id
                        where b.UserId == bankAccountRequest.UserId && b.Name == bankAccountRequest.AccountName
                        select b).ToListAsync();

            var account = data.FirstOrDefault();
            account.Balance += bankAccountRequest.Amount;

            await _bankContext.SaveChangesAsync();

            return data;
        }

        [HttpPost]
        [Route("withdraw")]
        public async Task<IEnumerable<BankAccount>> WithdrawBankAccount([FromBody] BankAccountRequest bankAccountRequest)
        {
            var data = await (from b in _bankContext.Set<BankAccount>()
                        join u in _bankContext.Set<User>()
                            on b.UserId equals u.Id
                        where b.UserId == bankAccountRequest.UserId && b.Name == bankAccountRequest.AccountName
                        select b).ToListAsync();

            var account = data.FirstOrDefault();

            if (account.Balance - bankAccountRequest.Amount < 0)
            {
                return null;
            }
            else
            {
                account.Balance -= bankAccountRequest.Amount;
            }

            await _bankContext.SaveChangesAsync();

            return data;
        }
    }
}

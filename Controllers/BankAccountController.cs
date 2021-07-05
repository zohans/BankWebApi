using BankWebApplication.Data;
using BankWebApplication.Dto;
using BankWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
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
        
        [Route("users/{userId}")]
        public IEnumerable<BankAccount> GetUserBankAccounts(int userId)
        {
            var data = _bankContext.BankAccounts.Where( b => b.UserId == userId).ToList();
            return data;
        }

        [Route("deposit")]
        public IEnumerable<BankAccount> DepositBankAccount([FromBody] BankAccountRequest bankAccountRequest)
        {
            var data = (from b in _bankContext.Set<BankAccount>()
                        join u in _bankContext.Set<User>()
                            on b.UserId equals u.Id
                        where b.UserId == bankAccountRequest.UserId && b.Name == bankAccountRequest.AccountName
                        select b ).ToList();

            var account = data.FirstOrDefault();
            account.Balance += bankAccountRequest.Amount;

            _bankContext.SaveChanges();

            return data;
        }


        [Route("withdraw")]
        public IEnumerable<BankAccount> WithdrawBankAccount([FromBody] BankAccountRequest bankAccountRequest)
        {
            var data = (from b in _bankContext.Set<BankAccount>()
                        join u in _bankContext.Set<User>()
                            on b.UserId equals u.Id
                        where b.UserId == bankAccountRequest.UserId && b.Name == bankAccountRequest.AccountName
                        select b).ToList();

            var account = data.FirstOrDefault();

            if (account.Balance - bankAccountRequest.Amount < 0)
            {
                return null;
            }
            else
            {
                account.Balance -= bankAccountRequest.Amount;
            }

            _bankContext.SaveChanges();

            return data;
        }


        //[Route("users/{userId}/bankaccounts/{name}/deposit/{amount}")]
        //public IEnumerable<BankAccount> DepositUserBankAccount(int userId, string name, decimal amount)
        //{
        //    // TODO: refactor params to dto object
        //    var data = _bankContext.BankAccounts.Where(b => b.UserId == userId && b.Name == name).ToList();
        //    var account = data.FirstOrDefault();
        //    account.Balance += amount;

        //    return data;
        //}

        //[Route("users/{userId}/bankaccounts/{name}/withdraw/{amount}")]
        //public IEnumerable<BankAccount> WithdrawUserBankAccount(int userId, string name, decimal amount)
        //{
        //    // TODO: refactor params to dto object
        //    var data = _bankContext.BankAccounts.Where(b => b.UserId == userId && b.Name == name).ToList();
        //    var account = data.FirstOrDefault();

        //    if (account.Balance - amount < 0)
        //    { 
        //        return null; 
        //    }              
        //    else
        //    {
        //        account.Balance -= amount;
        //    }
            
        //    return data;
        //}



        [HttpGet]
        public IEnumerable<BankAccount> Get()
        {
            var data = _bankContext.BankAccounts.ToList();
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody] BankAccount obj)
        {
            var data = _bankContext.BankAccounts.Add(obj);
            _bankContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BankAccount obj)
        {
            var data = _bankContext.BankAccounts.Update(obj);
            _bankContext.SaveChanges();
            return Ok();
        }
    }
}

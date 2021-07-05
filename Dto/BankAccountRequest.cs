using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Dto
{
    public class BankAccountRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string AccountName { get; set; }

        [Required]
        public string TransactionType { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}

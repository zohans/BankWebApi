using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApplication.Models
{
    public class BankAccount
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public Guid Number { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}

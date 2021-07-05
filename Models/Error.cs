using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankWebApplication.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string ReferenceNumber { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}

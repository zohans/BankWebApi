using BankWebApplication.Data;
using BankWebApplication.Dto;
using BankWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        readonly BankContext _bankContext;
        public UserController(BankContext BankContext)
        {
            _bankContext = BankContext;
        }

        [HttpPost]
        [Route("create")]
        public async Task<User> CreateUser([FromBody]UserRequest userRequest)
        {

            string userName = string.Empty;
            User userAdded = null;

            var headers = this.Request.Headers;
            if (headers.ContainsKey("UserName"))
            {
                userName = headers["UserName"];
            }            

            if (userName == "Admin")
            {
                userAdded = new User() { FirstName = userRequest.FirstName,
                    LastName = userRequest.LastName,
                    UserName = userRequest.FirstName + userRequest.LastName.Substring(0, 1),
                    CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };
                
                _bankContext.Add(userAdded);
                await _bankContext.SaveChangesAsync();
            }                

            return userAdded;
        }

        [HttpGet]
        public string Get()
        {            
            return "Welcome to Bank Web Api";
        }
    }
}

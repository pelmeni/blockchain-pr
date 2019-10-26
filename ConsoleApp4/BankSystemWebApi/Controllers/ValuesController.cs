using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSystem.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystemWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize()]
        [Route("user")]
        [HttpGet]
        public string GetUser()
        {
            var id = Guid.Parse(Request.HttpContext.User.Claims.ToArray()[1].Value);

            var userName = Request.HttpContext.User.Claims.ToArray()[0].Value;

            return userName;
        }
        [Authorize()]
        [Route("bankaccounts")]
        [HttpGet]
        public IEnumerable<string> GetBA()
        {
            
            var ops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());
            var id = Guid.Parse(Request.HttpContext.User.Claims.ToArray()[1].Value);
            var userAccounts = ops.GetList(id);
            return userAccounts.Select(i => i.AccountId.ToString());
        }
        [Authorize()]
        [Route("bankaccounts/add")]
        [HttpPost]
        public void AddBA()
        {
            var ops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());
            var id = Guid.Parse(Request.HttpContext.User.Claims.ToArray()[1].Value);
            var accountId = Guid.NewGuid();
            var userAccount = ops.AddOne(id, accountId);

        }
        [Authorize()]
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
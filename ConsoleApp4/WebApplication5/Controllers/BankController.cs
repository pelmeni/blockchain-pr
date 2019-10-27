using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSystem.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Providers;

namespace WebApplication5.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            var ops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims
                .FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                );

            var model = ops.GetList(userId).Select(i => new UserBankAccount()
            {
                AccountId = i.AccountId,
                BlockchainAddress = i.BlockchainAddress,
                UserAccountId = i.UserAccountId,
                UserId = i.UserId,
                Created = i.Created
            });
            
            return View(model);
        }
        // GET: Blockchain/Details/5
        public ActionResult Details(int id)
        {
            var ops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());
            var tops = new TransactionOperations(new DapperBankSystemConnectionStringProvider());
            var iops = new InvoiceOperations(new DapperBankSystemConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

            var userAccount = ops.GetOne(id);

            var transactions = tops.GetList(userAccount.AccountId).Select(i => new BankTransaction()
            {
                AccountId = i.AccountId,
                Amount = i.Value,
                Comment = i.Comment,
                Purpose = i.Purpose,
                StatusId = i.StatusId,
                TransactionId = i.TransactionId,
                Created = i.Created
            });
            var invoices = iops.GetList(userAccount.AccountId).Select(i => new BankInvoice() { 
                InvoiceId=i.InvoiceId,
                AccountId=i.AccountId,
                Amount=i.Amount,
                IssueDate=i.IssueDate,
                IssuerAddress=i.IssuerAddress,
                IssuerName=i.IssuerName,
                PaymentAccountId=i.PaymentAccountId,
                StatusId=i.StatusId,
                StatusChanged=i.StatusChanged,
                Created=i.Created
            });

            var balance = transactions.Sum(i=>i.Amount);

            var model = new UserBankAccountDetails()
            {
                AccountId = userAccount.AccountId,
                BlockchainAddress = userAccount.BlockchainAddress,
                UserAccountId = userAccount.UserAccountId,
                UserId = userAccount.UserId,
                Created = userAccount.Created,
                Transactions = transactions,
                Invoices = invoices,
                Balance = new BankAccountBalance() { AccountId = userAccount.AccountId, Amount = balance, Modified = DateTime.Now }
            };

             return View(model);
        }

        // GET: Blockchain/Create
        public ActionResult Create()
        {
            var ops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims
                .FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                );

            var accountId = Guid.NewGuid();

            var userAccount = ops.AddOne(userId, accountId);

            var model =  new UserBankAccount()
            {
                AccountId = userAccount.AccountId,
                BlockchainAddress = userAccount.BlockchainAddress,
                UserAccountId = userAccount.UserAccountId,
                UserId = userAccount.UserId,
                Created = userAccount.Created
            };

            return View(model);
        }

        // POST: Blockchain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // POST: Blockchain/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessInvoice(IFormCollection collection)
        {
            try
            {
                var invoiceId = Guid.Parse(collection["invoiceId"]);
                
                var iops = new InvoiceOperations(new DapperBankSystemConnectionStringProvider());
                var tops = new TransactionOperations(new DapperBankSystemConnectionStringProvider());

                var invoice = iops.GetOne(invoiceId);
                var transactions = tops.GetList(invoice.AccountId);
                var balance = transactions.Sum(i => i.Value);

                if(invoice.StatusId==0 && balance >= invoice.Amount)
                {
                    tops.AddOne(invoice.AccountId, -invoice.Amount, $"invoice #{invoice.InvoiceId}", "Invoice Payment");
                    iops.UpdageInvoiceStatus(invoice.InvoiceId, 1);
                }
                    

                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Blockchain/Create
        public ActionResult Charge(Guid accountId)
        {
            var ops = new UserAccountOperations(new DapperBankSystemConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims
                .FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
                );

            var model = new BankTransaction()
            {
                AccountId=accountId,
                Amount=0,
                Purpose="Charge"
            };

            return View(model);
        }

        // POST: Blockchain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Charge(IFormCollection collection)
        {
            try
            {
                var tops = new TransactionOperations(new DapperBankSystemConnectionStringProvider());

                var accountId = Guid.Parse(collection["AccountId"]);
                var value = decimal.Parse(collection["Amount"]);
                var comment = collection["Comment"];
                var purpose = collection["Purpose"];

                var transaction = tops.AddOne(accountId, value, comment, purpose);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Pillsy.DataTransferObjects.UpdateTransactionHistoryDto;
using Pillsy.DataTransferObjects.Account.AccountByMonthDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Pillsy.DataTransferObjects.TransactionHistory.TransactionHistoryExpenseMonthsDto;
using Pillsy.DataTransferObjects.TransactionHistory.TransactionHistoryRevenueMonthsDto;
using Newtonsoft.Json;
using NuGet.Protocol;
using Newtonsoft.Json.Linq;

namespace Pillsy.Controllers.TransactionHistories
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoriesController : ControllerBase
    {
        private readonly ITransactionHistoryService _transactionHistoryService;
        private readonly ICustomerPackageService _customerPackageService;


        public TransactionHistoriesController(ITransactionHistoryService transactionHistoryService, ICustomerPackageService customerPackageService)
        {
            _transactionHistoryService = transactionHistoryService;
            _customerPackageService = customerPackageService;
        }

        //GET: api/TransactionHistories
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistory()
        {
            return Ok(await _transactionHistoryService.GetAllTransactions());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all/success-status")]
        public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistorySuccessStatus()
        {
            return Ok(await _transactionHistoryService.GetAllTransactionsWithSuccessStatus());
        }

        // GET: api/TransactionHistories/5
        [Authorize(Roles = "Patient")]
        [HttpGet]
        [Route("get-transaction/{patientId}")]
        public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistoryByPatientId(Guid patientId)
        {
            var transactionHistory = await _transactionHistoryService.GetTransactionByPatientId(patientId);

            if (transactionHistory == null)
            {
                return NotFound();
            }

            return Ok(transactionHistory.ToList());
        }

        // GET: api/TransactionHistories/5
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Patient")]
        [HttpGet]
        [Route("history-transaction/{transactionId}")]
        public async Task<ActionResult<TransactionHistory>> GetTransactionHistoryByTransactionId(Guid transactionId)
        {
            var transactionHistory = await _transactionHistoryService.GetTransactionByTransactionId(transactionId);

            if (transactionHistory == null)
            {
                return NotFound();
            }

            return Ok(transactionHistory);
        }

        // PUT: api/TransactionHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("history-transaction/update-status")]
        public async Task<IActionResult> UpdateTransactionHistory(UpdateTransactionHistoryDto transactionHistoryDto)
        {
            try
            {
                var transaction = await _transactionHistoryService.GetTransactionByTransactionId(transactionHistoryDto.TransactionHistoryId);
                if (transaction != null)
                {
                    transaction.Status = 1;
                    var result = await _transactionHistoryService.UpdateTransactionHistory(transaction);

                    var customerPackages = await _customerPackageService.GetListCustomerPackageByPatientId(transaction.PatientId);
                    var customerPackage = customerPackages.OrderByDescending(c => c.CreatedDate).FirstOrDefault(c => c.CustomerPackageName.Contains("Premium"));
                    if (customerPackage != null)
                    {
                        await _customerPackageService.UpdateCustomerPackage(customerPackage);
                    }
                    if (result) return Ok("Update successfully!");
                    return BadRequest("Update failed!");
                }
                else
                {
                    return NotFound("Transaction not found!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all/expense/months")]
        public async Task<ActionResult<List<TransactionHistoryExpenseMonthsDto>>> GetTransactionHistoryExpenseMonths()
        {
            var trans = await _transactionHistoryService.GetAllTransactions();
            List<TransactionHistoryExpenseMonthsDto> expenseByMonths = new List<TransactionHistoryExpenseMonthsDto>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime dateTime = new DateTime(DateTime.Now.Year, i, 1);
                string month = dateTime.ToString("MMM");
                Random random = new Random();
                double randomValue = random.NextDouble() * (210 - 180) + 180;
                randomValue = Math.Round(randomValue, 2);
                expenseByMonths.Add(new TransactionHistoryExpenseMonthsDto
                {
                    X = month,
                    Y = randomValue,
                });
            }
            expenseByMonths = JsonConvert.DeserializeObject<List<TransactionHistoryExpenseMonthsDto>>("[\r\n  {\r\n    \"x\": \"Jan\",\r\n    \"y\": 189.46\r\n  },\r\n  {\r\n    \"x\": \"Feb\",\r\n    \"y\": 209.76\r\n  },\r\n  {\r\n    \"x\": \"Mar\",\r\n    \"y\": 181.08\r\n  },\r\n  {\r\n    \"x\": \"Apr\",\r\n    \"y\": 181.5\r\n  },\r\n  {\r\n    \"x\": \"May\",\r\n    \"y\": 209.31\r\n  },\r\n  {\r\n    \"x\": \"Jun\",\r\n    \"y\": 207.17\r\n  },\r\n  {\r\n    \"x\": \"Jul\",\r\n    \"y\": 197.52\r\n  },\r\n  {\r\n    \"x\": \"Aug\",\r\n    \"y\": 183.59\r\n  },\r\n  {\r\n    \"x\": \"Sep\",\r\n    \"y\": 190.12\r\n  },\r\n  {\r\n    \"x\": \"Oct\",\r\n    \"y\": 202.56\r\n  },\r\n  {\r\n    \"x\": \"Nov\",\r\n    \"y\": 189.14\r\n  },\r\n  {\r\n    \"x\": \"Dec\",\r\n    \"y\": 191.53\r\n  }\r\n]");


            return expenseByMonths;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all/revenue/months")]
        public async Task<ActionResult<List<TransactionHistoryRevenueMonthsDto>>> GetTransactionHistoryRevenueMonths()
        {
            var trans = await _transactionHistoryService.GetAllTransactions();
            List<TransactionHistoryRevenueMonthsDto> revenueByMonths = new List<TransactionHistoryRevenueMonthsDto>();

            for (int i = 1; i <= 12; i++)
            {
                //var jan = trans.Where(d => d.CreatedDate!.Value.Month.Equals(i));
                //var count = jan.Count();
                DateTime dateTime = new DateTime(DateTime.Now.Year, i, 1);
                string month = dateTime.ToString("MMM");
                double count = 0;
                foreach (var tran in trans.Where(t => t.Status == 1))
                {
                    if (tran.CreatedDate!.Value.Month == i)
                    {
                        count = count + tran.SubscriptionPackage.UnitPrice;
                    }
                }
                revenueByMonths.Add(new TransactionHistoryRevenueMonthsDto
                {
                    X = month,
                    Y = count,
                });
            }



            return revenueByMonths;
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all/expense/months/totals")]
        public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistoryExpenseMonthsTotals()
        {
            var trans = await _transactionHistoryService.GetAllTransactions();
            var expenseByMonthsResult = await GetTransactionHistoryExpenseMonths();
            var expenseJson = expenseByMonthsResult.Value.ToJson();
            var expenseByMonths = JsonConvert.DeserializeObject<List<TransactionHistoryExpenseMonthsDto>>(expenseJson);
            double count = 0;
            foreach (var expense in expenseByMonths!)
            {
                count = count + expense.Y;
            }

            var expenseTotals = Math.Round(count, 2).ToString();


            return Ok(expenseTotals);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all/revenue/months/totals")]
        public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistoryRevenueMonthsTotals()
        {
            // Get all transactions
            var transactions = await _transactionHistoryService.GetAllTransactions();

            // Get revenue by months
            //var revenueByMonthsResult = await GetTransactionHistoryRevenueMonths();


            //var trans = await _transactionHistoryService.GetAllTransactions();
            List<TransactionHistoryRevenueMonthsDto> revenueByMonths = new List<TransactionHistoryRevenueMonthsDto>();

            for (int i = 1; i <= 12; i++)
            {
                //var jan = trans.Where(d => d.CreatedDate!.Value.Month.Equals(i));
                //var count = jan.Count();
                DateTime dateTime = new DateTime(DateTime.Now.Year, i, 1);
                string month = dateTime.ToString("MMM");
                double count = 0;
                foreach (var tran in transactions.Where(t => t.Status == 1))
                {
                    if (tran.CreatedDate!.Value.Month == i)
                    {
                        count = count + tran.SubscriptionPackage.UnitPrice;
                    }
                }
                revenueByMonths.Add(new TransactionHistoryRevenueMonthsDto
                {
                    X = month,
                    Y = count,
                });
            }

            //// Parse revenue result to JSON
            //var revenueJson = revenueByMonthsResult.Value.ToJson();

            //// Parse JSON to list of DTOs
            //var expenseByMonths = JsonConvert.DeserializeObject<List<TransactionHistoryExpenseMonthsDto>>(revenueJson);

            // Calculate total expense
            double totalExpense = revenueByMonths.Sum(expense => expense.Y);

            // Round to 2 decimal places
            totalExpense = Math.Round(totalExpense, 2);


            return Ok(totalExpense);
        }
    }
}

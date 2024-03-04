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

namespace Pillsy.Controllers.TransactionHistories
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoriesController : ControllerBase
    {
        private readonly ITransactionHistoryService _transactionHistoryService;

        public TransactionHistoriesController(ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
        }

        //GET: api/TransactionHistories
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistory()
        {
            return Ok(await _transactionHistoryService.GetAllTransactions());
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

        ////POST: api/TransactionHistories
        ////To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public async Task<ActionResult<TransactionHistory>> AddNewTransactionHistory(TransactionHistory transactionHistory)
        //{
        //    if (_context.TransactionHistory == null)
        //    {
        //        return Problem("Entity set 'PillsyDBContext.TransactionHistory'  is null.");
        //    }
        //    _context.TransactionHistory.Add(transactionHistory);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTransactionHistory", new { id = transactionHistory.TransactionId }, transactionHistory);
        //}

        //// DELETE: api/TransactionHistories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTransactionHistory(Guid id)
        //{
        //    if (_context.TransactionHistory == null)
        //    {
        //        return NotFound();
        //    }
        //    var transactionHistory = await _context.TransactionHistory.FindAsync(id);
        //    if (transactionHistory == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TransactionHistory.Remove(transactionHistory);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TransactionHistoryExists(Guid id)
        //{
        //    return (_context.TransactionHistory?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        //}
    }
}

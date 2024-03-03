using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;

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

        // GET: api/TransactionHistories
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TransactionHistory>>> GetTransactionHistory()
        //{
        //  if (_context.TransactionHistory == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.TransactionHistory.ToListAsync();
        //}

        //// GET: api/TransactionHistories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TransactionHistory>> GetTransactionHistory(Guid id)
        //{
        //  if (_context.TransactionHistory == null)
        //  {
        //      return NotFound();
        //  }
        //    var transactionHistory = await _context.TransactionHistory.FindAsync(id);

        //    if (transactionHistory == null)
        //    {
        //        return NotFound();
        //    }

        //    return transactionHistory;
        //}

        //// PUT: api/TransactionHistories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTransactionHistory(Guid id, TransactionHistory transactionHistory)
        //{
        //    if (id != transactionHistory.TransactionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(transactionHistory).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TransactionHistoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/TransactionHistories
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TransactionHistory>> PostTransactionHistory(TransactionHistory transactionHistory)
        //{
        //  if (_context.TransactionHistory == null)
        //  {
        //      return Problem("Entity set 'PillsyDBContext.TransactionHistory'  is null.");
        //  }
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

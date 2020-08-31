using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using Microsoft.AspNetCore.Cors;

namespace LoanApp.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanContext _context;

        public LoansController(LoanContext context)
        {
            _context = context;
        }

        // GET: api/Loans=
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetCreditLoan()
        {
            return await _context.CreditLoan.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loan = await _context.CreditLoan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(Loan loan)
        {
            _context.CreditLoan.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loan>> DeleteLoan(int id)
        {
            var loan = await _context.CreditLoan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.CreditLoan.Remove(loan);
            await _context.SaveChangesAsync();

            return loan;
        }

        private bool LoanExists(long id)
        {
            return _context.CreditLoan.Any(e => e.Id == id);
        }
    }
}

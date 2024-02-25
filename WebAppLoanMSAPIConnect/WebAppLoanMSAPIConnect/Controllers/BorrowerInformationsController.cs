using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppLoanMSAPIConnect.Data;
using WebAppLoanMSAPIConnect.Models;

namespace WebAppLoanMSAPIConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerInformationsController : ControllerBase
    {
        private readonly WebAppLoanMSAPIConnectContext _context;

        public BorrowerInformationsController(WebAppLoanMSAPIConnectContext context)
        {
            _context = context;
        }

        // GET: api/BorrowerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowerInformation>>> GetBorrowerInformation()
        {
            return await _context.BorrowerInformation.ToListAsync();
        }

        // GET: api/BorrowerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowerInformation>> GetBorrowerInformation(int id)
        {
            var borrowerInformation = await _context.BorrowerInformation.FindAsync(id);

            if (borrowerInformation == null)
            {
                return NotFound();
            }

            return borrowerInformation;
        }

        // PUT: api/BorrowerInformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowerInformation(int id, BorrowerInformation borrowerInformation)
        {
            if (id != borrowerInformation.BorrowerId)
            {
                return BadRequest();
            }

            _context.Entry(borrowerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerInformationExists(id))
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

        // POST: api/BorrowerInformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BorrowerInformation>> PostBorrowerInformation(BorrowerInformation borrowerInformation)
        {
            _context.BorrowerInformation.Add(borrowerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrowerInformation", new { id = borrowerInformation.BorrowerId }, borrowerInformation);
        }

        // DELETE: api/BorrowerInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BorrowerInformation>> DeleteBorrowerInformation(int id)
        {
            var borrowerInformation = await _context.BorrowerInformation.FindAsync(id);
            if (borrowerInformation == null)
            {
                return NotFound();
            }

            _context.BorrowerInformation.Remove(borrowerInformation);
            await _context.SaveChangesAsync();

            return borrowerInformation;
        }

        private bool BorrowerInformationExists(int id)
        {
            return _context.BorrowerInformation.Any(e => e.BorrowerId == id);
        }
    }
}

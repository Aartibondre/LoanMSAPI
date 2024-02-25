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
    public class LegalDocumentsController : ControllerBase
    {
        private readonly WebAppLoanMSAPIConnectContext _context;

        public LegalDocumentsController(WebAppLoanMSAPIConnectContext context)
        {
            _context = context;
        }

        // GET: api/LegalDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalDocuments>>> GetLegalDocuments()
        {
            return await _context.LegalDocuments.ToListAsync();
        }

        // GET: api/LegalDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalDocuments>> GetLegalDocuments(int id)
        {
            var legalDocuments = await _context.LegalDocuments.FindAsync(id);

            if (legalDocuments == null)
            {
                return NotFound();
            }

            return legalDocuments;
        }

        // PUT: api/LegalDocuments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalDocuments(int id, LegalDocuments legalDocuments)
        {
            if (id != legalDocuments.ApplicationNo)
            {
                return BadRequest();
            }

            _context.Entry(legalDocuments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalDocumentsExists(id))
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

        // POST: api/LegalDocuments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LegalDocuments>> PostLegalDocuments(LegalDocuments legalDocuments)
        {
            _context.LegalDocuments.Add(legalDocuments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegalDocuments", new { id = legalDocuments.ApplicationNo }, legalDocuments);
        }

        // DELETE: api/LegalDocuments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegalDocuments>> DeleteLegalDocuments(int id)
        {
            var legalDocuments = await _context.LegalDocuments.FindAsync(id);
            if (legalDocuments == null)
            {
                return NotFound();
            }

            _context.LegalDocuments.Remove(legalDocuments);
            await _context.SaveChangesAsync();

            return legalDocuments;
        }

        private bool LegalDocumentsExists(int id)
        {
            return _context.LegalDocuments.Any(e => e.ApplicationNo == id);
        }
    }
}

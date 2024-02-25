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
    public class PropertyInformationsController : ControllerBase
    {
        private readonly WebAppLoanMSAPIConnectContext _context;

        public PropertyInformationsController(WebAppLoanMSAPIConnectContext context)
        {
            _context = context;
        }

        // GET: api/PropertyInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyInformation>>> GetPropertyInformation()
        {
            return await _context.PropertyInformation.ToListAsync();
        }

        // GET: api/PropertyInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyInformation>> GetPropertyInformation(int id)
        {
            var propertyInformation = await _context.PropertyInformation.FindAsync(id);

            if (propertyInformation == null)
            {
                return NotFound();
            }

            return propertyInformation;
        }

        // PUT: api/PropertyInformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyInformation(int id, PropertyInformation propertyInformation)
        {
            if (id != propertyInformation.ApplicantId)
            {
                return BadRequest();
            }

            _context.Entry(propertyInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyInformationExists(id))
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

        // POST: api/PropertyInformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PropertyInformation>> PostPropertyInformation(PropertyInformation propertyInformation)
        {
            _context.PropertyInformation.Add(propertyInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyInformation", new { id = propertyInformation.ApplicantId }, propertyInformation);
        }

        // DELETE: api/PropertyInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PropertyInformation>> DeletePropertyInformation(int id)
        {
            var propertyInformation = await _context.PropertyInformation.FindAsync(id);
            if (propertyInformation == null)
            {
                return NotFound();
            }

            _context.PropertyInformation.Remove(propertyInformation);
            await _context.SaveChangesAsync();

            return propertyInformation;
        }

        private bool PropertyInformationExists(int id)
        {
            return _context.PropertyInformation.Any(e => e.ApplicantId == id);
        }
    }
}

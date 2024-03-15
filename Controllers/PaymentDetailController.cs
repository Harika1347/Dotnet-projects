using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;
        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/<PaymentDetailController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET api/<PaymentDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetailById(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return Problem("PaymentDetails are empty");
            }
            var details = await _context.PaymentDetails.FindAsync(id);
            if (details == null)
            {
                return NotFound();
            }
            return details;
        }

        // POST api/<PaymentDetailController>
        [HttpPost("PostPaymentDetail")]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            if (_context.PaymentDetails == null)
            {
                return Problem("PaymentDetails are empty");
            }
            _context.PaymentDetails.Add(paymentDetail);
             await _context.SaveChangesAsync();
            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        // PUT api/<PaymentDetailController>/5
        [HttpPut("UpdatePayment/{id}")]
        public async Task<ActionResult> UpdatePaymentdetail(int id,PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentId)
            {
                return BadRequest();
            }
            var Paydetails = GetPaymentDetailById(id);
            _context.Entry(paymentDetail).State= EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(Paydetails==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(await _context.PaymentDetails.ToListAsync());

        }

        // DELETE api/<PaymentDetailController>/5
        [HttpDelete("DeletePayment/{id}")]
        public async Task<IActionResult> DeletePaymentDetailsById(int id)
        {
            var payDetails = await _context.PaymentDetails.FindAsync(id);
            if(payDetails == null)
            {
                return NotFound();
            }
            else
            {
                _context.PaymentDetails.Remove(payDetails); 
                await _context.SaveChangesAsync();  
            }
            return Ok(await _context.PaymentDetails.ToListAsync());
        }
    }
}

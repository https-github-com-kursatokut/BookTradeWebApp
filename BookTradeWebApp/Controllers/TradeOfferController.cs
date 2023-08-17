using BookTradeWebApp.DataContexts;
using BookTradeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTradeWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeOfferController : ControllerBase
    {
        private readonly UserDbContext _context;

        public TradeOfferController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeOffer>>> GetAllTradeOffers()
        {
            return await _context.TradeOffers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TradeOffer>> GetTradeOfferById(int id)
        {
            var tradeOffer = await _context.TradeOffers.FindAsync(id);

            if (tradeOffer == null)
            {
                return NotFound();
            }

            return tradeOffer;
        }

        [HttpPost]
        public async Task<ActionResult<TradeOffer>> CreateTradeOffer(TradeOffer tradeOffer)
        {
            _context.TradeOffers.Add(tradeOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTradeOfferById), new { id = tradeOffer.TradeOfferId }, tradeOffer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTradeOffer(int id, TradeOffer tradeOffer)
        {
            if (id != tradeOffer.TradeOfferId)
            {
                return BadRequest();
            }

            _context.Entry(tradeOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeOfferExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeOffer(int id)
        {
            var tradeOffer = await _context.TradeOffers.FindAsync(id);

            if (tradeOffer == null)
            {
                return NotFound();
            }

            _context.TradeOffers.Remove(tradeOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeOfferExists(int id)
        {
            return _context.TradeOffers.Any(to => to.TradeOfferId == id);
        }
    }
}

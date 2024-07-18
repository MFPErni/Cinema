using CinemaAPI.Data;
using CinemaAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly DataContext _context;
        public CinemaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetAllTickets()
        {
            var tickets = await _context.TicketList.ToListAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var specificTicket = await _context.TicketList.FindAsync(id);
            if (specificTicket is null)
            {
                return NotFound("Ticket not found.");
            }
            return Ok(specificTicket);
        }

        [HttpPost]
        public async Task<ActionResult<List<Ticket>>> AddMovie(Ticket addTicket)
        {
            _context.TicketList.Add(addTicket);
            await _context.SaveChangesAsync();

            return Ok(await _context.TicketList.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Ticket>>> UpdateTicket(Ticket updateTicket)
        {
            var dbTicket = await _context.TicketList.FindAsync(updateTicket.Id);
            if (dbTicket is null)
            {
                return NotFound("Ticket not found");
            }

            dbTicket.Id = updateTicket.Id;
            dbTicket.PurchaseDate = updateTicket.PurchaseDate;
            dbTicket.Mdetails = updateTicket.Mdetails;
            dbTicket.Vdetails = updateTicket.Vdetails;

            await _context.SaveChangesAsync();

            return Ok(await _context.TicketList.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Ticket>>> DeleteTicket(int id)
        {
            var dbTicket = await _context.TicketList.FindAsync(id);
            if (dbTicket is null)
            {
                return NotFound("Ticket not found");
            }

            _context.TicketList.Remove(dbTicket);
            await _context.SaveChangesAsync();

            return Ok(await _context.TicketList.ToListAsync());
        }
    }
}

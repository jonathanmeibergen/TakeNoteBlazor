
using TakeNoteBlazor.Server.Data;
using TakeNoteBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Server;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TakeNoteBlazor.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly TakeNoteContext _context;
        private int pageLength { get; set; }
        public NoteController(TakeNoteContext context)
        {
            _context = context;
            pageLength = 8;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalAmount()
        {
            var total = await _context.Notes.CountAsync();
            return Ok(total);
        }

        [HttpGet("totalpages")]
        public async Task<IActionResult> GetTotalPages()
        {
            int total = await _context.Notes.CountAsync();
            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total)/Convert.ToDecimal(pageLength)));
            return Ok(totalPages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var notes = await _context.Notes.FirstOrDefaultAsync(n => n.Id.Equals(id));
            return Ok(notes);
        }

        [HttpGet("paging/{page}")]
        public async Task<IActionResult> GetPage(int page)
        {
            var notes = await _context.Notes.Skip(pageLength * (page-1))
                                            .Take(pageLength)
                                            .ToListAsync();
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> Post (Note note)
        {
            note.AuthorId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Add(note);
            await _context.SaveChangesAsync();
            return Ok(note.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put (Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var note = new Note { Id = id };
            _context.Remove(note);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

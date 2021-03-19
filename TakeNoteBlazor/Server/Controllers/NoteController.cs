using TakeNoteBlazor.Server.Data;
using TakeNoteBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var notes = await _context.Notes.FirstOrDefaultAsync(n => n.Id.Equals(id));
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> Post (Note note)
        {
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

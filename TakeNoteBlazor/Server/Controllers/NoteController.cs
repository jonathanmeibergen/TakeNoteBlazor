
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
using TakeNoteBlazor.Server.Repositories;

namespace TakeNoteBlazor.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly IRepository<Note> _repository;
        private int pageLength { get; set; }
        public NoteController(IRepository<Note> repository)
        {
            _repository = repository;
            pageLength = 8;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _repository.GetAllAsync();
            return Ok(notes);
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            int total = await _repository.GetTotalAsync();
            //int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total)/Convert.ToDecimal(pageLength)));
            return Ok(total);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var notes = await _repository.GetAsync(id);
            return Ok(notes);
        }

        [HttpGet("paging/{page}")]
        public async Task<IActionResult> GetPage(int page)
        {
            var notes = await _repository.TakeAsync(pageLength * (page - 1), pageLength);
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> Post (Note note)
        {
            note.AuthorId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _repository.AddAndSaveAsync(note);
            return Ok(note.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put (Note note)
        {
            await _repository.ChangeStateAndSaveAsync(note, EntityState.Modified);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            await _repository.DeleteAndSaveAsync(id);
            return NoContent();
        }
    }
}

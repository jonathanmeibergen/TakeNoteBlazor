using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Server.Data;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Services
{
    public class NoteService : INoteService
    {
        private readonly TakeNoteContext _dbContext;

        public NoteService(TakeNoteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteNote(int id)
        {
            var note = _dbContext.Notes.FirstOrDefault(n => n.Id.Equals(id));
            _dbContext.Notes.Remove(note);
            _dbContext.SaveChangesAsync();
        }

        public Note GetNote(int id)
        {
            return _dbContext.Notes.FirstOrDefault(n => n.Id.Equals(id));
        }

        public List<Note> GetNotes()
        {
            return _dbContext.Notes.ToList();
        }

        public void SaveNote(Note note)
        {
            _dbContext.AddAsync(note);
            _dbContext.SaveChangesAsync();
        }
    }
}

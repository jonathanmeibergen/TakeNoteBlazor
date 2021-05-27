using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Repositories
{
    public interface INoteRepository
    {
        List<Note> GetNotes();
        Note GetNote(int id);
        void SaveNote(Note note);
        void DeleteNote(int id);
    }
}

using EnsolversPT.Context;
using EnsolversPT.Interfaces;
using EnsolversPT.Models;
using Microsoft.EntityFrameworkCore;

namespace EnsolversPT.Managers
{
    public class NotesManager : IService<Note>
    {
        private readonly NotesContext _context;
        public NotesManager(NotesContext notesContext) 
        {
            _context = notesContext;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            var notes = await _context.Notes.ToListAsync();

            return notes;
        }


        public async Task<Note> InsertNoteAsync(Note newNote)
        {
            await _context.Notes.AddAsync(newNote);
            await _context.SaveChangesAsync();

            return newNote;
        }

        public async Task<Note> Delete(int id)
        {


            var note = await _context.Notes.SingleOrDefaultAsync(n=> n.Id == id);          
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();

                return note;
            }

            return null;
        }

        public async Task<Note> Modify(Note note, int id)
        {

            Note? noteModify = await _context.Notes.FindAsync(id);
            noteModify.Tag = note.Tag;
            noteModify.Title = note.Title;
            noteModify.Description = note.Description;

            _context.Entry(noteModify).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return noteModify;
        }

        public async Task<IEnumerable<Note>> GetByTag(string tag)
        {
            var notesbytag = _context.Notes.Where(n => n.Tag == tag);
            if(notesbytag != null)
            {
                return notesbytag;
            }
            return null;
                                            
        }
    }
}

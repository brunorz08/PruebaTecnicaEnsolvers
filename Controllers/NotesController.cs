using EnsolversPT.Interfaces;
using EnsolversPT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnsolversPT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IService<Note> _notes;
        public NotesController(IService<Note> note)
        {
            _notes = note;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAll()

        {

            IEnumerable<Note> listNotes = await _notes.GetAllAsync();
            if (listNotes != null)
            {

                return Ok(listNotes);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Note>> NewNote(Note note)
        {
            if (ModelState.IsValid)
            {
                await _notes.InsertNoteAsync(note);
                return Ok(note);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> DeleteNote(int id)
        {
            try
            {
                Note note = await _notes.Delete(id);

                return Ok(note);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Note>> ModifyNote(int id, Note note)
        {
            if (ModelState.IsValid)
            {
                var Note = await _notes.Modify(note,id);
                return Ok(Note);
            }

            return BadRequest();
        }

        [HttpGet("{tag}")]
        public async Task<ActionResult<IEnumerable<Note>>> GetByTag(string tag)
        {
            IEnumerable<Note> notes = await _notes.GetByTag(tag);

            if(notes != null)
            {
                return Ok(notes);
            }

            return NotFound();
        }

        
        

    }
}

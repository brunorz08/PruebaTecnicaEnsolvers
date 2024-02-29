using EnsolversPT.Models;
using Microsoft.EntityFrameworkCore;

namespace EnsolversPT.Context
{
    public class NotesContext : DbContext
    {

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {

        }


        public virtual DbSet<Note> Notes { get; set; }


    }
}

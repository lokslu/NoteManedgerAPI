using System;
using Microsoft.EntityFrameworkCore;
using NoteManedgerAPI.EF.Entity;


namespace NoteManedgerAPI.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
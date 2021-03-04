using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteManedgerAPI.EF;
using NoteManedgerAPI.EF.Entity;

namespace NoteManedgerAPI.repositories
{
    public class _db_Note_manedger
    {
        private readonly ApplicationContext _db;

        public _db_Note_manedger(ApplicationContext db)
        {
            _db = db;
        }
        
        public List<Note> GetNotesByUser(int userid)
        {
            return (from note in _db.Notes
             where note.usetId == userid
             orderby note.orderId
             select note).ToList();
        }   

        public bool Insert_and_ordering_orderID(Note NewNote)
        {
            NewNote.orderId = 0;

            List<Note> Notes = (from note in _db.Notes
                          where note.usetId == NewNote.usetId
                          orderby note.orderId
                          select note).ToList() ;

            if (Notes == null || Notes.Count == 0)
            {
                _db.Notes.Add(NewNote);
            }
            else
            {
                _db.Notes.Add(NewNote);
                for (int i = 0; i < Notes.Count; i++)
                {
                    Notes[i].orderId = i+1;
                }
            }
            _db.SaveChanges();
            return true;

        }
        public bool Update(Note RenewedNote)
        {
            _db.Entry(RenewedNote).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }
        public bool Delete(int NoteId)
        {
            var userTask = _db.Notes.FirstOrDefault(x => NoteId == x.id);
            _db.Notes.Remove(userTask ?? throw new InvalidOperationException());
            _db.SaveChanges();
            return true;
        }
        public bool Ordering(List<Note> OrderingNotes)
        {
            for (int i = 0; i < OrderingNotes.Count; i++)
            {
                _db.Entry(OrderingNotes[i]).State = EntityState.Modified;
            }
            _db.SaveChanges();
            return true;
        }

    }
}

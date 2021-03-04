using NoteManedgerAPI.EF;
using NoteManedgerAPI.EF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManedgerAPI.repositories
{
    public class _db_User_manedger
    {
        private readonly ApplicationContext _db;

        public _db_User_manedger(ApplicationContext db)
        {
            _db = db;
        }
        public bool checkUser(string email, string password)
        {
            return null != _db.Users.FirstOrDefault(x => x.email == email && x.password == password);

        }
        public bool checkNewUser(string email)
        {
            return !_db.Users.Any(user=>user.email==email);

        }
        public void Insert(User item)
        {
            _db.Users.Add(item);
            _db.SaveChanges();
        }
        public User GetUser_by_Email(string email)
        {
            return _db.Users.FirstOrDefault(x => email == x.email);
        }
    }
}

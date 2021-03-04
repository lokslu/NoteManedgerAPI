using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManedgerAPI.Models
{
    public class RegisterModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}

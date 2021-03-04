using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManedgerAPI.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }
}

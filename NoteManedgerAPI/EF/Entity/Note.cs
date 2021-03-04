using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManedgerAPI.EF.Entity
{
    public class Note
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("User")]
        public int usetId { get; set; }
        public int orderId { get; set; }

        public string title { get; set; }
        public string color { get; set; }
        public string body { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

using NoteManedgerAPI.repositories;
using System.Collections;
using NoteManedgerAPI.EF; 
using NoteManedgerAPI.EF.Entity;
using Microsoft.AspNetCore.Authorization;

namespace NoteManedgerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        //M-Manedger
        //db-databases
        private readonly _db_Note_manedger M_db_Notes;
        private readonly _db_User_manedger M_db_Users;

        public NoteController(ApplicationContext db)
        {
            M_db_Notes = new _db_Note_manedger(db);
            M_db_Users = new _db_User_manedger(db);
        }



        [HttpGet("{email}")]
        public IEnumerable<Note> Get(string email)
        {
            User current = M_db_Users.GetUser_by_Email(email);
            return M_db_Notes.GetNotesByUser(current.id);
        }

        [HttpPost]
        public void Post([FromBody] Note NewNote, [FromQuery]int id)
        {
            NewNote.usetId = id;
            Console.WriteLine("id - "+NewNote.id);
            Console.WriteLine("userid - "+NewNote.usetId);
            Console.WriteLine("orderid - "+NewNote.orderId);
            Console.WriteLine("title- "+NewNote.title);
            Console.WriteLine("color - "+NewNote.color);
            Console.WriteLine("body - "+NewNote.body);

            M_db_Notes.Insert_and_ordering_orderID(NewNote);
        }

        //public void Put([FromBody] Note value,[FromQuery]int id)//[FromQuery]-подтягивает с запроса 
        [HttpPut]
        public void UpdateNote([FromBody] Note RenewedNote)
        {
            M_db_Notes.Update(RenewedNote);
        }
       
        [HttpDelete]
        public void DeleteNote([FromQuery]int id)
        {
            M_db_Notes.Delete(id);

        }

        [HttpPut("ordering")]
        public void CangeOrderNote([FromBody] List<Note> OrderingNotes)
        {
            M_db_Notes.Ordering(OrderingNotes);
        }
    }




}
        //Имуляцыя запосов к БД
        /*public static List<Note> mas= new List<Note>(){
                new Note(),
                new Note(),
            };

        // GET: api/Note
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return mas;
        }
        
        // GET: api/Note/5
        //[HttpGet("{id}", Name = "Get")]   
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Note
        [HttpPost]
        public void Post([FromBody] Note value)
        {
            mas.Insert(0, value);                      
        }

        [HttpPut]
        public void Put([FromBody] Note value,[FromQuery]int id)
        {
            //int id = Int32.Parse(Request.Query["id"]);
            mas[id] = value;
        }
        [HttpPut("upmas")]
        public void updatenotes([FromBody] List<Note> notes)
        {
            //int id = Int32.Parse(Request.Query["id"]);

            mas = notes;
        }

        // PUT: api/Note/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete([FromQuery]int id)
        {
            mas.RemoveAt(id);
           
        }*/
    
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Common.Model;
using CommonContext;
using Common.DAL;

namespace CoreAPI.Controllers
{
    public class UsersController : ApiController
    {
        //private CoreContext db = new CoreContext();
        private IUserRepository repo;

        public UsersController()
        {
            repo = new UserRepositoryEF(new CoreContext());
        }

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            //return db.Users;
            return repo.GetAllItems();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = repo.GetItemById(id);
            if (user == null)
                return NotFound();

            return (IHttpActionResult)repo.GetItemById(id); // Potential Issue with cast.
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != user.ID)
                return BadRequest();

            //db.Entry(user).State = EntityState.Modified;

            try
            {
                //db.SaveChanges();
                repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.InsertItem(user);
            repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = repo.GetItemById(id);
            if (user == null)
            {
                return NotFound();
            }

            repo.DeleteItem(id);
            repo.Save();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return repo.GetAllItems().Count(e => e.ID == id) > 0;
        }
    }
}
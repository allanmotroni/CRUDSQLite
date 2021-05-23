using CRUDSQLite.Contexts;
using CRUDSQLite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Contact>> List()
        {
            List<Contact> contacts = null;
            using (ContactContext context = new ContactContext())
            {
                contacts = await context.Contacts.ToListAsync();
            }

            return contacts;  
        }

        [HttpGet]
        [Route("{contactId:int}")]
        public async Task<Contact> GetById(int contactId)
        {
            Contact contact = null;
            using (ContactContext context = new ContactContext())
            {
                contact = await context.Contacts.FindAsync(contactId);
            }

            return contact;
        }

        [HttpGet]
        [Route("{contactName:alpha}")]
        public async Task<Contact> GetByName(string contactName)
        {
            Contact contact = null;
            using (ContactContext context = new ContactContext())
            {
                contact = await context.Contacts.FirstOrDefaultAsync(p=>p.Name == contactName);
            }

            return contact;
        }

        [HttpPost]
        public async Task<Contact> Insert([FromBody] Contact contact)
        {
            using (ContactContext context = new ContactContext())
            {
                await context.AddAsync(contact);
                await context.SaveChangesAsync();
            }

            return contact;
        }

        [HttpPut]
        public async Task<Contact> Alter([FromBody] Contact contact)
        {
            using (ContactContext context = new ContactContext())
            {
                context.Update(contact);
                await context.SaveChangesAsync();
            }

            return contact;
        }

        [HttpDelete]
        public async Task<Contact> Remove([FromBody] Contact contact)
        {
            using (ContactContext context = new ContactContext())
            {
                context.Remove(contact);
                await context.SaveChangesAsync();
            }

            return contact;
        }
    }
}

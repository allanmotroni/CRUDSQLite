using CRUDSQLite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSQLite.Contexts
{
    public class ContactContext : DbContext
    {
        public ContactContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Test.sqlite");
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

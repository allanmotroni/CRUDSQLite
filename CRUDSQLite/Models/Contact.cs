﻿namespace CRUDSQLite.Models
{
    public class Contact : Base
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name}";
        }
    }
}

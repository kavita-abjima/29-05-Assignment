﻿namespace WebApiDbMigrations.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string ? FirstName { get; set; }

        public string ? LastName { get; set; }

        public string ? Gender { get; set; }

        public string ? City { get; set; }

        internal class EmpMapping
        {
            internal class APIMapping
            {
            }
        }
    }
}

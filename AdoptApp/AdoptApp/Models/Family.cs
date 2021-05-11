using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptApp.Models
{
    [Table("Families")]
    public class Family
    {
        [PrimaryKey, AutoIncrement]
        public int FamilyId { get; set; }

        [Unique]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Unique]
        public string Email { get; set; }
        [Unique]
        public string License { get; set; }
        public string Agency { get; set; }

        public string Pic { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Languages { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Children { get; set; }
        public string Pets { get; set; }

        public string Description { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }

        [OneToMany]
        public List<Home> Homes { get; set; }
    }
}

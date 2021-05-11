using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptApp.Models
{
    [Table("CaseWorkers")]
    public class CaseWorker
    {
        [Unique]
        public string CaseWorkerId { get; set; }

        [PrimaryKey, AutoIncrement]
        public int WorkerId { get; set; }
        public string Agency { get; set; }
        [Unique]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [OneToMany] 
        public List<Case> cases { get; set; }
    }
}

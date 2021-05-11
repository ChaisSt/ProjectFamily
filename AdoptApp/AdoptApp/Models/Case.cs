using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptApp.Models
{
    [Table("Cases")]
    public class Case
    {
        [PrimaryKey, AutoIncrement]
        public int CaseId { get; set; }
        [Unique]
        public string CaseNum { get; set; }
        //[ForeignKey(typeof(CaseWorker))] 
        public string CaseWorkerId { get; set; }
        public string Pic { get; set; }
        public string Description { get; set; }
        public int Group { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string Race { get; set; }
        public string Language { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
    }
}

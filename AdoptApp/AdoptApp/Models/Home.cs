using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptApp.Models
{
    [Table("Homes")]
    public class Home
    {
        [PrimaryKey, AutoIncrement]
        public int HomeId { get; set; }
        [ForeignKey(typeof(Family))]
        public string UserName { get; set; }
        [Unique]
        public string Address { get; set; }
        public string Type { get; set; }
        public string Owned { get; set; }
        public int Bedrooms { get; set; }
        public string Yard { get; set; }
        public string YardType { get; set; }
        public string Additional { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptApp.Models
{
    [Table("Logins")]
    public class Login
    {
        [PrimaryKey, AutoIncrement]
        public int LoginId { get; set; }

        [Unique]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AcctType { get; set; }

    }
}

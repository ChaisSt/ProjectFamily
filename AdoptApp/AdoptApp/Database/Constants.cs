﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdoptApp.Database
{
    public class Constants
    {
        public const string dbName = "Adopt.db3";

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;


        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(basePath, dbName);
            }
        }

    }
}



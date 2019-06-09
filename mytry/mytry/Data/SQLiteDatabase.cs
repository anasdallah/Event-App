using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mytry
{
    public sealed class SQLiteDatabase
    {
        private SQLiteAsyncConnection _database;

        public SQLiteAsyncConnection GetConnectionAsync() {
            if (_database is null)
                return _database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"MyDb.SQLite3"));
            return _database;
        }
    }
}

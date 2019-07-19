using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace XFSQLiteDemo.Interfaces
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}

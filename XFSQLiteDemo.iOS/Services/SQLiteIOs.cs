using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using XFSQLiteDemo.Interfaces;
using XFSQLiteDemo.iOS.Services;


[assembly: Dependency(typeof(SQLiteIOs))]
namespace XFSQLiteDemo.iOS.Services
{
    public class SQLiteIOs : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, "Mydatabase.db");
            // Create the connection  
            var connection = new SQLiteConnection(path);
            // Return the database connection  
            return connection;
        }
    }
}
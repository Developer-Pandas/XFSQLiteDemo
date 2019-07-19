using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLitePCL;
using System.IO;
using Xamarin.Forms;
using XFSQLiteDemo.Droid.Services;
using XFSQLiteDemo.Interfaces;

[assembly: Dependency(typeof(SQliteDroid))]
namespace XFSQLiteDemo.Droid.Services
{
    public class SQliteDroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "Mydatabase.db";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
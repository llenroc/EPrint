using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using EPrint.Services.Local;
using SQLite;
using Xamarin.Forms;
using EPrint.iOS.Services;
using System.IO;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace EPrint.iOS.Services
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "UserSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var conn = new SQLiteConnection(path);
            // Return the database connection 
            return conn;
        }
    }
}
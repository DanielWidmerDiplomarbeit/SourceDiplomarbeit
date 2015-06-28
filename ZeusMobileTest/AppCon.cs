// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using ZeusMobile.Data;

namespace ZeusMobileTest
{
    public static class AppConn
    {
        static SQLite.Net.SQLiteConnection _conn;
        static DataBase _database;
        public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        {
            _conn = connection;
            _database = new DataBase(_conn);
        }
        public static DataBase TestDataBase
        {
            get { return _database; }
        }
    }
}
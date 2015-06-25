using ZeusMobile.Data;

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
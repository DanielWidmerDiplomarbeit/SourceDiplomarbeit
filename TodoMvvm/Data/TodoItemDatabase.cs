using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using ZeusMobile.Models;

namespace ZeusMobile.Data
{
	public class TodoItemDatabase 
	{
		static object locker = new object ();

		SQLiteConnection database;

		public TodoItemDatabase(SQLiteConnection conn)
		{
			database = conn;
			database.CreateTable<TodoItem>();
			database.CreateTable<Subject>();
			database.CreateTable<Versicherter>();
			database.CreateTable<SchadensExperte>();
		}

		public IEnumerable<Subject> GetSubjects ()
		{
			lock (locker) {
				return (from i in database.Table<Subject>() select i).ToList();
			}
		}

		public IEnumerable<Versicherter> GetVersicherte()
		{
			lock (locker) {
				return (from i in database.Table<Versicherter>() select i).ToList();
			}
		}

		public IEnumerable<SchadensExperte> GetSchadensExperten ()
		{
			lock (locker) {
				return (from i in database.Table<SchadensExperte>() select i).ToList();
			}
		}


		public IEnumerable<TodoItem> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<TodoItem>() select i).ToList();
			}
		}

		public IEnumerable<TodoItem> GetItemsNotDone ()
		{
			lock (locker) {
				return database.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
			}
		}

		public TodoItem GetItem (int id) 
		{
			lock (locker) {
				return database.Table<TodoItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveSubjects ( List<Subject> items){

			return database.InsertAll (items, typeof(Subject));			
		}
		public int SaveVersicherte ( List<Versicherter> items){

			return database.InsertAll (items, typeof(Versicherter));			
		}
		public int SaveSchadensExperten ( List<SchadensExperte> items){

			return database.InsertAll (items, typeof(SchadensExperte));			
		}

		public int SaveItem (TodoItem item) 
		{
			lock (locker)
			{
			    if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				}
			    return database.Insert(item);
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<TodoItem>(id);
			}
		}
	}
}


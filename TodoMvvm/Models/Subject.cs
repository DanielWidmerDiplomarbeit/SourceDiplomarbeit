using System;
using SQLite.Net.Attributes;

namespace TodoMvvm
{
	public class Subject
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Rolle { get; set;}
		public string Name { get; set; }
	}
}
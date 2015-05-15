using System;
using SQLite.Net.Attributes;

namespace ZeusMobile.Models
{
	public class TodoItem
	{
	    [PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
        
		public DateTime Schadensdatum{ get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
	}
}


using SQLite.Net.Attributes;

namespace ZeusMobile.Models
{
	public class Subject
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Rolle { get; set;}
		public string Name { get; set; }
	}
}
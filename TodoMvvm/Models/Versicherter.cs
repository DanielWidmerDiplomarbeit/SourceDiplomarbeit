using System;
using SQLite.Net.Attributes;

namespace TodoMvvm
{
	public class Versicherter : Subject
	{
		public Versicherter(){
			ID = base.ID;
			Name = base.Name;
		}
		public int VersichertenNr { get; set; }
	}
}
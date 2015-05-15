using System;
using SQLite.Net.Attributes;

namespace TodoMvvm
{
	public class SchadensExperte : Subject
	{
		public SchadensExperte(){
			ID = base.ID;
			Name = base.Name;
		}
		public int ExpertenNr { get; set; }
	}
}
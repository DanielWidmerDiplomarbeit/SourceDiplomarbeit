using System;
using SQLite.Net;
using System.Collections.Generic;
using TodoMvvm;
using System.Linq;

namespace QuickTodo
{
	public class DemoData
	{
		public DemoData(){
		}

		public List<Subject> Subjects {
			get; 
			private set;
		}

		public List<Versicherter> Versicherte {
			get; 
			private set;
		}

		public List<SchadensExperte> SchadensExperten {
			get; 
			private set;
		}

		public void buildDemoData()
		{

		var versichertenNr = 3215;
		var expertenNr = 15;
			Versicherte = new List<Versicherter>();
			SchadensExperten = new List<SchadensExperte>();

		Subjects = DemoSubjects ();

		foreach (var subject in Subjects)
			{
				if (subject.Rolle.Equals("Kunde"))
				{
					Versicherter versicherter = new Versicherter {
						ID = subject.ID,
						Name = subject.Name,
						Rolle = subject.Rolle
					};
					versicherter.VersichertenNr = versichertenNr++;
					Versicherte.Add(versicherter);
				}

				if (subject.Rolle.Equals("Experte"))
				{
					SchadensExperte experte = new SchadensExperte {
						ID = subject.ID,
						Name = subject.Name,
						Rolle = subject.Rolle
					};
					experte.ExpertenNr = expertenNr++;
					SchadensExperten.Add(experte);
				}
			}
		}

		private List<Subject> DemoSubjects()
		{
			var _subjects = new List<Subject> {
				new Subject() {Name = "Kunde Adam", Rolle = "Kunde" },
				new Subject() {Name = "Kunde Bruno", Rolle = "Kunde" },
				new Subject() {Name = "Expertin Eva", Rolle = "Experte" },
				new Subject() {Name = "Experte Zorro", Rolle = "Experte" }
			};

			return _subjects;
		}

	}
}


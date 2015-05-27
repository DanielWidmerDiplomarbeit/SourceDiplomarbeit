using System;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
	class SchadenCellViewModel : BaseViewModel
	{
		Schaden schaden;

		public Schaden Item { get { return schaden; }}

		public string Strasse { get { return schaden.Strasse; }}
		public int Id { get { return schaden.Id; }}
		public int PoliceNr { get { return schaden.PoliceId; }}
        public Schaden.EnumStatus Status { get { return schaden.Status; } }



		public SchadenCellViewModel (Schaden schadenItem)
		{
			schaden = schadenItem;
		}
	}
}


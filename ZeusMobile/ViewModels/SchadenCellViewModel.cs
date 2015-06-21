using System;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
	class SchadenCellViewModel : BaseViewModel
	{
	    public Schaden Schaden { get; set; }

	    public string SchadenListeText
	    {
	        get
	        {
                return Schaden.Beschreibung + " " + Schaden.Ort;
	        }
	    }
		
		public SchadenCellViewModel (Schaden schadenItem)
		{
			Schaden = schadenItem;
		}
	}
}


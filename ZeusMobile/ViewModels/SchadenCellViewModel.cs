// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using ZeusMobile.BaseClassesGD;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    public class SchadenCellViewModel : BaseViewModel
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


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


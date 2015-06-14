using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    class ObjekteViewModel : BaseViewModel
    {

        public ObjekteViewModel(Objekt objekt)
        {
            Objekt = objekt;
        }

        public Objekt Objekt { get; private set; }
    }
}


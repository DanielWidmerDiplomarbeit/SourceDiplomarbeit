using ZeusMobile.BaseClassesGD;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
    class PolicenViewModel : BaseViewModel
    {

        public PolicenViewModel(Police police)
        {
            Police = police;
        }
        
        public Police Police { get; private set; }
    }
}


// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using ZeusMobile.BaseClassesGD;
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


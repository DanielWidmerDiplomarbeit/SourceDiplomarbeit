// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using System.Collections.ObjectModel;
using ZeusMobile.Models;
using ZeusMobile.ViewModels;

namespace ZeusMobile.Services
{
    interface IZeusDbService
    {
        //Protokoll
        void SaveProtokoll(Schaden schaden, Protokoll protokoll);
        void DeleteProtokoll( Protokoll protokoll);
        Protokoll ReadProtokoll(int schadenId);

        //Schaden
        void SaveSchaden(Schaden schaden);
        Schaden ReadSchaden(int schadenId);

        ObservableCollection<SchadenCellViewModel> ReadSchadenListe(string sucheText, bool nurPendente);

        //Objekt
        Objekt ReadObjekt(int objektId);

        //Police
        Police ReadPolice(int policeId);

        //Versicherter
        Versicherter ReadVersicherter(int versicherterId);

        //Sachbearbeiter
        Sachbearbeiter ReadSachbearbeiter(int sachbearbeiterId);

        //Person
        Person ReadPerson(int personId);

    }
}

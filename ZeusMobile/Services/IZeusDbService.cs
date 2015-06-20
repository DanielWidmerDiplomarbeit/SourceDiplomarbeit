using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusMobile.Models;

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
        List<Schaden> ReadSchadenListe();

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

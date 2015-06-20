using System;
using System.Collections.Generic;
using ZeusMobile.Data;
using ZeusMobile.Models;

namespace ZeusMobile.Services
{
    public class ZeusDbService : IZeusDbService
    {
        private readonly DataBase _dataBase;

        public ZeusDbService(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public void SaveProtokoll(Schaden schaden, Protokoll protokoll)
        {
            if (schaden.Status == Schaden.EnumStatus.Gemeldet
                || schaden.Status == Schaden.EnumStatus.ZurBesichtigung
                || schaden.Status == 0)
            {
                schaden.Status = Schaden.EnumStatus.Aufgenommen;
            }

            protokoll.SchadenId = schaden.Id;
            _dataBase.SaveProtokoll(protokoll);
            protokoll = _dataBase.GetProtokollBySchadenNr(schaden.Id);

            if (schaden.Protokoll == null)
            {
                schaden.Protokoll = new Protokoll();
                schaden.Protokoll = protokoll;
            }
            
            schaden.LetzteMutation = DateTime.Now;
            _dataBase.SaveSchaden(schaden);
        }

        public void DeleteProtokoll(Protokoll protokoll)
        {
            var schaden = _dataBase.GetSchaden(protokoll.SchadenId);
            _dataBase.DeleteProtokoll(protokoll);
            schaden.Protokoll = null;
            schaden.Status = Schaden.EnumStatus.ZurBesichtigung;
            schaden.LetzteMutation = DateTime.Now;
            _dataBase.InsertOrReplaceSchadenWithChildren(schaden);
        }

        public Protokoll ReadProtokoll(int schadenId)
        {
            return _dataBase.GetProtokollBySchadenNr(schadenId);
        }

        public void SaveSchaden(Schaden schaden)
        {
            schaden.LetzteMutation = DateTime.Now;
            _dataBase.SaveSchaden(schaden);
        }

        public Schaden ReadSchaden(int schadenId)
        {
            return _dataBase.GetSchaden(schadenId);
        }

        public List<Schaden> ReadSchadenListe()
        {
            throw new NotImplementedException();
        }

        public Objekt ReadObjekt(int objektId)
        {
            throw new NotImplementedException();
        }

        public Police ReadPolice(int policeId)
        {
            throw new NotImplementedException();
        }

        public Versicherter ReadVersicherter(int versicherterId)
        {
            throw new NotImplementedException();
        }

        public Sachbearbeiter ReadSachbearbeiter(int sachbearbeiterId)
        {
            throw new NotImplementedException();
        }

        public Person ReadPerson(int personId)
        {
            throw new NotImplementedException();
        }
    }
}

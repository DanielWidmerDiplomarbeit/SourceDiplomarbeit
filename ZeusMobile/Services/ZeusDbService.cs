// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using System;
using System.Collections.ObjectModel;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.ViewModels;

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
            SaveProtokoll(schaden, protokoll, 0);
        }

        public void SaveProtokoll(Schaden schaden, Protokoll protokoll, Schaden.EnumStatus status)
        {
            if (status > 0)
            {
                schaden.Status = status;
            }

            protokoll.LetzteBearbeitung = DateTime.Now;
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

        public ObservableCollection<SchadenCellViewModel> ReadSchadenListe(string sucheText, bool nurPendente)
        {
            var alleSchaeden = _dataBase.GetSchaeden();

            var schadensAuswahlListe = new ObservableCollection<SchadenCellViewModel>();

            foreach (var schaden in alleSchaeden)
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (!nurPendente || nurPendente && schaden.Status < Schaden.EnumStatus.Aufgenommen)
                {
                    if (string.IsNullOrEmpty(sucheText) || schaden.Ort.ToUpper().Contains(sucheText.ToUpper()) || schaden.Beschreibung.ToUpper().Contains(sucheText.ToUpper()))
                    {
                        schadensAuswahlListe.Add(new SchadenCellViewModel(schaden));
                    }
                }
            }
            return schadensAuswahlListe;
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

using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using ZeusMobile.Models;

namespace ZeusMobile.Data
{
    public class DataBase
    {
        static object locker = new object();

        SQLiteConnection database;

        public DataBase(SQLiteConnection conn)
        {
            database = conn;

            database.CreateTable<Person>();
            database.CreateTable<Versicherter>();
            database.CreateTable<Sachbearbeiter>();
            database.CreateTable<Police>();
            database.CreateTable<Schaden>();
            database.CreateTable<Protokoll>();
            database.CreateTable<Objekt>();
        }

        public List<Person> GetSubjekte()
        {
            lock (locker)
            {
                return (from i in database.Table<Person>() select i).ToList();
            }
        }

        public Person GetSubject(int subjectId)
        {
            lock (locker)
            {
                return database.Find<Person>(x => x.Id == subjectId);
            }
        }

        public List<Versicherter> GetVersicherte()
        {
            lock (locker)
            {
                return (from i in database.Table<Versicherter>() select i).ToList();
            }
        }

        public Versicherter GetVersicherter(int versicherterId)
        {
            lock (locker)
            {
                return database.Find<Versicherter>(x => x.Id == versicherterId);
            }
        }

        public List<Sachbearbeiter> GetSchadensExperten()
        {
            lock (locker)
            {
                return (from i in database.Table<Sachbearbeiter>() select i).ToList();
            }
        }

        public List<Protokoll> GetSchadenProtokolle()
        {
            lock (locker)
            {
                return (from i in database.Table<Protokoll>() select i).ToList();
            }
        }

        public Protokoll GetSchadenProtokoll(int schadenId)
        {
            lock (locker)
            {
                return database.Find<Protokoll>(x => x.SchadenId == schadenId);
            }
        }


        public List<Police> GetPolicen()
        {
            lock (locker)
            {
                return (from i in database.Table<Police>() select i).ToList();
            }
        }

        public Police GetPolice(int schadenId)
        {
            lock (locker)
            {
                return database.Find<Police>(x => x.Id == schadenId);
            }
        }


        public List<Schaden> GetSchaeden()
        {
            lock (locker)
            {
                return (from i in database.Table<Schaden>() select i).ToList();
            }
        }

        public Schaden GetSchaden(int schadenId)
        {
            lock (locker)
            {
                return database.Find<Schaden>(x => x.Id == schadenId);
            }
        }


        public List<Objekt> GetVersicherungsobjekte()
        {
            lock (locker)
            {
                return (from i in database.Table<Objekt>() select i).ToList();
            }
        }

        public void InsertOrReplaceAllSubjectsWithChildren(List<Person> items)
        {
            database.InsertOrReplaceAllWithChildren(items);
        }

        public void InsertOrReplaceAllVersicherteWithChildren(List<Versicherter> items)
        {
            database.InsertOrReplaceAllWithChildren(items);
        }

        public void InsertOrReplaceAllSchaedenWithChildren(List<Schaden> items)
        {
            database.InsertOrReplaceAllWithChildren(items);
        }
        public void InsertOrReplaceSchadenWithChildren(Schaden schaden)
        {
            database.InsertOrReplaceWithChildren(schaden);
        }

        public void InsertOrReplaceAllPolicenWithChildren(List<Police> items)
        {
            database.InsertOrReplaceAllWithChildren(items);
        }

        public void SaveSchaden(Schaden schaden)
        {
            lock (locker)
            {
                if (schaden.Id == 0)
                {
                    database.Insert(schaden);
                }
                else
                { 
                    database.InsertOrReplace(schaden);
                }
               
            }
        }

        public void SaveProtokoll(Protokoll protokoll)
        {
            lock (locker)
            {
                if (protokoll.Id == 0)
                {
                    database.Insert(protokoll);
                }
                else
                {
                    database.InsertOrReplace(protokoll);
                }

            }
        }
        public void DeleteProtokoll(Protokoll protokoll)
        {
            lock (locker)
            {
                database.Delete(protokoll);
            }
        }

        public Protokoll GetProtokollBySchadenNr(int schadenId)
        {
            lock (locker)
            {
                return database.Find<Protokoll>(x => x.SchadenId == schadenId);
            }
        }
    }
}


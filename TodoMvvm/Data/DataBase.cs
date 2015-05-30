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

            database.CreateTable<Subject>();
            database.CreateTable<Versicherter>();
            database.CreateTable<SchadensExperte>();
            database.CreateTable<Police>();
            database.CreateTable<Schaden>();
            database.CreateTable<SchadenProtokoll>();
            database.CreateTable<Versicherungsobjekt>();
        }

        public List<Subject> GetSubjekte()
        {
            lock (locker)
            {
                return (from i in database.Table<Subject>() select i).ToList();
            }
        }

        public Subject GetSubject(int subjectId)
        {
            lock (locker)
            {
                return database.Find<Subject>(x => x.Id == subjectId);
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

        public List<SchadensExperte> GetSchadensExperten()
        {
            lock (locker)
            {
                return (from i in database.Table<SchadensExperte>() select i).ToList();
            }
        }

        public List<SchadenProtokoll> GetSchadenProtokolle()
        {
            lock (locker)
            {
                return (from i in database.Table<SchadenProtokoll>() select i).ToList();
            }
        }

        public SchadenProtokoll GetSchadenProtokoll(int schadenId)
        {
            lock (locker)
            {
                return database.Find<SchadenProtokoll>(x => x.Id == schadenId);
            }
        }


        public List<Police> getPolicen()
        {
            lock (locker)
            {
                return (from i in database.Table<Police>() select i).ToList();
            }
        }

        public Police getPolice(int schadenId)
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

        public List<Versicherungsobjekt> getVersicherungsobjekte()
        {
            lock (locker)
            {
                return (from i in database.Table<Versicherungsobjekt>() select i).ToList();
            }
        }

        public void InsertOrReplaceAllSubjectsWithChildren(List<Subject> items)
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

        public void InsertOrReplaceAllPolicenWithChildren(List<Police> items)
        {
            database.InsertOrReplaceAllWithChildren(items);
        }


        public int SaveSchaden(Schaden item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                return database.Insert(item);
            }
        }

    }
}


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

        public List<Subject> GetSubjects()
        {
            lock (locker)
            {
                return (from i in database.Table<Subject>() select i).ToList();
            }
        }

        public List<Versicherter> GetVersicherte()
        {
            lock (locker)
            {
                return (from i in database.Table<Versicherter>() select i).ToList();
            }
        }

        public IEnumerable<SchadensExperte> GetSchadensExperten()
        {
            lock (locker)
            {
                return (from i in database.Table<SchadensExperte>() select i).ToList();
            }
        }
        
        public IEnumerable<SchadenProtokoll> GetSchadenProtokolle()
        {
            lock (locker)
            {
                return (from i in database.Table<SchadenProtokoll>() select i).ToList();
            }
        }


        public List<Police> getPolicen()
        {
            lock (locker)
            {
                return (from i in database.Table<Police>() select i).ToList();
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
        


        public IEnumerable<Schaden> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Schaden>() select i).ToList();
            }
        }

        public IEnumerable<Schaden> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<Schaden>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            }
        }

        public Schaden GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Schaden>().FirstOrDefault(x => x.Id == id);
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

        public int InsertSubjects(List<Subject> items)
        {
            return database.InsertAll(items, typeof(Subject));
        }

        public int SaveVersicherte(List<Versicherter> items)
        {
            return database.InsertAll(items, typeof(Versicherter));
        }

        public int SaveSchadensExperten(List<SchadensExperte> items)
        {
            return database.InsertAll(items, typeof(SchadensExperte));
        }

        public int SavePolicen(List<Police> polices)
        {
            return database.InsertAll(polices, typeof(Police));
        }

        public int SaveVersicherungsObjekte(List<Versicherungsobjekt> Versicherungsobjekte)
        {
            return database.InsertAll(Versicherungsobjekte, typeof(Versicherungsobjekt));
        }

        public int SaveSchaeden(List<Schaden> schaedenList)
        {
            return database.InsertAll(schaedenList, typeof(Schaden));
        }

        public int SaveProtokolle(List<SchadenProtokoll> schaedenList)
        {
            return database.InsertAll(schaedenList, typeof(SchadenProtokoll));
        }

        public int Save(List<Object> dataList, Type modelType)
        {
            return database.InsertAll(dataList, modelType);
        }


        public int SaveItem(Schaden item)
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

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Schaden>(id);
            }
        }


    }
}


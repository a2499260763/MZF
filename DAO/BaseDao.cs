using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EF;
using System.Runtime.Remoting.Messaging;
using Log4;

namespace DAO
{
    public class DaoBase<T> where T : class
        {
            //MyDbContext db = new MyDbContext();

            public static MyDbContext CreateContext()
            {
            
                MyDbContext db = CallContext.GetData("s") as MyDbContext;
           
                if (db == null)
                {
                    db = new MyDbContext();
                    CallContext.SetData("s", db);
                }
            
            
                return db;
            }
            
            public int Add(T t)
            {
                MyDbContext db = CreateContext();
                db.Set<T>().Add(t);
                return db.SaveChanges();
            }

            public int Update(T t)
            {
                MyDbContext db = CreateContext();
                db.Set<T>().Attach(t);
                db.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }

            public int Delete(T t)
            {
                MyDbContext db = CreateContext();
                db.Set<T>().Attach(t);
                db.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();

            }

            public List<T> Select()
            {
                MyDbContext db = CreateContext();
                return db.Set<T>()
                       .AsNoTracking()
                       .Select(e => e)
                       .ToList();
            }

          
        }
    }

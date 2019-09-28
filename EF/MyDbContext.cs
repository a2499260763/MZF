using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;

namespace EF
{
   public class MyDbContext:DbContext
    {
        public MyDbContext():base("sql1")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Entity.MajorKind> MajorKind { get; set; }

        public DbSet<Entity.MajorChen> MajorChen { get; set; }

        public DbSet<Entity.Major> Major { get; set; }
    }
}

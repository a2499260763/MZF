using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Configer;
using EF.Entity;
using System.Reflection;

namespace EF
{
   public class MyDbContext:DbContext
    {
        public MyDbContext():base("sql")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Configurations.Add(new StudentConfiger());
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        //public DbSet<Student> Student { get; set; }
        public DbSet<oneorganization> oneorganization { get; set; }
        public DbSet<twoorganization> twoorganization { get; set; }
        public DbSet<threeorganization> threeorganization { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EnumClasses
{
    class MyDatabase : DbContext
    {
        public MyDatabase():base("ONOMA")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }
    }
}

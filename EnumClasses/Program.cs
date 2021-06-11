using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //MoviesPerActor();

            MyDatabase db = new MyDatabase();

            var MoviesPerActorWithDate = db.MovieActors.GroupBy(x => x.Actor).Where(x=>x.Key.Name == "DiCaprio").ToList();


            foreach (var item in MoviesPerActorWithDate)
            {
                Console.WriteLine(item.Key.Name);
                Console.WriteLine("\t\t");
                foreach (var x in item)
                {
                    Console.WriteLine(x.Movie.Title + " "+ x.ContractDate.Year);
                }
                
            
            }

            Console.WriteLine("--------------------------------------------------------");



        }

        private static void MoviesPerActor()
        {
            MyDatabase db = new MyDatabase();
            //var kati = from movie in db.Movies
            //           from actor in db.Actors
            //           select new
            //           {
            //               movieTitle = movie.Title,
            //               actorName = actor.Name
            //           };

            //Console.WriteLine("All actors with all movies");
            //foreach (var item in kati)
            //{
            //    Console.WriteLine($"{item.movieTitle,-15} {item.actorName,-15}");
            //}


            var moviesperactors = db.MovieActors.ToList();

            //var movsperacts = db.MovieActors.ToList();

            var foo = from x in moviesperactors
                      group x.Movie by x.Actor into y
                      select y;



            foreach (var item in foo)
            {
                Console.WriteLine(item.Key.Name);
                foreach (var g in item)
                {
                    Console.WriteLine("\t\t");
                    Console.WriteLine(g.Title);
                }
            }
        }
        static void Dicts()
        {
            //Student s1 = new Student() { StudentId = 5, Name = "S1", Country = Country.France};
            //Student s2 = new Student() { StudentId = 6, Name = "S2" };
            //Student s3 = new Student() { StudentId = 7, Name = "S3" };
            //Student s4 = new Student() { StudentId = 8, Name = "S4" };
            //Student s5 = new Student() { StudentId = 9, Name = "S5" };

            //Dictionary<int, Student> dict = new Dictionary<int, Student>();

            //dict.Add(s1.StudentId, s1);
            //dict.Add(s2.StudentId, s2);
            //dict.Add(s3.StudentId, s3);
            //dict.Add(s4.StudentId, s4);
            //dict.Add(s5.StudentId, s5);

            //foreach (var item in dict)
            //{
            //    Console.WriteLine(item.Value.Name);
            //    Console.WriteLine(item.Value.Country);
            //} 

            // foreach (var item in dict)
            //{
            //    Console.WriteLine(item.Key);
            //}

            //dict.Remove(s5.StudentId);


            //if (!(dict.ContainsKey(9)))
            //{
            //    dict.Add(9, new Student() { Name = "Ninenth" });
            //}


            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("-----------------------------------");


            //Dictionary<string, string> foo = new Dictionary<string, string>();

            //foo.Add("en", "UK");
            //foo.Add("gr", "Greece");

            //Console.WriteLine(foo["gr"]); //Greece

            //foreach (var item in foo)
            //{
            //    Console.WriteLine(item.Key+ " " + item.Value);
            //}

            //Dictionary<int, string> foo2 = new Dictionary<int, string>();

            //foo2.Add(12345, "George");

            //Dictionary<int, Student> foo3 = new Dictionary<int, Student>();
            //foo3.Add(123, new Student() { StudentId = 1, Country = Country.Greece, Name = "Nikos" });


            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("-----------------------------------");





            //MyDatabase db = new MyDatabase();

            //var students = db.Students.ToList();
            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Name {student.Name} - Country: {student.Country}");
            //}

            //Console.WriteLine("-----------------------------------");

            //var something = from stu in students
            //                group stu.Name by stu.Country into Foo
            //                select new { Country = Foo.Key, Names = Foo.ToList(), };


            //foreach (var item in something)
            //{
            //    Console.WriteLine(item.Country + " " + item.Names.Count()); ;
            //}

            //Console.WriteLine("-----------------------------------");

            //foreach (var item in something)
            //{
            //    Console.WriteLine(item.Country);
            //    foreach (var name in item.Names)
            //    {
            //        Console.WriteLine("\t\t");
            //        Console.WriteLine(name);
            //    }
            //}

            //Console.WriteLine("-----------------------------------");

            //var studentsByCountry = from stu in students
            //                group new { Name = stu.Name, id = stu.StudentId } by stu.Country into Foo
            //                select new { Country = Foo.Key, Names = Foo.ToList() };






            //Console.WriteLine("----------------------");
            //foreach (var item in studentsByCountry)
            //{
            //    Console.WriteLine($"Country: {item.Country}");
            //    foreach (var x in item.Names)
            //    {
            //        Console.WriteLine($"Id: {x.id} Name: {x.Name}");
            //    }
            //}



        }
    }

    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }
    }
    public enum Country
    {
        Greece,
        France,
        USA
    }
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }

    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }

    public class MovieActor
    {
        public string Serial { get; set; }
        public DateTime ContractDate { get; set; }

        [Key, Column(Order = 0)]
        public int MovieId { get; set; }
        [Key, Column(Order = 1)]
        public int ActorId { get; set; }

        //Navigation Properties
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }

}

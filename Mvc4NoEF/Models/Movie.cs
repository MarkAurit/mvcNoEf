using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc4NoEF.Models
{
    public class Movie : IMovieRepository
    {
        [Required]
        public int MovieID { get; set; }

        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool FamilyFriendly { get; set; }

        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        public Movie() { }

        public Movie(int id, string name, string email, string movieAbstract)
        {
            this.MovieID = id;
            this.Name = name;
            this.Abstract = movieAbstract;
            this.Email = email;
        }

        public void Save(Movie movie)
        {
            
        }

        public Movie Get(int? id)
        {
            Movie mo = new Movie(
                1,
                "Nada Movie",
                "ko@knock.com",
                "now is the time for all good men"

            );
            return mo;
        }

        public IEnumerable<Movie> GetMovies()
        {
            List<Movie> lmo = new List<Movie>();
            Movie mo = new Movie(
                1,
                "Nada Movie",
                "ko@knock.com",
                "now is the time for all good men"

            );
            lmo.Add(mo);
            Movie mo2 = new Movie(
                2,
                "Super Man",
                "jimmy@knock.com",
                "stay away from the green rock"

            );
            lmo.Add(mo2);
            return lmo;
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4NoEF.Models
{
    interface IMovieRepository
    {
        int MovieID { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        bool FamilyFriendly { get; set; }
        string Abstract { get; set; }
        Movie Get(int? id);
        void Save(Movie movie);
        IEnumerable<Movie> GetMovies();
        //void Movie();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

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

        public Movie(int id, string name, string email, string movieAbstract, int familyFriendly=1)
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
                "now is the time for all good men",
                1

            );
            return mo;
        }

        public IEnumerable<Movie> GetMovies()
        {
            List<Movie> lmo = new List<Movie>();
            using (var reader = DataAccessLayer.GetReader("pMoviesGet"))
            {
                while (reader.Read())
                {
                    lmo.Add(new Movie(
                        reader.GetInt32(0)
                        , reader[1].ToString()
                        , reader[2].ToString()
                        , reader[3].ToString()
                        //,dr.GetInt16(4)
                        ));
                }
            }
            return lmo;
        }

        public IEnumerable<Movie> GetMoviesOld()
        {
            List<Movie> lmo = new List<Movie>();
            //Movie mo = new Movie(
            //    1,
            //    "Nada Movie",
            //    "ko@knock.com",
            //    "now is the time for all good men"

            //);
            //lmo.Add(mo);
            //Movie mo2 = new Movie(
            //    2,
            //    "Super Man",
            //    "jimmy@knock.com",
            //    "stay away from the green rock"

            //);
            //lmo.Add(mo2);
            SqlDataReader dr = null;
            using (var reader = DataAccessLayer.GetReader("pMoviesGet"))
            {
                //dr = StaticsDb.AsSqlDataReader(dr);
                dr = (SqlDataReader)((RefCountingDataReader)reader).InnerReader;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lmo.Add(new Movie(
                            dr.GetInt32(0)
                            ,dr[1].ToString()
                            ,dr[2].ToString()
                            ,dr[3].ToString()
                            //,dr.GetInt16(4)
                            ));
                    }
                }
            }
            return lmo;
        }
    }




}
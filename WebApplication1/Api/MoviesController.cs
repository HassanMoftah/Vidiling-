using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidiling.Models;
using Vidiling.Dtos;
using AutoMapper;

namespace Vidiling.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //Get api/movies
        public IHttpActionResult GetCustomer()
        {
            var ss= _context.Movies.Include(m=>m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(ss);
        }
        //Get api/movies/1
        public IHttpActionResult GetMovie (int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //post api/movies
        [HttpPost]
        public IHttpActionResult CreateMoive(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            moviedto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviedto);

        }

        [HttpPut]
        public void UpdateMovie(int Id,MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(moviedto,movie);
         
            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var movieindb = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (movieindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieindb);
            _context.SaveChanges();

        }
    }
}

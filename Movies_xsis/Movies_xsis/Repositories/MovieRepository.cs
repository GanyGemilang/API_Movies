using Microsoft.EntityFrameworkCore;
using Movies_xsis.Entities;
using System;

namespace Movies_xsis.Repositories
{
    public class MovieRepository
    {
        private readonly DbtestContext _dbtestContext;

        // Constructor
        // Inject AppDbContext inside the constructor to make access to the AppDbContext 
        public MovieRepository(DbtestContext dbtestContext)
        {
            _dbtestContext = dbtestContext;
        }

        public async Task<List<Movie>> ListMovie()
        {
            return await _dbtestContext.Movies.OrderBy(m => m.Id).ToListAsync();
        }
        public async Task<Movie> MovieById(int id)
        {
            Movie dataMovie = await _dbtestContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if(dataMovie != null)
            {
                return dataMovie;
            }
            else
            {
                return null; 
            }
            
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            if (movie is not null)
            {
                await _dbtestContext.Movies.AddAsync(movie);
                await _dbtestContext.SaveChangesAsync();

                return movie;
            }
            else
            {
                return null;
            }
        }
        public async Task<Movie> EditMovie(Movie movie)
        {
            var movieDetail = await MovieById(movie.Id);
            if (movieDetail is not null && movie is not null)
            {
                // AutoMapper or Mapster or any kind of function that 
                // could map these properties must be used
                movieDetail.Title = movie.Title;
                movieDetail.Description = movie.Description;    
                movieDetail.Rating = movie.Rating;
                movieDetail.Image = movie.Image;
                movieDetail.UpdatedAt = movie.UpdatedAt;
                await _dbtestContext.SaveChangesAsync();
            }
            return movie;
        }
        public async Task<bool> Delete(int id)
        {
            var movie = await MovieById(id);
            if (movie is not null)
            {
                _dbtestContext.Movies.Remove(movie);
                _dbtestContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

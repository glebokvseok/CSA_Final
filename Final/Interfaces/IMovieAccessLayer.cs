using System.Collections.Generic;
using System.Threading.Tasks;
using Final.Models;

namespace Final.Interfaces; 

public interface IMovieAccessLayer {
    public Task<bool> CheckMovieExistence(int id);
    public Task<IEnumerable<Movie>> GetMovies();
}
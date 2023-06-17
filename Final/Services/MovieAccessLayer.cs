using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Final.Interfaces;
using Final.Models;
using Npgsql;

namespace Final.Services; 

public class MovieAccessLayer : DataAccessLayer, IMovieAccessLayer {
    public MovieAccessLayer(string host, string port, string database, string user, string password, string table)
        : base(host, port, database, user, password) => _moviesTableName = table;

    public async Task<bool> CheckMovieExistence(int id) {
        var request = $"SELECT COUNT(1) FROM {_moviesTableName} WHERE id = @id;";
        await using var connection = new NpgsqlConnection(ConnectionString);
        return (await connection.QueryAsync<int>(request, new {id})).FirstOrDefault() == 1;
    }
    
    public async Task<IEnumerable<Movie>> GetMovies() {
        var request = $"SELECT * FROM {_moviesTableName}";
        var connection = new NpgsqlConnection(ConnectionString);
        var movies = (await connection.QueryAsync<Movie>(request))?.ToList();
        if (movies is null) {
            return new List<Movie>();
        }
        
        foreach (var movie in movies) {
            movie.GenreName = movie.Genre.ToString();
        }

        return movies;
    }

    private readonly string _moviesTableName;
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Final.Interfaces;
using Final.Models;
using Npgsql;

namespace Final.Services; 

public class ShowTimeAccessLayer : DataAccessLayer, IShowTimeAccessLayer {
    public ShowTimeAccessLayer(string host, string port, string database, string user, string password, string table)
        : base(host, port, database, user, password) => _showTimesTableName = table;
    
    public async Task<bool> CheckShowTimeExistence(int id) {
        var request = $"SELECT COUNT(1) FROM {_showTimesTableName} WHERE id = @id;";
        await using var connection = new NpgsqlConnection(ConnectionString);
        return (await connection.QueryAsync<int>(request, new {id})).FirstOrDefault() == 1;
    }

    public async Task<IEnumerable<ShowTime>> GetShowTimes() {
        var request = $"SELECT id, film_name AS filmName, date, film_id as filmId FROM {_showTimesTableName}";
        var connection = new NpgsqlConnection(ConnectionString);
        var showTimes = (await connection.QueryAsync<ShowTime>(request))?.ToList();
        return showTimes ?? new List<ShowTime>();
    }

    private readonly string _showTimesTableName;
}
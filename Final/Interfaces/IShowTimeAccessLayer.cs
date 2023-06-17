using System.Collections.Generic;
using System.Threading.Tasks;
using Final.Models;

namespace Final.Interfaces; 

public interface IShowTimeAccessLayer {
    public Task<bool> CheckShowTimeExistence(int id);
    public Task<IEnumerable<ShowTime>> GetShowTimes();
}
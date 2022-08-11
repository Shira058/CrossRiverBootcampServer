using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public interface ILocationDal
{
    Task<List<Location>> getAllLocation();
    Task<int> addNewLocation(Location newLocation);
    Task<List<Location>> getLocationsByPatientId(string id);
     Task<List<Location>> getAllLocationByCity(string city);
    public Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates);
    public Task<List<Location>> getAllLocationByAge(LocationSearch age);
    public Task<bool> deleteLocation(int id);

}
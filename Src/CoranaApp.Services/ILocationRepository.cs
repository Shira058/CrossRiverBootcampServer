using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services;
public interface ILocationRepository
{
    public Task<List<LocationDTO>> getAllLocation();
    public Task<List<Location>> getLocationsByPatientId(string id);
    public Task<int> addNewLocation(Location newLocation);
    public Task<List<Location>> getAllLocationByCity(string city);
    public Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates);
    public Task<List<Location>> getAllLocationByAge( LocationSearch age);
}

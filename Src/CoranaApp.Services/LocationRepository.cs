using CoronaApp.Dal.Models;
using CoronaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public class LocationRepository : ILocationRepository
{
    ILocationDal _LocationDal;
    public LocationRepository(ILocationDal LocationDal)
    {
        _LocationDal = LocationDal;
    }

    public async Task<List<LocationDTO>> getAllLocation()
    {
        var result = await _LocationDal.getAllLocation();
        var locationDTOList = result.Select(l => new LocationDTO(l.Id,l.StartDate, l.EndDate,l.City,l.Address)).ToList();
        return locationDTOList;
    }

    public async Task<List<Location>> getLocationsByPatientId(string id)
    {
        return await _LocationDal.getLocationsByPatientId(id);
    }

    public async Task<List<LocationDTO>> getAllLocationByCity(string city)
    {
        var result = await _LocationDal.getAllLocationByCity(city);
        var locationDTOList = result.Select(l => new LocationDTO(l.Id, l.StartDate, l.EndDate, l.City, l.Address)).ToList();
        return locationDTOList;
    }

    public async Task<int> addNewLocation(Location newLocation)
    {
        return await _LocationDal.addNewLocation(newLocation);
    }

    public async Task<List<LocationDTO>> getAllLocationBetweenDates(LocationSearch dates)
    {
        var result = await _LocationDal.getAllLocationBetweenDates(dates);
        var locationDTOList = result.Select(l => new LocationDTO(l.Id, l.StartDate, l.EndDate, l.City, l.Address)).ToList();
        return locationDTOList;
    }

    public async Task<List<LocationDTO>> getAllLocationByAge(LocationSearch age)
    { 
       var result = await _LocationDal.getAllLocationByAge(age);
        var locationDTOList = result.Select(l => new LocationDTO(l.Id, l.StartDate, l.EndDate, l.City, l.Address)).ToList();
        return locationDTOList;
    }

}

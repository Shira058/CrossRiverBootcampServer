using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public class LocationDal : ILocationDal
{
    public async Task<List<Location>> getAllLocation()
    {
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            return await _CoronaAppDBContext.Locations.ToListAsync();
        }
    }

    public async Task<List<Location>> getLocationsByPatientId(string id)
    {
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            return await _CoronaAppDBContext.Locations.Where(location => location.Patient.Id.CompareTo(id) == 0).ToListAsync();
        }
    }

    public async Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates)
    {
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            return await _CoronaAppDBContext.Locations.Where(location => DateTime.Compare(dates.StartDate, location.StartDate) <= 0 && DateTime.Compare(dates.EndDate, location.EndDate) >= 0).ToListAsync();
        }
    }

    public async Task<List<Location>> getAllLocationByCity(string city)
    {
        if (city == null)
        {
            throw new ArgumentNullException("city");
        }
        else
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                return await _CoronaAppDBContext.Locations.Where(location => location.City.Contains(city)).ToListAsync();
            }
        }
    }

    public async Task<List<Location>> getAllLocationByAge(LocationSearch age)
    {
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            return await _CoronaAppDBContext.Locations.Include(location => location.Patient)
            .Where(location => location.Patient.Age == age.Age).ToListAsync();
        }

    }
    public async Task<int> addNewLocation(Location newLocation)
    {
        try
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                await _CoronaAppDBContext.Locations.AddAsync(newLocation);
                await _CoronaAppDBContext.SaveChangesAsync();
            }
            return newLocation.Id;
        }
        catch (Exception)
        {
            throw new Exception("internal error with SaveChangesAsync function");
        }

    }
    public async Task<bool> deleteLocation(int id)
    {
        try
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
               var locationToDeleted = await _CoronaAppDBContext.Locations.FindAsync(id);
                if (locationToDeleted != null)
                {
                    _CoronaAppDBContext.Locations.Remove(locationToDeleted);
                    await _CoronaAppDBContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception)
        {
            throw new Exception("internal error with SaveChangesAsync function");
        }
    }

}
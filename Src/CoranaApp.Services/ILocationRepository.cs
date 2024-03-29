﻿using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Services;
public interface ILocationRepository
{
    public Task<List<Location>> getAllLocation();
    public Task<List<Location>> getLocationsByPatientId(ClaimsPrincipal User);
    public Task<int> addNewLocation(Location newLocation);
    public Task<List<Location>> getAllLocationByCity(string city);
    public Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates);
    public Task<List<Location>> getAllLocationByAge( LocationSearch age);
}

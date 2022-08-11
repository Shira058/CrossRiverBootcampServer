using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Api.Controllers;

//[Authorize(Roles = "user")]
[Route("[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    ILocationRepository _LocationRepository;

    public LocationController(ILocationRepository LocationRepository)
    {
        _LocationRepository = LocationRepository;
    }

    // GET:
    [HttpGet]
    public async Task<ActionResult<List<Location>>> getAllLocation()
    {
        var result = await _LocationRepository.getAllLocation();
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Location>>> getLocationsByPatientId(string id)
    {
        var result = await _LocationRepository.getLocationsByPatientId(id);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpGet("city")]
    public async Task<ActionResult<List<Location>>> getAllLocationByCity([FromQuery] string city)
    {
        if (city == null)
        {
            throw new ArgumentNullException("city");
        }

        var result = await _LocationRepository.getAllLocationByCity(city);

        if (result == null)
        {
            return StatusCode(404, "not found");
        }

        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }

        return Ok(result);
    }

    // GET:
    [HttpPost("dates")]
    public async Task<ActionResult<List<Location>>> getAllLocationBetweenDates([FromBody] LocationSearch dates)
    {
        if (dates == null)
        {
            throw new ArgumentNullException("LocationSearch by dates");
        }
        if (dates.StartDate == null)
        {
            dates.StartDate = DateTime.Now;
        }
        if (dates.EndDate == null)
        {
            dates.EndDate = DateTime.Now;
        }
        if (DateTime.Compare(dates.StartDate, dates.EndDate) < 0)
        {
            return StatusCode(500, "not a valid argument");
        }

        var result = await _LocationRepository.getAllLocationBetweenDates(dates);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpPost("age")]
    public async Task<ActionResult<List<Location>>> getAllLocationByAge([FromBody] LocationSearch age)
    {
        if (age == null || age.Age == null)
        {
            throw new ArgumentNullException("LocationSearch by age");
        }
        var result = await _LocationRepository.getAllLocationByAge(age);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // POST:
    [HttpPost]
    public async Task<ActionResult<int>> addNewLocation([FromBody] Location newLocation)
    {
        if (newLocation == null)
        {
            throw new ArgumentNullException("new Location");
        }
        if (DateTime.Compare(newLocation.StartDate, newLocation.EndDate) < 0)
        {
            throw new Exception("not a valid argument");
        }

        var result = await _LocationRepository.addNewLocation(newLocation);
        
        if (result == 0)
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> deleteLocation(int id)
    {
        if (id == 0)
        {
            throw new ArgumentNullException("delete Location id");
        }
        
        var result = await _LocationRepository.deleteLocation(id);
        if (result == false)
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);

    }


}
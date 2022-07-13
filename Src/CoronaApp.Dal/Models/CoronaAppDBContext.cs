﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class CoronaAppDBContext:DbContext
    {
        public CoronaAppDBContext(DbContextOptions<CoronaAppDBContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Location> Locations { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sample.Models;

public class SampleDbCotext : DbContext
{
    public SampleDbCotext(DbContextOptions<SampleDbCotext> options)
            : base(options)
    {
    }
    public static string ConfigPath { get; set; } = null!;

    public DbSet<Userdata> User { get; set; }

}
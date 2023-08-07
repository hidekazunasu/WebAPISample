using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sample.Models;

public class Userdata
{
    public string? ID { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }
}
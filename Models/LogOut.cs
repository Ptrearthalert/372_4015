using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Logout
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

}

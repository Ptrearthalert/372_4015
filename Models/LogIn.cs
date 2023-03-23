using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class LogIn
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

}

using System;
using System.Collections.Generic;

namespace Student_BusinessObjects;

public partial class Account
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }
}

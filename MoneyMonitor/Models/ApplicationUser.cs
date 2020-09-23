﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMonitor.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Wealth> Wealths { get; internal set; }
    }
}

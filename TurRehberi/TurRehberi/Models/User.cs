﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurRehberi.Models
{
    public class User : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

    }
}

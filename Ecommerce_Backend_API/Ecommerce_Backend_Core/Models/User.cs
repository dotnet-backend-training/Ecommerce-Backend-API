﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Core.Models
{
    public class User : IdentityUser
    {
        [ForeignKey(nameof(Government))]
        public int GovernmentId {  get; set; }

        public Government Government { get; set; }

    }
}

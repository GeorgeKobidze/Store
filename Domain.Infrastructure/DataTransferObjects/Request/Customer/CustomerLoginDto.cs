﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.DataTransferObjects.Customer
{
    public class CustomerLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

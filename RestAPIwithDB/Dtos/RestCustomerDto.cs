﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIwithDB.Dtos
{
    public class RestCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
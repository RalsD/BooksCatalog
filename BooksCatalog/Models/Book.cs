﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime RegistrationTimeStamp { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
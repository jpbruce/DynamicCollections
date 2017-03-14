﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCollections.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
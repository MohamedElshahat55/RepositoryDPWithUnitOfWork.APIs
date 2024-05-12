﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDPWithUnitOfWork.Core.Models
{
    public class Book : BaseModel
    {
        [Required, MaxLength(100)]
       
        public string Name { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

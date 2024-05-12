using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDPWithUnitOfWork.Core.Models
{
    public class Author : BaseModel
    {
        [Required, MaxLength(50)]
        public string Title { get; set; }
    }
}

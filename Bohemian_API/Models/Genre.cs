using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Models
{
    public class Genre
    {
        [Key]
        public int Genre_Id { get; set; }
        public string Genre_Name { get; set; }
    }
}

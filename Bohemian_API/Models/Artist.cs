using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Models
{
    public class Artist
    {
        [Key]
        public int Artist_Id { get; set; }
        public string Artist_Name { get; set; }
    }
}

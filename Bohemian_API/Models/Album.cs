using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Models
{
    public class Album
    {
        [Key]
        public int Album_Id { get; set; }
        public string Album_Title { get; set; }
        
        [ForeignKey("Artist")]
        public int Artist_Id { get; set; }
        public Artist Artist { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Models
{
    public class Song
    {
        [Key]
        public int Song_Id { get; set; }
        public string Song_Title { get; set; }
        public string Song_Length { get; set; }

        [ForeignKey("Album")]
        public int Album_Id { get; set; }
        public Album Album { get; set; }

        [ForeignKey("Genre")]
        public int Genre_Id { get; set; }
        public Genre Genre { get; set; }

    }
}

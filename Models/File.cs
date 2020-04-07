using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Models
{[Table("Yoga")]
    public class File
    {[Key]
        public int Yid{ get; set; }
        [Required]
        public string Yoganame { get; set; }
        [Required]
        public string photo { get; set; }
    }
}

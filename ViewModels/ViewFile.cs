using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.ViewModels
{
    [Table("Yoga")]
    public class ViewFile
    {
        [Key]
        public int Yid { get; set; }
        [Required]
        public string Yoganame { get; set; }
      
        public IFormFile formFile { get; set; }
    }
}

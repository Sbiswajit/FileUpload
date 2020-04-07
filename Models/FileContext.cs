using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class FileContext : DbContext
    {
        public FileContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<File> yogas { get; set; }
    }
}

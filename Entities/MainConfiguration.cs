using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MainConfiguration
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string? InstaUrl { get; set; }
        [MaxLength(300)]
        public string? FaceUrl { get; set; }
        [MaxLength(300)]
        public string? PhoneNumber { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}

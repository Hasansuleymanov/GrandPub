using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        [MaxLength(1500)]
        public string? Description { get; set; }
        public string? Size { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public virtual Category? Category { get; set; }
        public string? ThumbnailUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}

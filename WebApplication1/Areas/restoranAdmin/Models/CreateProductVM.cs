namespace WebMVC.Areas.restoranAdmin.Models
{
    public class CreateProductVM
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Size { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsDeleted { get; set; }

    }
}

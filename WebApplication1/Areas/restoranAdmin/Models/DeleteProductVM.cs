namespace WebMVC.Areas.restoranAdmin.Models
{
    public class DeleteProductVM
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ThumbnailUrl { get; set; }

    }
}

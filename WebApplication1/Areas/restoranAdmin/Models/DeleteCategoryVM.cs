namespace WebMVC.Areas.restoranAdmin.Models
{
    public class DeleteCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsDefault { get; set; }
    }
}

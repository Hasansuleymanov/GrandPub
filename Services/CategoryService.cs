using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories.Where(c=>!c.IsDeleted).ToList();
        }
        public Category? GetByID(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public int GetCategoryCount()
        {
            return _context.Categories.Count();
        }
        public void Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }
        public void Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }
        public void Delete(Category category)
        {
            category.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}

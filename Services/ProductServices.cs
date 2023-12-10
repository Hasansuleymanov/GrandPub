using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices
    {
        private readonly ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include(c=>c.Category).Where(c => !c.IsDeleted).ToList();
        }

        public List<Product>GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(c=>!c.IsDeleted && c.CategoryId == categoryId).ToList();
        }

        public List<Product>? GetProductsByCategorySlug(string? slug)
        {
            Category? findCategory = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (findCategory != null && !string.IsNullOrWhiteSpace(slug))
            {
                return _context.Products.Where(c => c.CategoryId == findCategory.Id).ToList();
            }
            else
            {
                Category defaultCategory = _context.Categories.First(c => c.IsDefault);
                return _context.Products.Where(c=>c.CategoryId==defaultCategory.Id).ToList();
            }
        }

        public Product? GetByID(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            product.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}

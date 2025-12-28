using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Sitem.Web.Models;

namespace Sitem.Web.Services
{
    public class BlogService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _jsonFilePath;

        public BlogService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _jsonFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Data", "blog_posts.json");
        }

        private List<BlogPost> GetPosts()
        {
            if (!File.Exists(_jsonFilePath))
            {
                return new List<BlogPost>();
            }

            var json = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<List<BlogPost>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BlogPost>();
        }

        public List<BlogPost> GetAllPosts()
        {
            return GetPosts().OrderByDescending(p => p.PublishDate).ToList();
        }

        public BlogPost GetPostBySlug(string slug)
        {
            return GetPosts().FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
        }

        public List<BlogPost> GetPopularPosts(int count)
        {
            return GetPosts().OrderByDescending(p => p.ViewCount).Take(count).ToList();
        }

        public List<KeyValuePair<string, int>> GetCategories()
        {
            return GetPosts()
                .GroupBy(p => p.Category)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .OrderByDescending(x => x.Value)
                .ToList();
        }
        
         public List<BlogPost> GetPostsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category) || category.ToLower() == "all")
            {
                return GetAllPosts();
            }
            return GetPosts().Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).OrderByDescending(p => p.PublishDate).ToList();
        }
    }
}

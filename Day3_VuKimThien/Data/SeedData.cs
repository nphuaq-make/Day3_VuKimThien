using Day3_VuKimThien.Models;

namespace Day3_VuKimThien.Data

{
    public class SeedData
    {
        //Gia lap du lieu ban dau cho data
        public static List<Models.Category> categories = new List<Models.Category>
        {
            new Category() { Id = 1, Name = "Iphone ku ki", Description = "Description 1" },
            new Category() { Id = 2, Name = "Android ba bi", Description = "Description 2" },
            new Category() { Id = 3, Name = "Mac mo bi", Description = "Description 3" },

        };
        public static List<Models.Product> Products = new List<Models.Product>
        {
            new Models.Product()
            {
                Id = 1,
                Name = "iPhone 16 Pro Max",
                Price = 34990000,
                Description = "Điện thoại Apple cao cấp, camera chuyên nghiệp.",
                CategoryId = 1
            },
            new Models.Product()
            {
                Id = 2,
                Name = "Samsung Galaxy S25 Ultra",
                Price = 31990000,
                Description = "Điện thoại Samsung cao cấp, camera 200MP.",
                CategoryId = 2
            },
            new Models.Product()
            {
                Id = 3,
                Name = "MacBook Air M3",
                Price = 24990000,
                Description = "Laptop Apple mỏng nhẹ, phù hợp học tập và làm việc.",
                CategoryId = 3
            }
        };
    }
}

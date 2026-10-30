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
    }
}

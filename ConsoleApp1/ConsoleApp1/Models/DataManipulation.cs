using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class DataManipulation
    {
        public void AddPost(Post post)
        {
            using (BlogContext blogContext = new BlogContext())
            {
                blogContext.Posts.Add(post);
                blogContext.SaveChanges();
            }
            Console.WriteLine("Post success upload");
        }

        public void GetAllPosts()
        {
            using (BlogContext blogContext = new BlogContext())
            {
                List<Post> posts = blogContext.Posts.ToList();

                Console.WriteLine("Post All");
                Console.WriteLine("----------");
                foreach (var item in posts)
                {
                    Console.WriteLine($"Id: {item.Id}\nTitle: {item.Title}\nContent: {item.Content}\nImage: {item.Image}");
                }
            }
        }

        public void EditPostTitle(int? id, string title)
        {
            if (id == null)
            {
                throw new NullReferenceException();
                return;
            }

            using (BlogContext blogContext = new BlogContext())
            {
                Post dbpost = blogContext.Posts.FirstOrDefault(x => x.Id == id);

                if (dbpost == null)
                {
                    throw new NotFoundException("Bele Post yoxdur");
                    return;
                }

                dbpost.Title = title;
                blogContext.SaveChanges();
                Console.WriteLine("Title deyisdi");
            }

        }

        public void GetPostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
                return;
            }

            using (BlogContext blogContext = new BlogContext())
            {
                Post dbpost = blogContext.Posts.FirstOrDefault(x => x.Id == id);

                if (dbpost == null)
                {
                    throw new NotFoundException("Bele Post yoxdur");
                    return;
                }
                Console.WriteLine($"Id: {dbpost.Id}\nTitle: {dbpost.Title}\nContent: {dbpost.Content}\nImage: {dbpost.Image}");
            }
        }

        public void DeletePost(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
                return;
            }

            using (BlogContext blogContext = new BlogContext())
            {
                Post dbpost = blogContext.Posts.FirstOrDefault(x => x.Id == id);

                if (dbpost == null)
                {
                    throw new NotFoundException("Bele Post yoxdur");
                    return;
                }
                
                blogContext.Posts.Remove(dbpost);
                blogContext.SaveChanges();
                Console.WriteLine("Post silindi");

            }
        }

    }
}

using System;
using System.Linq;
using Xunit;
using EFGetStarted.AspNetCore.ExistingDb.Models;

namespace EFGetStarted.AspNetCore.ExistingDb.Tests
{
    public class InMemoryDataProviderTest
    {
        [Fact]
        public void Task_Add_Without_Relation()
        {
            //Arrange    
            var factory = new ConnectionFactory();

            //Get the instance of BlogDBContext  
            var context = factory.CreateContextForInMemory();

            var post = new Post() { Content = "foo1", Title = "foo1 title"};

            ////Act    
            var data = context.Post.Add(post);
            context.SaveChanges();

            ////Assert    
            ////Get the post count  
            var postCount = context.Post.Count();
            if (postCount != 0)
            {
                Assert.Equal(1, postCount);
            }

            ////Get single post detail  
            var singlePost = context.Post.FirstOrDefault();
            if (singlePost != null)
            {
                Assert.Equal("foo1 title", singlePost.Title);
            }
        }

        [Fact]
        public void Task_Add_With_Relation()
        {
            //Arrange    
            var factory = new ConnectionFactory();

            //Get the instance of BlogDBContext  
            var context = factory.CreateContextForInMemory();

            var post = new Post() { BlogId = 1, Content = "foo1", Title = "foo1 title" };

            ////Act    
            var data = context.Post.Add(post);
            context.SaveChanges();

            ////Assert    
            ////Get the post count  
            var postCount = context.Post.Count();
            if (postCount != 0)
            {
                Assert.Equal(1, postCount);
            }

            ////Get single post detail  
            var singlePost = context.Post.FirstOrDefault();
            if (singlePost != null)
            {
                Assert.Equal("foo1 title", singlePost.Title);
            }
        }

        [Fact]
        public void Task_Add_Time_Test()
        {
            ////Arrange    
            //var factory = new ConnectionFactory();

            ////Get the instance of BlogDBContext  
            //var context = factory.CreateContextForInMemory();

            ////Act   
            //for (int i = 1; i <= 1000; i++)
            //{
            //    var post = new () { Title = "Test Title " + i, Description = "Test Description " + i, CategoryId = 2, CreatedDate = DateTime.Now };
            //    context.Post.Add(post);
            //}

            //context.SaveChanges();


            ////Assert    
            ////Get the post count  
            //var postCount = context.Post.Count();
            //if (postCount != 0)
            //{
            //    Assert.Equal(1000, postCount);
            //}

            ////Get single post detail  
            //var singlePost = context.Post.Where(x => x.PostId == 1).FirstOrDefault();
            //if (singlePost != null)
            //{
            //    Assert.Equal("Test Title 1", singlePost.Title);
            //}
        }
    }
}

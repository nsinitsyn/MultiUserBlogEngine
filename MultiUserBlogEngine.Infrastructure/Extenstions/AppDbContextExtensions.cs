using MultiUserBlogEngine.Domain.Entities;
using MultiUserBlogEngine.Domain.Entities.Enum;
using MultiUserBlogEngine.Infrastructure.DbAccess;

namespace MultiUserBlogEngine.Infrastructure.Extenstions;

public static class AppDbContextExtensions
{
    public static void SeedDatabase(this AppDbContext dbContext)
    {
        if(dbContext.Users.Any())
        {
            return;
        }

        dbContext.Users.Add(new User
        {
            UserRole = UserRole.SystemUser,
            Email = "not defined",
            DisplayName = "System"
        });

        if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MULTI_USER_BLOG_ENGINE_SEED_TEST_DATA")))
        {
            SeedTestData(dbContext);
        }

        dbContext.SaveChanges();
    }

    private static void SeedTestData(AppDbContext dbContext)
    {
        var alex = new User
        {
            UserRole = UserRole.User,
            Email = "alex@user.com",
            DisplayName = "Alex",
            EmailConfirmed = true,
            Rating = 10,
            Posts = new List<Post>
            {
                new Post
                {
                    Title = "How to learn English",
                    PreviewContent = "Preview content here",
                    Content = "Content",
                    ApprovedDateTime = DateTime.Parse("2022-10-08 12:20:00Z").ToUniversalTime(),
                    IsApproved = true,
                    Rating = 5,
                    GuestUserViews = new List<PostGuestUserView>
                    {
                        new PostGuestUserView
                        {
                            IpAddress = "168.141.25.78"
                        },
                        new PostGuestUserView
                        {
                            IpAddress = "164.115.32.65"
                        }
                    },
                    Tags = new List<Tag>
                    {
                        new Tag { Id = "English" },
                        new Tag { Id = "Learning" }
                    }
                }
            }
        };

        var alexPost = alex.Posts.First();

        var max = new User
        {
            UserRole = UserRole.User,
            Email = "max@user.com",
            DisplayName = "Max",
            EmailConfirmed = true,
            Rating = 0,
            FavoritesPosts = new List<Post> { alexPost },
            SubscribedTo = new List<User> { alex }
        };

        alexPost.Comments = new List<Comment>
        {
            new Comment
            {
                User = max,
                Content = "Nice post!",
                CreatedDateTime = DateTime.Parse("2022-10-08 12:56:00Z").ToUniversalTime(),
                Reactions = new List<CommentReaction> 
                {
                    new CommentReaction
                    {
                        User = alex,
                        IsLike = true
                    }
                }
            }
        };

        alexPost.Reactions = new List<PostReaction>
        {
            new PostReaction
            {
                User = max,
                IsLike = true,
                CreatedDateTime = DateTime.Parse("2022-10-08 12:55:09Z").ToUniversalTime(),
            }
        };

        dbContext.Users.Add(alex);
        dbContext.Users.Add(max);
    }
}

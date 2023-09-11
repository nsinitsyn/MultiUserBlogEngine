using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;
using MultiUserBlogEngine.Domain.Entities.Links;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.Posts)
            .WithOne(x => x.AuthorUser)
            .HasForeignKey(x => x.AuthorUserId);

        builder.HasOne(x => x.BlockingInformation)
            .WithOne()
            .HasForeignKey<BlockedUser>(x => x.UserId);

        builder.HasOne(x => x.DeletedUser)
            .WithMany()
            .HasForeignKey(x => x.DeletedUserId);

        builder.HasMany(x => x.FavoritesPosts)
            .WithMany()
            .UsingEntity("UserFavoritePostLink")
            .ToTable("UserFavoritePostLinks");

        builder.HasMany(x => x.ReadLaterPosts)
            .WithMany()
            .UsingEntity("UserReadLaterPostLink")
            .ToTable("UserReadLaterPostLinks");

        builder.HasMany(x => x.PostComplaints)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.SubscribedTo)
            .WithMany(x => x.Subscribers)
            .UsingEntity<UserSubscribedToLink>(
                b => b.HasOne(x => x.SubscribedToUser).WithMany().HasForeignKey(x => x.SubscribedToUserId),
                b => b.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId))
            .ToTable($"{nameof(UserSubscribedToLink)}s");

        builder.HasMany(x => x.IgnoredPostTags)
            .WithMany()
            .UsingEntity("UserIgnoredPostTagLink")
            .ToTable("UserIgnoredPostTagLinks");

        builder.HasMany(x => x.IgnoredAuthors)
            .WithMany()
            .UsingEntity<UserIgnoredAuthorLink>(
                b => b.HasOne(x => x.IgnoredAuthorUser).WithMany().HasForeignKey(x => x.IgnoredAuthorUserId),
                b => b.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId))
            .ToTable($"{nameof(UserIgnoredAuthorLink)}s");
    }
}

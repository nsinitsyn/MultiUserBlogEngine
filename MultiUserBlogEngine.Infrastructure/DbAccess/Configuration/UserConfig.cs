using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

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
            .WithMany();

        builder.HasMany(x => x.ReadLaterPosts)
            .WithMany();

        builder.HasMany(x => x.PostComplaints)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class PostConfig : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasOne(x => x.DeletedUser)
            .WithMany()
            .HasForeignKey(x => x.DeletedUserId);

        builder.HasMany(x => x.UserViews)
            .WithMany()
            .UsingEntity("PostUserViewLink")
            .ToTable("PostUserViewLinks");

        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity("PostTagLink")
            .ToTable("PostTagLinks");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class PostReactionConfig : IEntityTypeConfiguration<PostReaction>
{
    public void Configure(EntityTypeBuilder<PostReaction> builder)
    {
        builder.HasKey(x => new { x.UserId, x.PostId });
    }
}

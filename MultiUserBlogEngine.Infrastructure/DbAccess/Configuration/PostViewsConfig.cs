using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class PostViewsConfig : IEntityTypeConfiguration<PostViews>
{
    public void Configure(EntityTypeBuilder<PostViews> builder)
    {
        builder.HasKey(x => x.PostId);
    }
}

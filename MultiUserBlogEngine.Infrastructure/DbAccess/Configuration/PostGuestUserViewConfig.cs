using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class PostGuestUserViewConfig : IEntityTypeConfiguration<PostGuestUserView>
{
    public void Configure(EntityTypeBuilder<PostGuestUserView> builder)
    {
        builder.ToTable($"{nameof(PostGuestUserView)}s");

        builder.HasKey(x => new { x.PostId, x.IpAddress });
    }
}

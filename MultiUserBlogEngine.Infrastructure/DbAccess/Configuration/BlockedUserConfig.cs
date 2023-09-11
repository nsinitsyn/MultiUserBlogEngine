
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class BlockedUserConfig : IEntityTypeConfiguration<BlockedUser>
{
    public void Configure(EntityTypeBuilder<BlockedUser> builder)
    {
        builder.HasKey(x => x.UserId);
    }
}

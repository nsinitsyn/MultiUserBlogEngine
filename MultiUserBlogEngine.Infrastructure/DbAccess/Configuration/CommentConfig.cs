using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(x => x.DeletedUser)
            .WithMany()
            .HasForeignKey(x => x.DeletedUserId);
    }
}

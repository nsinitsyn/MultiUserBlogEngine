using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable($"{nameof(Comment)}s");

        builder.HasOne(x => x.DeletedUser)
            .WithMany()
            .HasForeignKey(x => x.DeletedUserId);

        builder.HasOne(x => x.ParentComment)
            .WithMany(x => x.ChildComments)
            .HasForeignKey(x => x.ParentCommentId);

        // SQL Server Express не поддерживает каскадное удаление для циклических связей, поэтому использовался DeleteBehavior.ClientCascade.
        // Оставлено на случай тестов на SQL Server.

        //builder.HasOne(x => x.User)
        //    .WithMany(x => x.Comments)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.ClientCascade);
    }
}

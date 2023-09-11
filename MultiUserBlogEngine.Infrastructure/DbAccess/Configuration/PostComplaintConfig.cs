
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiUserBlogEngine.Domain.Entities;

namespace MultiUserBlogEngine.Infrastructure.DbAccess.Configuration;

internal class PostComplaintConfig : IEntityTypeConfiguration<PostComplaint>
{
    public void Configure(EntityTypeBuilder<PostComplaint> builder)
    {
        builder.ToTable($"{nameof(PostComplaint)}s");

        // SQL Server не поддерживает каскадное удаление для циклических связей, поэтому использовался DeleteBehavior.ClientCascade.
        // Оставлено на случай тестов на SQL Server.

        //builder.HasOne(x => x.User)
        //    .WithMany(x => x.PostComplaints)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.ClientCascade);
    }
}

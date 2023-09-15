﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiUserBlogEngine.Infrastructure.DbAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MultiUserBlogEngine.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.BlockedUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("BlockedReasonComment")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BlockedUntil")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("LastUpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("BlockedUsers", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedReasonComment")
                        .HasColumnType("text");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("LastUpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedUserId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.CommentReaction", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("CommentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("IsLike")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentReactions", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Links.UserIgnoredAuthorLink", b =>
                {
                    b.Property<int>("IgnoredAuthorUserId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("IgnoredAuthorUserId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIgnoredAuthorLinks", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Links.UserSubscribedToLink", b =>
                {
                    b.Property<int>("SubscribedToUserId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("SubscribedToUserId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSubscribedToLinks", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApprovedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("AuthorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedReasonComment")
                        .HasColumnType("text");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HiddenDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("LastUpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("PreviewContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("DeletedUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostComplaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppointedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("AppointedUserProcessedStatusComment")
                        .HasColumnType("text");

                    b.Property<string>("ComplaintText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("LastUpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("PostComplaintStatus")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointedUserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostComplaints", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostGuestUserView", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text");

                    b.HasKey("PostId", "IpAddress");

                    b.ToTable("PostGuestUserViews", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostReaction", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("IsLike")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostReactions", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostViews", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("ViewsNumber")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.ToTable("PostViews");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedReasonComment")
                        .HasColumnType("text");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastAuthorizedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastAuthorizedIpAddress")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("LastUpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Device")
                        .HasColumnType("text");

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExitDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text");

                    b.Property<string>("Platform")
                        .HasColumnType("text");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserAgent")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("PostTagLink", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<string>("TagsId")
                        .HasColumnType("text");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostTagLinks", (string)null);
                });

            modelBuilder.Entity("PostUserViewLink", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserViewsId")
                        .HasColumnType("integer");

                    b.HasKey("PostId", "UserViewsId");

                    b.HasIndex("UserViewsId");

                    b.ToTable("PostUserViewLinks", (string)null);
                });

            modelBuilder.Entity("UserFavoritePostLink", b =>
                {
                    b.Property<int>("FavoritesPostsId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("FavoritesPostsId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFavoritePostLinks", (string)null);
                });

            modelBuilder.Entity("UserIgnoredPostTagLink", b =>
                {
                    b.Property<string>("IgnoredPostTagsId")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("IgnoredPostTagsId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIgnoredPostTagLinks", (string)null);
                });

            modelBuilder.Entity("UserReadLaterPostLink", b =>
                {
                    b.Property<int>("ReadLaterPostsId")
                        .HasColumnType("integer");

                    b.Property<int>("User1Id")
                        .HasColumnType("integer");

                    b.HasKey("ReadLaterPostsId", "User1Id");

                    b.HasIndex("User1Id");

                    b.ToTable("UserReadLaterPostLinks", (string)null);
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.BlockedUser", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", null)
                        .WithOne("BlockingInformation")
                        .HasForeignKey("MultiUserBlogEngine.Domain.Entities.BlockedUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Comment", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedUserId");

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Comment", "ParentComment")
                        .WithMany("ChildComments")
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeletedUser");

                    b.Navigation("ParentComment");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.CommentReaction", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Comment", null)
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Links.UserIgnoredAuthorLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "IgnoredAuthorUser")
                        .WithMany()
                        .HasForeignKey("IgnoredAuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IgnoredAuthorUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Links.UserSubscribedToLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "SubscribedToUser")
                        .WithMany()
                        .HasForeignKey("SubscribedToUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscribedToUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Post", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "AuthorUser")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedUserId");

                    b.Navigation("AuthorUser");

                    b.Navigation("DeletedUser");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostComplaint", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "AppointedUser")
                        .WithMany()
                        .HasForeignKey("AppointedUserId");

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany("PostComplaints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointedUser");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostGuestUserView", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", null)
                        .WithMany("GuestUserViews")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostReaction", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.PostViews", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", "Post")
                        .WithOne("Views")
                        .HasForeignKey("MultiUserBlogEngine.Domain.Entities.PostViews", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.User", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedUserId");

                    b.Navigation("DeletedUser");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Visitor", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostTagLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PostUserViewLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserViewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserFavoritePostLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("FavoritesPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserIgnoredPostTagLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("IgnoredPostTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserReadLaterPostLink", b =>
                {
                    b.HasOne("MultiUserBlogEngine.Domain.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("ReadLaterPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiUserBlogEngine.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Comment", b =>
                {
                    b.Navigation("ChildComments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("GuestUserViews");

                    b.Navigation("Reactions");

                    b.Navigation("Views");
                });

            modelBuilder.Entity("MultiUserBlogEngine.Domain.Entities.User", b =>
                {
                    b.Navigation("BlockingInformation");

                    b.Navigation("Comments");

                    b.Navigation("PostComplaints");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}

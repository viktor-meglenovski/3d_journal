using domain.DomainModels;
using domain.Identity;
using domain.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<ProfileImage> ProfileImages { get; set; }
        public virtual DbSet<OtherProjectImage> OtherProjectImages { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<ProjectSoftware> ProjectSoftwares { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //primary keys
            builder.Entity<ProjectImage>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<OtherProjectImage>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ProfileImage>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<SoftwareImage>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Software>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Project>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<UploadedFile>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ProjectSoftware>()
                .HasKey(x => new { x.ProjectId, x.SoftwareId });

            builder.Entity<Like>()
                .HasKey(x => new { x.ProjectId, x.UserId });


            //AppUser-Image 1-1
            builder.Entity<AppUser>()
                .HasOne(x => x.ProfileImage)
                .WithOne(x => x.AppUser)
                .HasForeignKey<AppUser>(x => x.ProfileImageId);


            //AppUser-Project (Creator) 1-N
            builder.Entity<AppUser>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId);

            //Project-Software M-N
            builder.Entity<ProjectSoftware>()
                .HasOne(x => x.Project)
                .WithMany(x => x.SoftwaresUsed)
                .HasForeignKey(x => x.ProjectId);

            builder.Entity<ProjectSoftware>()
                .HasOne(x => x.Software)
                .WithMany(x => x.UsedInProjects)
                .HasForeignKey(x => x.SoftwareId);

            //Project-AppUser (Likes) M-N
            builder.Entity<Like>()
                .HasOne(x => x.Project)
                .WithMany(x => x.LikedByUsers)
                .HasForeignKey(x => x.ProjectId);

            builder.Entity<Like>()
                .HasOne(x => x.User)
                .WithMany(x => x.LikedProjects)
                .HasForeignKey(x => x.UserId);

            //Project-MainImage 1-1
            builder.Entity<Project>()
                .HasOne(x => x.MainImage)
                .WithOne(x => x.Project)
                .HasForeignKey<Project>(x => x.MainImageId)
                .OnDelete(DeleteBehavior.SetNull);

            //Project-OtherImages 1-N
            builder.Entity<Project>()
                .HasMany(x => x.OtherImages)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            //Software-Logo 1-1
            builder.Entity<Software>()
                .HasOne(x => x.Logo)
                .WithOne(x => x.Software)
                .HasForeignKey<Software>(x => x.LogoId);

            //Project-UploadedFile 1-1
            builder.Entity<Project>()
                .HasOne(x => x.UploadedFile)
                .WithOne(x => x.Project)
                .HasForeignKey<Project>(x => x.UploadedFileId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

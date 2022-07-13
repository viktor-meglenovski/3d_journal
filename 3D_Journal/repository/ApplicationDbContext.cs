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
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<ProjectSoftware> ProjectSoftwares { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //primary keys
            builder.Entity<Image>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Software>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Project>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ProjectSoftware>()
                .HasKey(x => new { x.ProjectId,x.SoftwareId});


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

        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace networthitservices.models
{
    public partial class NetworthitservicesContext : DbContext
    {
        public NetworthitservicesContext(DbContextOptions<NetworthitservicesContext> options) : base(options)
        {

        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("categories", "blog");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("posts", "blog");

                entity.Property(e => e.PostId)
                    .HasColumnName("PostID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DatePublished).HasColumnType("datetime");

                entity.Property(e => e.FeaturedImage).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_posts_categories");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("services", "web");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("settings", "app");

                entity.Property(e => e.Key)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();
            });
        }
    }
}

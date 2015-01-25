using System.Data.Entity;
using System.Diagnostics;
using ORM.Entities;

namespace ORM.Context
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("Forum")
        {
            Debug.WriteLine(GetHashCode() + ". Context has been created");
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine(GetHashCode() + ". Context has been disposed");
            base.Dispose(disposing);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Replies)
                .WithRequired(e => e.Writer)
                .HasForeignKey(e => e.WriterId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Replies)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
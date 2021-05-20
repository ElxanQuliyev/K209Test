using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibraryAppK209.Models
{
    public partial class LibraryDBK209Context : DbContext
    {
        public LibraryDBK209Context()
        {
        }

        public LibraryDBK209Context(DbContextOptions<LibraryDBK209Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorToBook> AuthorToBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<SelectBookCategory> SelectBookCategories { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L693205\\MSCOMPAR;Initial Catalog=LibraryDBK209;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AuthorToBook>(entity =>
            {
                entity.ToTable("Author_to_Book");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorToBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Author_to__Autho__5070F446");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorToBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Author_to__BookI__5165187F");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Books__CategoryI__4D94879B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Orders__BookId__5535A963");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Orders__StudentI__5441852A");
            });

            modelBuilder.Entity<SelectBookCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SelectBookCategory");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Book Name");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Category Name");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ssn).HasColumnName("SSN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

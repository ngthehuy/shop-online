using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Models;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountCategory> AccountCategories { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientCategory> ClientCategories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactCategory> ContactCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<PictureCategory> PictureCategories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductComment> ProductComments { get; set; }

    public virtual DbSet<ProductMainCategory> ProductMainCategories { get; set; }

    public virtual DbSet<ProductVote> ProductVotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ShopOnlineDB;TrustServerCertificate=True;Persist Security Info=True;User ID=sa;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Account__536C85E5D8BD64AA");

            entity.ToTable("Account");

            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.AccountCategoryId)
                .HasMaxLength(50)
                .HasColumnName("AccountCategoryID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Thumb).HasMaxLength(255);

            entity.HasOne(d => d.AccountCategory).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountCategoryId)
                .HasConstraintName("FK__Account__Account__1273C1CD");
        });

        modelBuilder.Entity<AccountCategory>(entity =>
        {
            entity.HasKey(e => e.AccountCategoryId).HasName("PK__AccountC__8E42115A4F112CD8");

            entity.ToTable("AccountCategory");

            entity.Property(e => e.AccountCategoryId)
                .HasMaxLength(50)
                .HasColumnName("AccountCategoryID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Article__9C6270C8D543FC56");

            entity.ToTable("Article");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.ArticleCategoryId).HasColumnName("ArticleCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.ArticleCategory).WithMany(p => p.Articles)
                .HasForeignKey(d => d.ArticleCategoryId)
                .HasConstraintName("FK__Article__Article__300424B4");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__Article__CreateB__239E4DCF");
        });

        modelBuilder.Entity<ArticleCategory>(entity =>
        {
            entity.HasKey(e => e.ArticleCategoryId).HasName("PK__ArticleC__E0B6096352A3440E");

            entity.ToTable("ArticleCategory");

            entity.Property(e => e.ArticleCategoryId).HasColumnName("ArticleCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.ArticleCategories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__ArticleCa__Creat__1FCDBCEB");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A049835BB3E");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ClientCategoryId).HasColumnName("ClientCategoryID");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.ClientCategory).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientCategoryId)
                .HasConstraintName("FK__Client__ClientCa__32E0915F");
        });

        modelBuilder.Entity<ClientCategory>(entity =>
        {
            entity.HasKey(e => e.ClientCategoryId).HasName("PK__ClientCa__BDD57BF8F50001EB");

            entity.ToTable("ClientCategory");

            entity.Property(e => e.ClientCategoryId).HasColumnName("ClientCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.ClientCategories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__ClientCat__Creat__2D27B809");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C6625BBE1F08916");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ApproveBy).HasMaxLength(50);
            entity.Property(e => e.ContactCategoryId).HasColumnName("ContactCategoryID");
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(15);

            entity.HasOne(d => d.ApproveByNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ApproveBy)
                .HasConstraintName("FK__Contact__Approve__44FF419A");

            entity.HasOne(d => d.ContactCategory).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactCategoryId)
                .HasConstraintName("FK__Contact__Contact__35BCFE0A");
        });

        modelBuilder.Entity<ContactCategory>(entity =>
        {
            entity.HasKey(e => e.ContactCategoryId).HasName("PK__ContactC__1895FD7171A7D645");

            entity.ToTable("ContactCategory");

            entity.Property(e => e.ContactCategoryId).HasColumnName("ContactCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.ContactCategories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__ContactCa__Creat__412EB0B6");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF31791B0A");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(15);

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Order__ClientID__37A5467C");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__OrderDet__08D097C199D31491");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__38996AB5");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__398D8EEE");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.PictureId).HasName("PK__Picture__8C2866F84B233F31");

            entity.ToTable("Picture");

            entity.Property(e => e.PictureId).HasColumnName("PictureID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.PictureCategoryId).HasColumnName("PictureCategoryID");
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Url).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__Picture__CreateB__2A4B4B5E");

            entity.HasOne(d => d.PictureCategory).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.PictureCategoryId)
                .HasConstraintName("FK__Picture__Picture__3B75D760");
        });

        modelBuilder.Entity<PictureCategory>(entity =>
        {
            entity.HasKey(e => e.PictureCategoryId).HasName("PK__PictureC__2DD7C7103089B3DD");

            entity.ToTable("PictureCategory");

            entity.Property(e => e.PictureCategoryId).HasColumnName("PictureCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.PictureCategories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__PictureCa__Creat__267ABA7A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED0419FBE7");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Accessories).HasMaxLength(255);
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.ImageList).HasMaxLength(4000);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.Specification).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Warranty).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__Product__CreateB__1CF15040");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK__Product__Product__3E52440B");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__ProductC__3224ECEEF91EC81D");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.ProductMainCategoryId).HasColumnName("ProductMainCategoryID");
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__ProductCa__Creat__1920BF5C");

            entity.HasOne(d => d.ProductMainCategory).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductMainCategoryId)
                .HasConstraintName("FK__ProductCa__Produ__403A8C7D");
        });

        modelBuilder.Entity<ProductComment>(entity =>
        {
            entity.HasKey(e => e.ProductCommentId).HasName("PK__ProductC__2EC5E002CFF6D182");

            entity.ToTable("ProductComment");

            entity.Property(e => e.ProductCommentId).HasColumnName("ProductCommentID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Client).WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__ProductCo__Clien__412EB0B6");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductCo__Produ__4222D4EF");
        });

        modelBuilder.Entity<ProductMainCategory>(entity =>
        {
            entity.HasKey(e => e.ProductMainCategoryId).HasName("PK__ProductM__B450B99FFAE6F06F");

            entity.ToTable("ProductMainCategory");

            entity.Property(e => e.ProductMainCategoryId).HasColumnName("ProductMainCategoryID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.ProductMainCategories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__ProductMa__Creat__15502E78");
        });

        modelBuilder.Entity<ProductVote>(entity =>
        {
            entity.HasKey(e => new { e.ClientId, e.ProductId }).HasName("PK__ProductV__2D3ED66A08600D5C");

            entity.ToTable("ProductVote");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.ProductVotes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductVo__Clien__440B1D61");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVotes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductVo__Produ__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System.Drawing;
using FakeWebcomic.Storage.Helper;
using FakeWebcomic.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeWebcomic.Storage
{
    public class FakeWebcomicContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<ComicPage> ComicPages { get; set; }
        public FakeWebcomicContext(DbContextOptions<FakeWebcomicContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<ComicBook>().HasKey(u => u.EntityId);
            builder.Entity<ComicPage>().HasKey(u => u.EntityId);

            builder.Entity<ComicPage>()
                .HasOne(b => b.ComicBook)
                .WithMany(p => p.ComicPages)
                .HasForeignKey(u => u.ComicBookId);

            seedDB(builder);
        }

        private static void seedDB(ModelBuilder builder)
        {
            // Store and Define Objects
            User u1 = new User { EntityId = 1L, Name = "Kevin", IsAdmin = true };
            User u2 = new User { EntityId = 2L, Name = "Robert", IsAdmin = false };
            //
            // Using Test Image
            var obj = new ImageConvertor();
            var img = Image.FromFile("Images/test_img.jpg");
            byte[] imgByteArr = obj.ConvertImageToByteArray(img, ".jpg");

            var img2 = Image.FromFile("Images/test_img2.jpg");
            byte[] imgByteArr2 = obj.ConvertImageToByteArray(img2, ".jpg");

            var img3 = Image.FromFile("Images/test_img3.jpg");
            byte[] imgByteArr3 = obj.ConvertImageToByteArray(img3, ".jpg");

            ComicPage p1 = new ComicPage { EntityId = 1L, ComicBookId = 1L, PageNumber = 1, Image = imgByteArr, PageTitle = "Tin goes to the amuesment park" };
            ComicPage p2 = new ComicPage { EntityId = 2L, ComicBookId = 2L, PageNumber = 1, Image = imgByteArr2, PageTitle = "The Wedding's of the Harlequin" };
            ComicPage p3 = new ComicPage { EntityId = 3L, ComicBookId = 2L, PageNumber = 2, Image = imgByteArr3, PageTitle = "Superwoman goes for a swim" };

            ComicBook b1 = new ComicBook { EntityId = 1L, Title = "Tin Tin's Adventure", Author = "Hergé", Genre = "Adventure", EditionNumber = 32, Description = "Description goes here" };
            ComicBook b2 = new ComicBook { EntityId = 2L, Title = "All American Comic", Author = "Frank", Genre = "Action", EditionNumber = 2, Description = "Different Description" };

            // Insert the seed data to MS SQL DB
            builder.Entity<User>().HasData(u1);
            builder.Entity<User>().HasData(u2);

            builder.Entity<ComicBook>().HasData(b1);
            builder.Entity<ComicBook>().HasData(b2);
            builder.Entity<ComicPage>().HasData(p1);
            builder.Entity<ComicPage>().HasData(p2);
            builder.Entity<ComicPage>().HasData(p3);
        }
    }
}

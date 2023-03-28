using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using minitwit_backend.Data.Model;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace minitwit_backend.Data;

public partial class MinitwitContext : DbContext
{
    public MinitwitContext()
    {
    }

    public MinitwitContext(DbContextOptions<MinitwitContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured) {

            if (File.Exists("../databasefile/connectionString.txt"))
            {
                StreamReader readingFile = new StreamReader("../databasefile/connectionString.txt");
                string connectionString = readingFile.ReadLine();
                optionsBuilder.UseNpgsql(connectionString);
            }
            else if (File.Exists("../../databasefile/connectionString.txt"))
            {
                StreamReader readingFile = new StreamReader("../../databasefile/connectionString.txt");
                string connectionString = readingFile.ReadLine();
                optionsBuilder.UseNpgsql(connectionString);

            }
            else {
                throw new Exception("Please put a connection string in a txt file called connectionString.txt in a folder called databasefile");
            }

                /*
                if (File.Exists("../databasefile/minitwit.db"))
                {
                    optionsBuilder.UseSqlite("Data Source=../databasefile/minitwit.db");
                }
                else if (File.Exists("../../databasefile/minitwit.db"))
                {
                    optionsBuilder.UseSqlite("Data Source=../../databasefile/minitwit.db");
                }
                else {
                    optionsBuilder.UseSqlite("Data Source=../../databasefile/minitwit.db");
                }
                */

            }

        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("message");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Flagged).HasColumnName("flagged");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Text)
                .HasColumnName("text");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasColumnName("email");
            entity.Property(e => e.PwHash)
                .HasColumnName("pw_hash");
            entity.Property(e => e.Username)
                .HasColumnName("username");
            entity.HasMany(e => e.Following).WithMany(e => e.Followers);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

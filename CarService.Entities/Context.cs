using CarService.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient.Server;

namespace CarService.Entities;

public class Context : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Models.CarService>? CarServices { get; set; }
    public DbSet<MeanOfPayment>? MeansOfPayment { get; set; }
    public DbSet<OwnerOfCarService>? OwnersOfCarServices { get; set; }
    public DbSet<ReviewForCarService>? ReviewsForCarService { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<ServiceOfCarService>? ServicesOfCarService { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region User

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasOne(x => x.MeanOfPayment)
                                .WithMany(x => x.Users)
                                .HasForeignKey(x => x.IdMeanOfPayment)
                                .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region CarService

        builder.Entity<Models.CarService>().ToTable("CarServices");
        builder.Entity<Models.CarService>().HasKey(x => x.Id);
        builder.Entity<Models.CarService>().HasOne(x => x.OwnerOfCarService)
                                .WithMany(x => x.CarServices)
                                .HasForeignKey(x => x.IdOwnerOfCarService)
                                .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region MeanOfPayment

        builder.Entity<MeanOfPayment>().ToTable("MeansOfPayment");
        builder.Entity<MeanOfPayment>().HasKey(x => x.Id);

        #endregion

        #region OwnerOfCarService

        builder.Entity<OwnerOfCarService>().ToTable("OwnersOfCarServices");
        builder.Entity<OwnerOfCarService>().HasKey(x => x.Id);

        #endregion

        #region ReviewForCarService

        builder.Entity<ReviewForCarService>().ToTable("ReviewsForCarService");
        builder.Entity<ReviewForCarService>().HasKey(x => x.Id);
        builder.Entity<ReviewForCarService>().HasOne(x => x.CarService)
                                    .WithMany(x => x.ReviewsForCarService)
                                    .HasForeignKey(x => x.IdCarService)
                                    .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<ReviewForCarService>().HasOne(x => x.User)
                                    .WithMany(x => x.ReviewsForCarService)
                                    .HasForeignKey(x => x.IdUser)
                                    .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Service

        builder.Entity<Service>().ToTable("Services");
        builder.Entity<Service>().HasKey(x => x.Id);

        #endregion

        #region ServiceOfCarService

        builder.Entity<ServiceOfCarService>().ToTable("ServicesOfCarService");
        builder.Entity<ServiceOfCarService>().HasKey(x => x.Id);
        builder.Entity<ServiceOfCarService>().HasOne(x => x.Service)
                                    .WithMany(x => x.ServicesOfCarService)
                                    .HasForeignKey(x => x.IdService)
                                    .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<ServiceOfCarService>().HasOne(x => x.CarService)
                                    .WithMany(x => x.ServicesOfCarService)
                                    .HasForeignKey(x => x.IdCarService)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}
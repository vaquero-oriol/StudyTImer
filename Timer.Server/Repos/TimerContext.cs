using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timer.Server.Negocio;

namespace Timer.Server.Repos;

public class TimerContext: DbContext
{
    
    public DbSet<User> Users { get; set; }
    public TimerContext(DbContextOptions<TimerContext> options) : base(options)
    {
        
    }
    public static TimerContext Create(DbContextOptions<TimerContext> options)
    {
        return new TimerContext(options);
    }

    public async Task GuardarCambios()
    {
        try
        {
            await SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20);
            entity.Property(e => e.Contrasena);

        });

        modelBuilder.Entity<Negocio.Timer>(entity =>
        {
            entity.ToTable("timer");
            entity.HasKey(e => e.Id);
            entity.HasOne(m=>m.User)
                .WithMany(m=>m.Timers)
                .HasForeignKey(m=>m.Id)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);


        });
    }
}
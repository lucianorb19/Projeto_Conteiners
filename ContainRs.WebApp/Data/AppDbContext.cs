using ContainRs.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContainRs.WebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
        .HasKey(c => c.Id);

        modelBuilder.Entity<Cliente>()
            .Property(c => c.Nome).IsRequired();

        //ESTABELECENDO AS CONFIGURAÇÕES DO CAMPO Email DE Cliente
        //PARA A CONVERSÃO ENTRE MODELS <-> DB
        modelBuilder.Entity<Cliente>()
            .OwnsOne(c => c.Email, cfg =>//1 EMAIL
            {
                cfg.Property(e => e.Value)//O CAMPO Value EM EMAIL
                    .HasColumnName("Email")//COM NOME DE COLUNA Email
                    .IsRequired();//CAMPO Email OBRIGATÓRIO
            });


        modelBuilder.Entity<Cliente>()
            .Property(c => c.CPF).IsRequired();
    }
}

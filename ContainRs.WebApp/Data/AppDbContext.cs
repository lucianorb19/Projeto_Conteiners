using ContainRs.Application.Repositories;
using ContainRs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContainRs.WebApp.Data;

//public class AppDbContext : DbContext
public class AppDbContext : DbContext, IClienteRepository 
{
    //CONSTRUTOR QUE HERDA DA BASE
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    //ATRIBUTOS
    public DbSet<Cliente> Clientes { get; set; }


    //MÉTODO QUE CONFIGURA A CRIAÇÃO DAS TABELAS NA BD
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

    //IMPLEMENTAÇÃO DO MÉTODO HERDADO DA INTERFACE ContainRs.Application/Repositories/IClienteRepository
    public async Task<Cliente> AddAsync(Cliente cliente)
    {
        await Clientes.AddAsync(cliente);//ADICIONA CLIENTE A BD
        await SaveChangesAsync();//SALVA AS MUDANÇAS
        return cliente;
    }

}

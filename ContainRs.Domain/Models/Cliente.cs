﻿namespace ContainRs.Domain.Models;

public class Cliente
{

    //LIMITAÇÃO DO ENTITY PARA USAR CLASSE Email NO CONSTRUTOR DE Cliente
    private Cliente() { }

    public Cliente(string nome, Email email, string cPF)
    {
        Nome = nome;
        Email = email;
        CPF = cPF;
    }

    public Guid Id { get; set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public string CPF { get; private set; }
    public string? Celular { get; set; }
    public string? CEP { get; set; }
    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Municipio { get; set; }
    public string? Cidade { get; set; }
    
    //public string? Estado { get; set;} 
    public UnidadeFederativa? Estado { get; set; }
}

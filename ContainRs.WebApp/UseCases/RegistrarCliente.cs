﻿using ContainRs.WebApp.Data;
using ContainRs.WebApp.Models;

namespace ContainRs.WebApp.UseCases
{
    public class RegistrarCliente
    {

        //ATRIBUTOS

        //ATRIBUTO PARA CONEXÃO BD
        private readonly AppDbContext context;
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
        public string? Estado { get; set; }


        //CONSTRUTOR
        public RegistrarCliente(AppDbContext context, string nome, Email email, string cPF,
                                string? celular, string? cEP, string? rua,
                                string? numero, string? complemento, string? bairro,
                                string? municipio, string? estado)
        {
            this.context = context;
            Nome = nome;
            Email = email;
            CPF = cPF;
            Celular = celular;
            CEP = cEP;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Municipio = municipio;
            Estado = estado;
        }

        //MÉTODO QUE ADICIONA O CLIENTE A BD E RETORNA SEUS DADOS
        public async Task<Cliente> ExecutarAsync()
        {
            var cliente = new Cliente(Nome, Email, CPF)
            {
                Celular = Celular,
                CEP = CEP,
                Rua = Rua,
                Numero = Numero,
                Complemento = Complemento,
                Bairro = Bairro,
                Municipio = Municipio,
                Estado = Estado
            };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            return cliente;
        }
    }
}

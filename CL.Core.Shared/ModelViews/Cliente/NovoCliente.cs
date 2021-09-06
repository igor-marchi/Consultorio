using CL.Core.Shared.ModelViews.Endereco;
using CL.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;

namespace CL.Core.Shared.ModelViews.Cliente
{
    /// <summary>
    /// Objeto utilizado para inserção de um cliente
    /// </summary>
    public class NovoCliente
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        /// <example>Fulano de Tal</example>
        public string Nome { get; set; }

        /// <summary>
        /// Data de nascimento do cliente
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo cliente
        /// </summary>
        /// <example>M</example>
        public GeneroView Genero { get; set; }

        /// <summary>
        /// Documento do cliente: CNH, CPF ou RG
        /// </summary>
        /// <example>12345678</example>
        public string Documento { get; set; }

        public ICollection<NovoTelefone> Telefones { get; set; }

        public NovoEndereco Endereco { get; set; }
    }
}
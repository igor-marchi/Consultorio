using System;
using System.Collections.Generic;

namespace CL.Core.Domain
{
    public class Cliente
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public Genero Genero { get; set; }

        public ICollection<Telefone> Telefones { get; set; }

        public string Documento { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? UltimaAtualizacao { get; set; }

        public Endereco Endereco { get; set; }
    }
}
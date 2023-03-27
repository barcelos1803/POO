using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    
    
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Cidade Cidade {get; set; }

        public Pessoa(int id, string nome, string telefone, Cidade cidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cidade = cidade;
        }             
    }


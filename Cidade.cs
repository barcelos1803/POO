using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Cidade
    {
        public int Id { get; private set; }
        public string Nome { get; set; }

        public Cidade(int idCidade, string nomeCidade)
        {
            this.Id = idCidade;
            this.Nome = nomeCidade;
        } 

    }

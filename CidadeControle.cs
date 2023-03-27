using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    namespace CadastroCidade
    {
        public class CidadeControle
        {
            private static List<Cidade> cidades = new List<Cidade>();
            public static List<Cidade> GetListas()
            {
                return cidades;
            }

            public static void add (Cidade a)
            {
                cidades.Add(a);
            }
        }
    }

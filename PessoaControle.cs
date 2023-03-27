using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro
{
    public class PessoaControle
    {
        private static List<Pessoa> lista = new List<Pessoa>();

        public static List<Pessoa> GetListas()
        {
            return lista;
        }

        public static void add (Pessoa a)
        {
            lista.Add(a);
        }

        public static void alterar (Pessoa b)
        {
            int indice = GetIndicePessoa(b.Id);
            lista[indice] = b;
        }
        public static void excluir (Pessoa c)
        {
            lista.Remove(c);
        }


    public static Pessoa GetById (int id)
    {
        return lista.Find(obj=>obj.Id ==id);
        throw new ArgumentException("Não foi encontrada nenhuma pessoa com este ID.");
    }

        public static int GetIndicePessoa(int id)
    {
        //percorro a lista
        int i = 0;
        foreach(Pessoa pe in lista)
        {
            //verifico se é igual o codigo passado
            if(pe.Id==id)
            {
                //se for igual eu retorno o indice
                return i;
            }
            i++;
        }
        return -1;
    }
    }
}
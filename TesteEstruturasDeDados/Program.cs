using System;
using System.Collections.Generic;

namespace TesteEstruturasDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable é uma interface para uma coleção. Não suporta a manipulação da coleção.
            //Expõe um enumerador que dá suporte a uma iteração simples
            IEnumerable<string> frases = new List<string>();

            //ICollection é a interface para uma coleção. Ela herda de IEnumerable.
            //Define métodos para manipular coleções genéricas.
            ICollection<string> colecao = new List<string>();

            //Classe que populará a coleção.
            Populador<String> populador = new Populador<String>();

            //Delegate é uma forma de passar um método como referência.
            populador.Popular(colecao, (int)Math.Pow(2,16), delegate { return "AHAHAHHAHA"; });
            
        }


    }


}
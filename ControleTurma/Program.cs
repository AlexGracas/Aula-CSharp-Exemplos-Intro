using System;
using System.Collections.Generic;

namespace ControleTurma
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dicionario com o número da turma e uma lista de todos os alunos na turma.
            Dictionary<int, IList<String>> turmas = new Dictionary<int, IList<string>>();
            //Instanciar uma lista e ja popular os valores.
            List<string> turma1 = new List<string>() { "Alex Pinheiro das Graças", "Joana Joaninha"};
            //Instanciar e popular em linhas diferentes.
            List<string> turma2 = new List<string>();
            //Adicionando um elemento por vez.
            turma2.Add("Eduardo Dudado");
            //Adicionar uma lista de elementos.
            turma2.AddRange(new List<String>(){"Trigo Triguilho", "Mario Marinho" });
            
            //Adicionar as turmas no dicionario. Número da turma e a lista de pessoas na turma.
            turmas.Add(202, turma1);
            turmas.Add(101, turma2);

            //Recuperando uma turma
            IList<String> pessoas = turmas[202];

            //Excluindo uma turma
            turmas.Remove(202);

            //recuperar uma turma inexistente -- Exceção KeyNotFoundException
            try
            {
                pessoas = turmas[202];
            }catch(KeyNotFoundException e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }

            //Somente recupera as pessoas se a chave existir.
            if (turmas.TryGetValue(202, out pessoas))
            {
                Console.WriteLine("Existe esta turma.");
            }
            else
            {
                Console.WriteLine("Não Existe esta turma.");
            }

            Console.ReadKey();
        }
    }
}
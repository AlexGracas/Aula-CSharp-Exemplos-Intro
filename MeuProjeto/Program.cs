using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace MeuProjeto
{
    class Program
    {

        Dictionary<String, JogoDaVelha> jogos;
        IList<string> strings = new List<string>();

        /// <summary>
        /// Ponto de entrada principal para o programa.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Configura a codificação do console para evitar problemas com acentos.
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //Instancia um objeto da classe JogoDaVelha
            JogoDaVelha jv = new JogoDaVelha();
            //Variaveis temporárias.
            int jogador = 1, coluna, linha;
            do
            {
                jv.Imprimir();
                jogador = jv.Jogador;
                do
                {
                    Console.WriteLine("Digite qual coluna o jogador {0} ira jogar:", jogador);
                    //A função TryParse tenta realizar o parse da string, caso nao seja possivel retorna false,
                    //caso seja verdadeiro grava o valor na variável coluna.
                } while (!int.TryParse(Console.ReadLine(), out coluna));
                do
                {
                    Console.WriteLine("Digite qual linha o jogador {0} ira jogar:", jogador);
                } while (!int.TryParse(Console.ReadLine(), out linha));

                //Este loop ira se repetir enquanto nao for executada uma jogada válida ou nao existir um vencedor.
            } while (!jv.Jogar(coluna, linha, jogador) || (jv.VerificarVencedor() == 0)
            );

            jv.Imprimir();
            //Imprime quem foi o jogador vencedor.
            Console.WriteLine("O vencedor foi o jogador:" + jv.VerificarVencedor());
            //Fica esperando o jogador digitar algo para terminar o programa.
            //Evita que o programa termine sem o usuário conseguir ler as mensagens finais.
            Console.ReadKey();
        }
    }
}
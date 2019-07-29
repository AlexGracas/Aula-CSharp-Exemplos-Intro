using System;
using System.Collections.Generic;
using System.Text;

namespace MeuProjeto
{
    class JogoDaVelha
    {
        //Declaração de um array multidimensional.
        int[,] tabuleiro = { { 0, 0, 0 },{ 0, 0, 0 },{ 0, 0, 0 } };
        //Qual o Jogador atual. Começa com o jogador 1.
        public int Jogador { get; set; } = 1;
        private int numJogadas = 0;
        /// <summary>
        /// Joga em uma posição específica
        /// </summary>
        /// <param name="posColuna">A coluna da jogada.</param>
        /// <param name="posLinha">A linha da Jogada</param>
        /// <param name="jogador">O jogador, pode ser 1 ou 2.</param>
        /// <returns>Retorna True caso seja possivel jogar ou False caso não seja possível.</returns>
        public bool Jogar(int posColuna, int posLinha, int jogador)
        {
            if (tabuleiro[posColuna, posLinha] == 0)
            {
                tabuleiro[posColuna, posLinha] = jogador;
                this.Jogador = Jogador++ % 2 + 1;
                numJogadas++;
                return true;
            }
            return false;
        }
        public void Imprimir()
        {
            //Loop pelas colunas
            for(int y = 0; y < 3; y++)
            {
                //Loop pelas linhas
                for(int x =0; x < 3; x++)
                {
                    //Se é 0, nao imprime nada pois a casa está vazia. Caso contrario imprime 1 ou 2.
                    String jogada = tabuleiro[x, y] == 0 ? " " : tabuleiro[x, y].ToString();
                    Console.Write(" " + jogada + " ");
                    //Separa a primeira casa e a segunda e a segunda e a terceira com um '|'
                    if(x < 2)
                    {
                        Console.Write("|");
                    }
                }
                // Pular uma linha após desenhar todos 
                Console.WriteLine();
                // Sem esta condição o desenho do jogo da velha ficaria estranho, com uma linha no final. Verifique retirando a condição.
                if (y < 2)
                {
                    int num = (new Random(
                        DateTime.Now.Millisecond)
                        ).Next();
                    Console.WriteLine("------------");
                }
            }
        }

        /// <summary>
        /// Verifica se existe um vencedor.
        /// </summary>
        /// <returns>-1: Empate; 0: O jogo nao acabou; 1 ou 2: Existe um vencedor.</returns>
        public int VerificarVencedor()
        {
            for(int i=0; i < 3; i++)
            {
                //Verificar jogo na horizontal.
                if( tabuleiro[i,0]!=0 &&
                    tabuleiro[i,0]==tabuleiro[i,1] && 
                    tabuleiro[i, 1] == tabuleiro[i, 2]){
                    return tabuleiro[i, 0];
                //Verificar jogo na vertical
                }else if(
                    tabuleiro[0,i] != 0 &&
                    tabuleiro[0, i] == tabuleiro[1, i] && 
                    tabuleiro[1, i] == tabuleiro[2, i]){
                    return tabuleiro[0, i];
                }
            }
            //Verificar jogo nas duas diagonais.
            if( tabuleiro[1,1]!=0 &&
                (tabuleiro[1,1]==tabuleiro[0,0] && tabuleiro[2,2]==tabuleiro[0,0] ) ||
                (tabuleiro[1, 1] == tabuleiro[0,2] && tabuleiro[0, 2] == tabuleiro[0, 0])){
                //Retorna o número do ganhador.
                return tabuleiro[1, 1];
            }else{
                if (numJogadas == 9){
                    //Empate
                    return -1;
                }
                //O jogo nao acabou.
                return 0;
            }
        }
    }
}

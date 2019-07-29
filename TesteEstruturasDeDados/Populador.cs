using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEstruturasDeDados
{
    class Populador<T>
    {
        /// <summary>
        ///  Na plataforma .NET, um delegate ou delegado é uma variável de tipo de referência 
        ///  que representa um método ou um conjunto de métodos pela manipulação de sua referência.
        /// </summary>
        /// <returns></returns>
        public delegate T criarClasse();

        public void Popular(ICollection<T> colecao, int quantidade, criarClasse criador)
        {
            T variavel = criador();
            while (quantidade-- > 0)
            {
                colecao.Add(variavel);
            }
        }
    }

   
}

using System;
using System.Collections.Generic;

namespace Ordenacao
{
    class Program
    {
        //Teste de diferentes tipos de ordenação.
        static void Main(string[] args)
        {
            Program p = new Program();
            p.TesteOrdenacao();
        }

        private void TesteOrdenacao()
        {
            List<int> elements = new List<int>();

            long tamanhoArray = 100000;
            PopularArrayInteiro(elements, tamanhoArray);

            // ImprimirLista(elements);
            DateTime before = DateTime.Now;
            QuickSort(elements);
            Console.WriteLine("Performance: " + (DateTime.Now - before).TotalMilliseconds);
            // ImprimirLista(elements);

            elements.Clear();
            PopularArrayInteiro(elements, tamanhoArray);

            // ImprimirLista(elements);
            before = DateTime.Now;
            SelectionSort(elements);
            Console.WriteLine("Performance: " + (DateTime.Now - before).TotalMilliseconds);
            //   ImprimirLista(elements);
            elements.Clear();
            PopularArrayInteiro(elements, tamanhoArray);

            // ImprimirLista(elements);
            before = DateTime.Now;
            elements.Sort();
            Console.WriteLine("Performance: " + (DateTime.Now - before).TotalMilliseconds);
            //   ImprimirLista(elements);
            Console.ReadKey();
        }


        private void PopularArrayInteiro(List<int> elements, long x)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            do
            {
                elements.Add((r).Next(200));
            } while (x-- > 0);
        }

        static public void ImprimirLista(IList<int> lista)
        {
            Console.WriteLine("Lista:");
            foreach(int i in lista)
            {
                Console.Write(i + " ,");
            }
            Console.WriteLine();
        }

        static void SelectionSort(IList<int> lista)
        {
            int indexElement = lista.Count-1;
            do
            {
                int maiorIndex = indexElement;
                for (int i = 0; i < indexElement; i++)
                {
                    if (lista[maiorIndex] < lista[i])
                    {
                        maiorIndex = i;

                    }
                }
                int temp = lista[maiorIndex];
                lista[maiorIndex] = lista[indexElement];

                
                lista[indexElement] = temp;
            } while (indexElement-- > 0);
        }

        static void QuickSort(IList<int> lista)
        {
            QuickSort(lista, 0, lista.Count-1);
        }

        static void QuickSort(IList<int> lista, int indexInicio, int indexFim)
        {
            if (indexInicio < indexFim)
            {
                int indexPivo = ParticionaLista(lista, indexInicio, indexFim);
                QuickSort(lista, indexInicio, indexPivo-1);
                QuickSort(lista, indexPivo+1, indexFim);
            }
        }

        private static int ParticionaLista(IList<int> lista, int indexInicio, int indexFim)
        {
            int pivo = lista[indexFim];
            int i = indexInicio;
            int aux;
            for (int j = indexInicio; j <= indexFim - 1; j++)
            {
                //Verifica se cada elemento é menor do que o pivo
                if (lista[j]<pivo)
                {
                    //Aqui realiza o swap (atualização dinâmica dos elementos)
                    aux = lista[i];
                    lista[i] = lista[j];
                    lista[j] = aux;
                    i += 1;
                }
            }

            aux = lista[i];
            lista[i] = lista[indexFim];
            lista[indexFim] = aux;

            return i;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] velha = new string[3, 3]; // Matriz jogo da velha
            int jogador = 0;  // X = 0    O = 1

            iniciamatriz(velha);

            imprime(velha);


            Console.ReadKey();
        }

        static void iniciamatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int y = 0; y < matriz.GetLength(1); y++)
                    matriz[i, y] = i.ToString() + "," + y.ToString();
        }
        static void imprime(string[,] matriz)
        {
            for(int i = 0; i < matriz.GetLength(0); i++) { 
                for(int y = 0; y < matriz.GetLength(1); y++) {
                    Console.Write("\t" + matriz[i, y]);
                }
                Console.WriteLine("");
            }
        }
    }
}

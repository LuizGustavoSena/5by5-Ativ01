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
            string[,] velha = new string[3, 3];
            int Quem_Comeca;
            bool jogador1 = false;

            //Controlando a entrada do usuario
            Console.WriteLine("O primeiro jogador sempre começa como X e o segundo como O");
            do
            {
                Console.WriteLine("Informe quem vai começar (jogador 1 digite 1 , jogador 2 digite 2) : ");
                Quem_Comeca = int.Parse(Console.ReadLine());
            } while (Quem_Comeca != 1 && Quem_Comeca != 2);

            if (Quem_Comeca == 1)
            {
                jogador1 = true;
                Console.WriteLine("---------JOGADOR 1 COMEÇA---------\n");
            }
            else
            {
                Console.WriteLine("---------JOGADOR 2 COMEÇA---------\n");
            }

            Console.WriteLine("As posições do jogo são essas:\n");

            iniciamatriz(velha);
            imprime(velha);

            Console.WriteLine("");

            for (int i = 0; i < 9; i++)
            {
                if (jogador1)
                {
                    Console.WriteLine("Jogador 1, sua vez de jogar: ");
                }
                else
                {
                    Console.WriteLine("Jogador 2, sua vez de jogar: ");
                }

                solicita_posicao(velha, jogador1);


                imprime(velha);

                if (verificastatus(velha) == 1) {
                    Console.WriteLine("Jogador 1 ganhou");
                    break;
                }
                else if (verificastatus(velha) == 2) {
                    Console.WriteLine("Jogador 2 ganhou");
                    break;
                }
                if (!jogador1)
                {
                    jogador1 = true;
                }
                else
                {
                    jogador1 = false;
                }
            }

            Console.ReadKey();
        }

        static void iniciamatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int y = 0; y < matriz.GetLength(1); y++)
                    matriz[i, y] = i.ToString() + "," + y.ToString();
        }

        static void solicita_posicao(string[,] matriz, bool jogador1)
        {
            int linha;
            int coluna;

            do
            {
                do
                {
                    Console.Write("Digite a linha: ");
                    linha = int.Parse(Console.ReadLine());

                    Console.Write("Digite a coluna: ");
                    coluna = int.Parse(Console.ReadLine());
                    if (linha > (matriz.GetLength(0) - 1) || (coluna > matriz.GetLength(1) - 1))
                        Console.WriteLine("DIGITE UM VALOR DENTRO DA MATRIZ");
                } while (linha > (matriz.GetLength(0) - 1) || (coluna > matriz.GetLength(1) - 1));
                

                if (matriz[linha, coluna] == "X" || matriz[linha, coluna] == "O")
                   Console.WriteLine("DIGITE UMA POSIÇÃO NÃO USADA");
            } while (matriz[linha, coluna] == "O" || matriz[linha, coluna] == "X");

            Console.WriteLine("");

            if (jogador1)
                matriz[linha, coluna] = "X";
            else
                matriz[linha, coluna] = "O";

            return;
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

        static int verificastatus(string[,] matriz)
        {
            string comparar;
            bool repete = false;
            //HORIZONTAL
            
            for(int i = 0; i < matriz.GetLength(0); i++) { 
                for(int y = 0; y < 1; y++)
                {
                    comparar = matriz[i, y];

                    for (int c = 1; c < matriz.GetLength(1); c++)
                    {
                        if(comparar == matriz[i, c])
                        {
                            if (repete) {
                                if (matriz[i, c] == "X")
                                    return 1;
                                else
                                    return 2;
                            }
                            repete = true;
                        }
                    }
                    repete = false;
                }
            }

            repete = false;

            for (int l = 0; l < 1; l++)
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    comparar = matriz[l, c];

                    for (int z = 1; z < matriz.GetLength(0); z++)
                    {
                        if (comparar == matriz[z, c])
                        {
                            Console.WriteLine("[{0}][{1}]", z, c);
                            if (repete)
                            {
                                Console.WriteLine("repete [{0}][{1}]", z, c);

                                if (matriz[z, c] == "X")
                                    return 1;
                                else
                                    return 2;
                            }
                            repete = true;
                        }
                    }
                    repete = false;
                }
            
            return 0;
        }
    }
}

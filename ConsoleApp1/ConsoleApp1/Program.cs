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
            string Quem_Comeca;
            bool jogador1 = false;
            int situacao;

            Console.WriteLine("PARA JOGAR VERIFIQUE AS POSIÇÕES DISPONÍVEIS\n" +
                                    "INFORMADA POR (LINHA, COLUNA) NA MATRIZ\n" +
                                    "E INFORME PRIMEIRO A LINHA E DEPOIS A COLUNA\n");

            do // LOOP VALOR DIFERENTE QUE 1 OU 2 PARA O JOGADOR
            {
                Console.WriteLine("Informe quem irá começar\n" +
                    "Jogador 1 (X) digite 1\nJogador 2 (O) digite 2");
                Quem_Comeca = Console.ReadLine();

            } while (Quem_Comeca != "1" && Quem_Comeca != "2");

            Console.Clear(); // LIMPA TELA DO CONSOLE

            if (Quem_Comeca == "1")
                jogador1 = true;

            iniciamatriz(velha);
            imprime(velha);

            Console.WriteLine("");

            for (int i = 0; i < 9; i++)
            {
                if (jogador1)
                    Console.WriteLine("\n---------JOGADOR 1 (X)---------");
                else
                    Console.WriteLine("\n---------JOGADOR 2 (O)---------");

                solicita_posicao(velha, jogador1);

                Console.Clear(); // LIMPA TELA DO CONSOLE

                imprime(velha);

                situacao = verificastatus(velha);

                if (situacao == 1)
                {
                    Console.WriteLine("Jogador 1 (X) ganhou");
                    break;
                }
                else if (situacao == 2)
                {
                    Console.WriteLine("Jogador 2 (O) ganhou");
                    break;
                }
                else if (situacao == 0 && i == 8)
                    Console.WriteLine("VELHA");

                if (!jogador1)
                    jogador1 = true;
                else
                    jogador1 = false;
            }

            Console.ReadKey();
        }

        static void iniciamatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int y = 0; y < matriz.GetLength(1); y++)
                    matriz[i, y] = i + "," + y;
        }

        static void solicita_posicao(string[,] matriz, bool jogador1)
        {
            int linha;
            int coluna;
            try
            {
                do // LOOP NÚMERO EM UMA POSIÇÃO JÁ UTILIZADA
                {
                    do // LOOP NÚMERO EM UMA POSIÇÃO MAIOR QUE O TAMANHO DA MATRIZ
                    {
                        Console.Write("Digite a linha: ");
                        linha = int.Parse(Console.ReadLine());

                        Console.Write("Digite a coluna: ");
                        coluna = int.Parse(Console.ReadLine());
                        if (linha > (matriz.GetLength(0) - 1) || (coluna > matriz.GetLength(1) - 1) || linha < 0 || coluna < 0)
                            Console.WriteLine("DIGITE UM VALOR DENTRO DA MATRIZ");
                    } while (linha > (matriz.GetLength(0) - 1) || (coluna > matriz.GetLength(1) - 1) || linha < 0 || coluna < 0);

                    if (matriz[linha, coluna] == " X" || matriz[linha, coluna] == " O")
                        Console.WriteLine("DIGITE UMA POSIÇÃO NÃO USADA");
                } while (matriz[linha, coluna] == " O" || matriz[linha, coluna] == " X");

                Console.WriteLine("");

                if (jogador1)
                    matriz[linha, coluna] = " X";
                else
                    matriz[linha, coluna] = " O";

            }
            catch (Exception)
            {
                Console.WriteLine("Digite apenas números existentes na matriz");
                solicita_posicao(matriz, jogador1);
            }

            return;
        }
        static void imprime(string[,] matriz)
        {
            Console.WriteLine("As posições do jogo são essas:\n");

            Console.WriteLine("\t-------------------------");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                    Console.Write("\t|  " + matriz[i, y]);

                Console.Write("\t|"); // DEIXAR MATRIZ EM UM FORMATO DE TABULEIRO
                Console.WriteLine("");
                Console.Write("\t-------------------------");
                Console.WriteLine("");
            }
        }

        static int verificastatus(string[,] matriz)
        {
            string comparar;
            bool repete = false;

            // VERIFICA DIAGONAL SECUNDÁRIA
            comparar = matriz[1, 1];
            for (int i = 0, y = 2; i < 2 * (matriz.GetLength(0) - 1); i += 2, y -= 2)
            {
                if (comparar == matriz[i, y])
                {
                    if (repete)
                    {
                        if (matriz[i, y] == " X")
                            return 1;
                        else
                            return 2;
                    }

                    repete = true;
                }
            }

            repete = false;
            // VERIFICA DIAGONAL PRINCIPAL
            comparar = matriz[0, 0];
            for (int i = 1; i < matriz.GetLength(0); i++)
            {
                if (comparar == matriz[i, i])
                {
                    if (repete)
                    {
                        if (matriz[i, i] == " X")
                            return 1;
                        else
                            return 2;
                    }
                    repete = true;
                }
            }

            repete = false;
            // VERIFICA HORIZONTAL
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int y = 0; y < 1; y++)
                {
                    comparar = matriz[i, y];

                    for (int c = 1; c < matriz.GetLength(1); c++)
                    {
                        if (comparar == matriz[i, c])
                        {
                            if (repete)
                            {
                                if (matriz[i, c] == " X")
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
            // VERIFICA VERTICAL
            for (int l = 0; l < 1; l++)
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    comparar = matriz[l, c];

                    for (int z = 1; z < matriz.GetLength(0); z++)
                    {
                        if (comparar == matriz[z, c])
                        {
                            if (repete)
                            {
                                if (matriz[z, c] == " X")
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

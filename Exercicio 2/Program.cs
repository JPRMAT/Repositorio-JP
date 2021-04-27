using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //variáveis
            int VJ;
            int VC;
            string OD;
            int NR = 0;
            var A = new Random();
            double TT = 0;
            int Rslt = 0;


            Console.WriteLine("Bem vindo ao jogo! A menor pontuação vence.");
            NR = ValorJogadorDigitado("Diga quantas rodadas voce quer jogar. Deve ser menor que 5", "Voce nao atendeu os requisitos", 0, 5);

            double[] medidas = new double[NR];

            //loop de rodadas

            for (int R = 0; R < NR; R = R + 1)
            {

                Console.WriteLine("Vamos jogar uma rodada");

                //input do jogador
                VJ = ValorJogadorDigitado("Digite um valor entre 1 e 50", "O que voce digitou nao atende os requisitos", 1, 50);

                //vez do computador e input de operação
                Console.WriteLine("O Computador vai gerar um número.");
                VC = A.Next(1, 11);

                string[] valores_validos = { "A", "S", "M", "CANCEL" };

                OD = ValorDigitadoTratado("Digite A para adição e S para subtração M para multiplicação (ou CANCEL)",
                                          "Você não digitou algo válido. Tente novamente. A para + e S para -",
                                          valores_validos);

                //seleção de operação
                switch (OD)
                {
                    case "A":
                        Console.WriteLine("Você escolheu adição.");
                        Rslt = VJ + VC;
                        break;
                    case "S":
                        Console.WriteLine("Você escolheu subtração.");
                        Rslt = VJ - VC;
                        break;
                    case "M":
                        Console.WriteLine("Você escolheu multiplicação.");
                        Rslt = VJ * VC;
                        break;
                    default:
                        Console.WriteLine("não resolvi.");
                        break;
                }


                //resultado e input do palpite
                Console.WriteLine("O resultado da operação foi: " + Rslt);

                DateTime antes = DateTime.Now;

                string[] valor_valido = { VC.ToString() };
                string valor_certo = ValorDigitadoTratado("Tente acertar o número gerado pelo computador.",
                                                          "Você errou ou não digitou um número. Tente novamente.",
                                                          valor_valido);

                //sucesso
                Console.WriteLine("Você acertou!");
                medidas[R] = (int)DateTime.Now.Subtract(antes).TotalMilliseconds;
                TT = TT + (int)DateTime.Now.Subtract(antes).TotalMilliseconds;

            }

            //fim de jogo
            Console.WriteLine("O jogo terminou. Suas pontuacoes em milisegundos:");
            for (int Q = 1; Q <= NR; Q = Q + 1)
            {
                Console.WriteLine("Rodada" + Q + ": " + medidas[Q]);
            }
            TT = MediaTempo(medidas);
            Console.WriteLine("A media entre as rodadas foi: " + TT);

        }

        static double MediaTempo(double[] tempos)
        {
            double soma = 0;
            double media = 0;
            for (int i = 0; i < tempos.Length; i++)
            {
                soma = soma + tempos[0];
            }
            media = soma / tempos.Length;
            return media;
        }

        static int ValorJogadorDigitado(string mensagem, string mensagem_erro, int valor_min, int valor_max)
        {

            Console.WriteLine(mensagem);
            string digitado = Console.ReadLine();
            int numero = 0;
            bool Convers = int.TryParse(digitado, out numero);

            while (Convers == false || numero < valor_min || numero > valor_max)
            {
                Console.WriteLine(mensagem_erro);
                numero = 0;
                Convers = true;
                digitado = Console.ReadLine();
                Convers = int.TryParse(digitado, out numero);
            }

            return numero;

        }

        static string ValorDigitadoTratado(string mensagem,
                                           string mensagem_erro,
                                           string[] possiveis_valores)
        {
            Console.WriteLine(mensagem);
            string dado;
            bool achou = false;
            do
            {
                dado = Console.ReadLine();
                for (int i = 0; i < possiveis_valores.Length; i++)
                {
                    if (possiveis_valores[i] == dado)
                    {
                        achou = true;
                        break;
                    }
                }

                if (!achou)
                    Console.WriteLine(mensagem_erro);

            } while (!achou);
            

            return dado;
        }
    }
}

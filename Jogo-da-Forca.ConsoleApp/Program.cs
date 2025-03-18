namespace Jogo_da_Forca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //escolha da palavra
                string palavraEscolhida = EscolherPalavra();

                //

                char[] letrasEncontradas = new char [palavraEscolhida.Length];

                for (int caractereAtual = 0; caractereAtual < letrasEncontradas.Length; caractereAtual++)
                {
                    letrasEncontradas[caractereAtual] = '_';
                }

                int quantidadeErros = 0;
                bool jogadorEnforcou = false;
                bool jogadorAcertou = false;

                do
                {
                    //Menu da forca

                    char chute = MenuDaForca(quantidadeErros, letrasEncontradas);

                    bool letraFoiEncontrada = VerificarLetraPalavra(palavraEscolhida, chute, letrasEncontradas);

                    if (letraFoiEncontrada == false)
                        quantidadeErros++;

                    string palavraEncontrada = String.Join("", letrasEncontradas);

                    jogadorAcertou = palavraEncontrada == palavraEscolhida;
                    jogadorEnforcou = quantidadeErros > 5;

                    VerificarPalavra(palavraEscolhida, jogadorEnforcou, jogadorAcertou);
                } while (jogadorEnforcou == false && jogadorAcertou == false);

                Console.Write("Deseja continuar? (S/N): ");

                string opcaoContinuar = Console.ReadLine()!.ToUpper();

                if (opcaoContinuar != "S")
                    break;
            }
        }
       static void VerificarPalavra(string palavraEscolhida, bool jogadorEnforcou, bool jogadorAcertou)
        {
            if (jogadorAcertou)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Você acertou a palavra secreta {palavraEscolhida}, parabéns!");
                Console.WriteLine("------------------------------");
            }
            else if (jogadorEnforcou)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Que azar! Tente novamente!");
                Console.WriteLine("--------------------------");
            }
        }

        static string EscolherPalavra()
        {
            string[] palavras =
                 {
                 "ABACATE",
                 "ABACAXI",
                 "ACEROLA",
                 "ACAI",
                 "ARACA",
                 "ABACATE",
                 "BACABA",
                 "BACURI",
                 "BANANA",
                 "CAJA",
                 "CAJU",
                 "CARAMBOLA",
                 "CUPUACU",
                 "GRAVIOLA",
                 "GOIABA",
                 "JABUTICABA",
                 "JENIPAPO",
                 "MACA",
                 "MANGABA",
                 "MANGA",
                 "MARACUJA",
                 "MURICI",
                 "PEQUI",
                 "PITANGA",
                 "PITAYA",
                 "SAPOTI",
                 "TANGERINA",
                 "UMBU",
                 "UVA",
                 "UVAIA"
                };
            Random random = new Random();

            int indiceEscolhido = random.Next(palavras.Length);

            string palavraEscolhida = palavras[indiceEscolhido];

            return palavraEscolhida;
        }

        static char MenuDaForca(int quantidadeErros,char[] letrasEncontradas)
        {
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string bracoDireito = quantidadeErros >= 4 ? @"\" : " ";
            string pernas = quantidadeErros >= 5 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("-----------------");
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
            Console.WriteLine("-----------------");
            Console.WriteLine("Erros do jogador: " + quantidadeErros);
            Console.WriteLine("-----------------");
            Console.WriteLine("Palavra escolhida: " + String.Join("", letrasEncontradas));
            Console.WriteLine("-----------------");

            Console.WriteLine("Digite uma letra válida: ");
            char chute = Console.ReadLine()!.ToUpper()[0];

            return chute;
        }

        static bool VerificarLetraPalavra(string palavraEscolhida,char chute, char[] letrasEncontradas)
        {
            bool letraFoiEncontrada = false;
            for (int contador = 0; contador < palavraEscolhida.Length; contador++)
            {
                char letraAtual = palavraEscolhida[contador];

                if (chute == letraAtual)
                {
                    letrasEncontradas[contador] = letraAtual;
                    letraFoiEncontrada = true;
                }
            }
            return letraFoiEncontrada;
        }
    }
}

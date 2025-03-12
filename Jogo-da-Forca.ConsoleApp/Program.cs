namespace Jogo_da_Forca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palavraescolhida = "MELANCIA";

            char[] letrasEncontradas = new char[palavraescolhida.Length];

            for (int caractereAtual = 0; caractereAtual < letrasEncontradas.Length; caractereAtual++) 
            {
                letrasEncontradas[caractereAtual] = '_';
            }
                        
              do //faça
            {
                string letrasEncontradasCompleta = String.Join("", letrasEncontradas);
                
                Console.Clear();
                Console.WriteLine("-----------------");
                Console.WriteLine("Jogo da Forca");
                Console.WriteLine("-----------------");
                Console.WriteLine("Palavra escolhida: " + letrasEncontradasCompleta);
                Console.WriteLine("-----------------");


                //dado caractere

                Console.WriteLine("Digite uma letra válida: ");
                string entradainicial = Console.ReadLine()!.ToUpper();

                if (entradainicial.Length > 1)
                {
                    Console.WriteLine("Informe apenas um caractere.");
                    return;

                }
                char chute = entradainicial[0];

                for (int contadorCaractere = 0; contadorCaractere < palavraescolhida.Length; contadorCaractere++)
                {
                    char caractereAtual = palavraescolhida[contadorCaractere];

                    if (chute == caractereAtual)
                    {
                        letrasEncontradas[contadorCaractere] = caractereAtual;
                    }
                                    
                }

                Console.WriteLine(chute);

                Console.ReadLine();
            } while (true); //enquanto (condição)
        }
    }
}

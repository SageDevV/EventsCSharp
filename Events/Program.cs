namespace events
{
    public class Program
    {
        public delegate void OcorrenciaOperacao(double a);

        public static event OcorrenciaOperacao AoOcorrerOperacao;

        public delegate double OcorrenciaRetornoValor(double a, double b);

        public static event OcorrenciaRetornoValor AoOcorrerRetornoValor;

        static void Main(string[] args)
        {
            AoOcorrerOperacao += PrintResult;
            AoOcorrerOperacao += AoQuadrado;
            AoOcorrerOperacao += AoCubo;
            AoOcorrerOperacao += RaizAoQuadrado;

            AoOcorrerRetornoValor += Subtracao;
            AoOcorrerRetornoValor += Soma;


            double a = 30;
            double b = 20;

            Console.WriteLine();
            Console.WriteLine($"Referência para {nameof(a)}");
            Console.WriteLine();

            AoOcorrerOperacao.Invoke(a);

            Console.WriteLine();
            Console.WriteLine($"Referência para {nameof(b)}");
            Console.WriteLine();

            AoOcorrerOperacao.Invoke(b);

            Console.WriteLine();
            Console.WriteLine($"Referência para {nameof(a)} e {nameof(b)}");
            Console.WriteLine();

            var resultValue = AoOcorrerRetornoValor.Invoke(b, a);
            Console.WriteLine($"O resultado da operação entre {a} e {b} é {resultValue}");
        }

        //Referências para o evento AoOcorrerOperacao
        public static void PrintResult(double a)
        {
            Console.WriteLine($"O valor de a é {a}");
        }

        public static void AoQuadrado(double a)
        {
            Console.WriteLine($"O resultado da potenciação ao quadrado de {a} é {Math.Pow(a, 2)}");
        }

        public static void AoCubo(double a)
        {
            Console.WriteLine($"O resultado da potenciação ao cubo de {a} é {Math.Pow(a, 3)}");
        }

        public static void RaizAoQuadrado(double a)
        {
            Console.WriteLine($"O resultado da radiciação ao quadrado de {a} é {Math.Sqrt(a)}");
        }

        //Referência para o evento AoOcorrerValor
        public static double Soma(double b, double a)
        {
            return b + a;
        }

        public static double Subtracao(double b, double a)
        {
            return b - a;
        }
    }
}
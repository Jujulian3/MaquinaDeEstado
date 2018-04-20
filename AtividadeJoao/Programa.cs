using System;
using System.Text.RegularExpressions;

namespace MaquinaDeEstado.Programa
{
    class Programa
    {
        static void Main(string[] args)
        {
            String sair = "";
            while (sair != "EXIT")
            {
                Console.WriteLine("Informe a entrada: ");
                string palavra = Console.ReadLine();

                Maquina maquina = new Maquina();
                Console.WriteLine(maquina.Verificar(palavra));

                Console.WriteLine("\n\nPara sair digite EXIT ou presione ENTER para continuar");
                sair = Console.ReadLine().ToUpper();
            }
        }
    }
}

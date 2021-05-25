using System;

namespace EscreveCheque
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeroConvertido = "";
            ConversorNumero conversorNumero = new ConversorNumero();

            Console.Write("Digite o valor do cheque: ");
            string valorDigitado = Console.ReadLine();
            if (conversorNumero.validaStringNumero(valorDigitado) == -1)
                Console.WriteLine($"Não foi possível converter o valor: {valorDigitado} em número");
            else
                numeroConvertido = conversorNumero.EscreverExtenso(conversorNumero.validaStringNumero(valorDigitado));
            Console.WriteLine(numeroConvertido);
        }
    }
}

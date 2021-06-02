using System;
using System.Collections.Generic;
using System.Text;

namespace EscreveCheque
{
    public class ConversorNumero
    {
        Quantificadores quantificador = new Quantificadores();

        public double validaStringNumero(string numeroString)
        {
            numeroString = numeroString.Replace(".", ",");
            double numeroConvertido = 0;
            try
            {
                numeroConvertido = Double.Parse(numeroString);
            }
            catch (Exception)
            {
                numeroConvertido = -1;
            }
            return numeroConvertido;
        }

       
        public string EscreverExtenso(double valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;
                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += quantificador.Escrever_Valor_Extenso(Convert.ToDouble(strValor.Substring(i, 3)));
                    valor_por_extenso = EscreveTrilhaoBilhaoMilhaoMil(strValor, valor_por_extenso, i);
                    if (i == 12)
                    {
                        valor_por_extenso = Adiciona_DE(valor_por_extenso);
                        valor_por_extenso = Adiciona_REAL(strValor, valor_por_extenso);
                        valor_por_extenso = Adiciona_E(strValor, valor_por_extenso);
                    }
                    if (i == 15)
                        valor_por_extenso = EscreveCentavosDeReal(strValor, valor_por_extenso);
                }
                return valor_por_extenso;
            }
        }

        private static string Adiciona_E(string strValor, string valor_por_extenso)
        {
            if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                valor_por_extenso += " E ";
            return valor_por_extenso;
        }

        private static string Adiciona_REAL(string strValor, string valor_por_extenso)
        {
            if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                valor_por_extenso += " REAL";
            else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                valor_por_extenso += " REAIS";
            return valor_por_extenso;
        }

        private static string Adiciona_DE(string valor_por_extenso)
        {
            if (valor_por_extenso.Length > 8)
                if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                    valor_por_extenso += " DE";
                else
                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES"
| valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                    valor_por_extenso += " DE";
                else
                        if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                    valor_por_extenso += " DE";
            return valor_por_extenso;
        }

        private static string EscreveCentavosDeReal(string strValor, string valor_por_extenso)
        {
            if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                valor_por_extenso += " CENTAVO DE REAL";
            else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                valor_por_extenso += " CENTAVOS DE REAL";
            return valor_por_extenso;
        }

        private static string EscreveTrilhaoBilhaoMilhaoMil(string strValor, string valor_por_extenso, int i)
        {
            if (i == 0 & valor_por_extenso != string.Empty)
            {
                valor_por_extenso = EscreveTrilhao(strValor, valor_por_extenso);
            }
            else if (i == 3 & valor_por_extenso != string.Empty)
            {
                valor_por_extenso = EscreveBilhao(strValor, valor_por_extenso);
            }
            else valor_por_extenso = EscreveMil(strValor, valor_por_extenso, i);
            return valor_por_extenso;
        }

        private static string EscreveMil(string strValor, string valor_por_extenso, int i)
        {
            if (i == 6 & valor_por_extenso != string.Empty)
            {
                valor_por_extenso = EscreveMilhao(strValor, valor_por_extenso);
            }
            else if (i == 9 & valor_por_extenso != string.Empty)
                if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                    valor_por_extenso += " MIL" + ((Convert.ToDouble(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);
            return valor_por_extenso;
        }

        private static string EscreveMilhao(string strValor, string valor_por_extenso)
        {
            if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                valor_por_extenso += " MILHÃO" + ((Convert.ToDouble(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
            else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                valor_por_extenso += " MILHÕES" + ((Convert.ToDouble(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
            return valor_por_extenso;
        }

        private static string EscreveBilhao(string strValor, string valor_por_extenso)
        {
            if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                valor_por_extenso += " BILHÃO" + ((Convert.ToDouble(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
            else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                valor_por_extenso += " BILHÕES" + ((Convert.ToDouble(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
            return valor_por_extenso;
        }

        private static string EscreveTrilhao(string strValor, string valor_por_extenso)
        {
            if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                valor_por_extenso += " TRILHÃO" + ((Convert.ToDouble(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
            else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                valor_por_extenso += " TRILHÕES" + ((Convert.ToDouble(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
            return valor_por_extenso;
        }
    }
}

using System;

namespace DelfosForm
{
    public class ConvNumero
    {
        
        public string formatar(string numero)
        {
            int posicaoPonto;
            char vchar;
            string aux = "";
            bool fl = true;

            if (numero.Length == 0) return "0,00";

            for (int i = 0; i < numero.Length; i++)
            {
                vchar = Convert.ToChar(numero.Substring(i, 1));
                if (vchar < 58 && vchar > 47) aux += numero.Substring(i, 1);
                if (numero.Substring(i, 1) == ",") 
                {
                    if (fl)
                    {
                        aux += ",";
                        fl = false;
                    }
                }
            }

            numero = aux;
            posicaoPonto = numero.IndexOf(",");

            if (posicaoPonto == -1)
            {
                posicaoPonto = numero.Length;
                numero += ",00";
            }

            if (numero.Substring(posicaoPonto, 1) == ".")
            {
                numero = numero.Substring(0, posicaoPonto) + "," +
                    numero.Substring(posicaoPonto + 1, numero.Length - posicaoPonto - 1);
            }

            if (posicaoPonto < numero.Length - 3) numero = numero.Substring(0, posicaoPonto + 1) +
                    numero.Substring(posicaoPonto + 1, 2);

            if (posicaoPonto + 1 == numero.Length) numero += "00";

            if (posicaoPonto + 2 == numero.Length) numero += "0";

            if (posicaoPonto == 0)
            {
                numero = "0" + numero;
                posicaoPonto = 1;
            }

            aux = numero.Substring(0, posicaoPonto);
            string aux1 = "";
            int pos = 0;

            if (aux.Length > 3)
            {
                for (int i = aux.Length-1; i > -1; i--)
                {
                    pos += 1;
                    if (pos > 3)
                    {
                        aux1 = "." + aux1;
                        pos = 1;
                    }
                    aux1 = aux.Substring(i, 1) + aux1;
                }
                numero = aux1 + numero.Substring(posicaoPonto, 3);
            }

            return numero;
        }

        public Double desformatar(string numero)
        {
            string aux = "";
            char vchar;

            for (int i = 0; i < numero.Length; i++)
            {
                vchar = Convert.ToChar(numero.Substring(i, 1));
                if (vchar < 58 && vchar > 47) aux += numero.Substring(i, 1);
            }

            if (numero.IndexOf(",") == numero.Length -1 || numero.IndexOf(",") == - 1)
                return Double.Parse(aux);

            if (numero.IndexOf(",") == numero.Length - 2)
                return Double.Parse(aux) / 10;
            else
                return Double.Parse(aux) / 100;
        }

    }
}
